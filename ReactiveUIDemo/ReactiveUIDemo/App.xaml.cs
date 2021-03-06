﻿using ReactiveUIDemo.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveUIDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var bootstrapper = new AppBootstrapper(); 
            MainPage = bootstrapper.CreateMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
