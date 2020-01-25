using ReactiveUIDemo.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveUIDemo
{
    public class AppBootstrapper
    {
        public AppBootstrapper()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Splat.Locator.CurrentMutable.Register(() => new StaticContactsService(), typeof(IContactsService));
        }

    }
}
