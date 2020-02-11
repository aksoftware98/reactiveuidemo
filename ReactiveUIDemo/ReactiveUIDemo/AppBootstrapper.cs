using ReactiveUI;
using ReactiveUI.XamForms;
using ReactiveUIDemo.Pages;
using ReactiveUIDemo.Services;
using ReactiveUIDemo.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ReactiveUIDemo
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen)); 

            RegisterServices();
            RegisterViews(); 

            Router.Navigate.Execute(new FirstViewModel());
        }

        public RoutingState Router { get; }

        private void RegisterServices()
        {
            Splat.Locator.CurrentMutable.Register(() => new StaticContactsService(), typeof(IContactsService));
        }

        private void RegisterViews()
        {
            Locator.CurrentMutable.Register(() => new FirstPage(), typeof(IViewFor<FirstViewModel>)); 
            Locator.CurrentMutable.Register(() => new SecondPage(), typeof(IViewFor<SecondViewModel>));
            //Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly()); 
        }

        public Page CreateMainPage()
        {
            return new RoutedViewHost(); 
        }
    }
}
