Software Requirements
=====================
First you will need to install a few libraries to compile the source

Libraries:
* Mono SDK (>= 1.9.1)
* Nini (>= 1.1)
* log4net
* GTK# (>= 2.10)
* Notify# (optional)
* Indicate# / MessagingMenu# (optional)
* DBus# / NDesk.DBus (optional)
* GtkSpell (optional)
* STFL (optional)

Depending on your operating system and favorite distribution the installation of the listed applications varies. For Debian based distributions it's just a matter of the following commands:

    apt-get install mono-devel mono-xbuild libnini-cil-dev liblog4net-cil-dev libgtk2.0-cil-dev libglade2.0-cil-dev libnotify-cil-dev libindicate0.1-cil-dev libndesk-dbus-glib1.0-cil-dev libndesk-dbus1.0-cil-dev lsb-release

Compiling Source
================

    ./configure
    make

Installing
==========

    make install

Running
=======

Now you can start Smuxi from the GNOME or KDE menu.

Source Structure
================

src/
----

This directory contains the source code of all Smuxi components.

lib/
----

This directory contains libraries that Smuxi needs and ships as part of Smuxi.

po\*/
-----

These directories contain translation files based on gettext.

debian/
-------

The debian/ directory contains upstream packaging used for the daily development
builds for Ubuntu and Debian found on [launchpad][].
The official (downstream) Debian packaging can be found on [here][].

  [launchpad]: https://launchpad.net/~meebey/+archive/smuxi-daily
  [here]: http://git.debian.org/?p=pkg-cli-apps/packages/smuxi.git
