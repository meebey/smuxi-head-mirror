/*
 * Smuxi - Smart MUltipleXed Irc
 *
 * Copyright (c) 2005-2008, 2012-2013, 2015 Mirco Bauer <meebey@meebey.net>
 *
 * Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA
 */

using System;
using System.Runtime.Remoting;
using System.Reflection;
using Gtk.Extensions;
using Smuxi.Common;

namespace Smuxi.Frontend.Gnome
{ 
    public class MainClass
    {
#if LOG4NET
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
#endif
        static readonly string LibraryTextDomain = "smuxi-frontend-gnome";
        static SingleApplicationInstance<CommandLineInterface> Instance { get; set; }

        public static void Main(string[] args)
        {
            bool debug = false;
            foreach (string arg in args) {
                switch (arg) {
                    case "-d":
                    case "--debug":
                        debug = true;
                        break;
                    case "-h":
                    case "--help":
                        ShowHelp();
                        Environment.Exit(0);
                        break;
                    /*
                    // don't block other parameters as we pass them to
                    // GTK+ / GNOME too
                    default:
                        Console.WriteLine("Invalid option: " + arg);
                        Environment.Exit(1);
                        break;
                    */
                }
            }
            
#if LOG4NET
            // initialize log level
            log4net.Repository.ILoggerRepository repo = log4net.LogManager.GetRepository();
            if (debug) {
                repo.Threshold = log4net.Core.Level.Debug;
            } else {
                repo.Threshold = log4net.Core.Level.Info;
            }
#endif

            try {
                try {
                    Instance = new SingleApplicationInstance<CommandLineInterface>();
                    if (Instance.IsFirstInstance) {
                        Instance.FirstInstance = new CommandLineInterface();
                    } else {
                        var msg = _("Bringing already running Smuxi instance to foreground...");
#if LOG4NET
                        _Logger.Info(msg);
#else
                        Console.WriteLine(msg);
#endif
                        Instance.FirstInstance.PresentMainWindow();
                        return;
                    }
                } catch (Exception ex) {
#if LOG4NET
                    _Logger.Warn("Single application instance error, ignoring...", ex);
#endif
                }

                Frontend.Init(args);
            } catch (Exception e) {
#if LOG4NET
                _Logger.Fatal(e);
#endif
                // when Gtk# receives an exception it is not usable/relyable anymore! 
                // except the exception was thrown in Frontend.Init() itself
                if (Frontend.IsGtkInitialized && !Frontend.InGtkApplicationRun) {
                    Frontend.ShowException(e);
                }
                
                // rethrow the exception for console output
                throw;
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage: smuxi-frontend-gnome [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  -h --help                Show this help");
            Console.WriteLine("  -d --debug               Enable debug output");
            Console.WriteLine("  -e --engine engine-name  Connect to engine");
        }

        static string _(string msg)
        {
            return LibraryCatalog.GetString(msg, LibraryTextDomain);
        }
    }

    public class CommandLineInterface : SingleApplicationInterface
    {
        public void PresentMainWindow()
        {
            if (!Frontend.IsGtkInitialized || !Frontend.InGtkApplicationRun) {
                return;
            }

            Gtk.Application.Invoke(delegate {
                var window = Frontend.MainWindow;
                if (window == null) {
                    return;
                }
                window.PresentWithServerTime();
            });
        }

        public override object InitializeLifetimeService()
        {
            // live forever
            return null;
        }
    }
}
