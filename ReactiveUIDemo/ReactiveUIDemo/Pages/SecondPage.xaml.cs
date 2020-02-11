using ReactiveUI.XamForms;
using ReactiveUIDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveUIDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ReactiveContentPage<SecondViewModel>
    {
        public SecondPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new SecondViewModel(null); 
        }
    }
}