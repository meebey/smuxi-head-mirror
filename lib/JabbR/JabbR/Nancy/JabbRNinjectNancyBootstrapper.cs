﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Nancy.Owin;
using Ninject;

namespace JabbR.Nancy
{
    public class JabbRNinjectNancyBootstrapper : NinjectNancyBootstrapper
    {
        private readonly IKernel _kernel;

        public JabbRNinjectNancyBootstrapper(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override IKernel GetApplicationContainer()
        {
            return _kernel;
        }

        protected override void ApplicationStartup(IKernel container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.BeforeRequest.AddItemToStartOfPipeline(FlowPrincipal);
        }

        private Response FlowPrincipal(NancyContext context)
        {
            var env = Get<IDictionary<string, object>>(context.Items, NancyOwinHost.RequestEnvironmentKey);
            if (env != null)
            {
                var principal = Get<IPrincipal>(env, "server.User") as ClaimsPrincipal;
                if (principal != null)
                {
                    context.CurrentUser = new ClaimsPrincipalUserIdentity(principal);
                }

                var appMode = Get<string>(env, "host.AppMode");

                if (!String.IsNullOrEmpty(appMode) &&
                    appMode.Equals("development", StringComparison.OrdinalIgnoreCase))
                {
                    context.Items["_debugMode"] = true;
                }
                else
                {
                    context.Items["_debugMode"] = false;
                }
            }

            return null;
        }

        private static T Get<T>(IDictionary<string, object> env, string key)
        {
            object value;
            if (env.TryGetValue(key, out value))
            {
                return (T)value;
            }
            return default(T);
        }
    }
}