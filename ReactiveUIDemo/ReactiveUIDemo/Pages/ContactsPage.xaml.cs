using ReactiveUI;
using ReactiveUIDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveUIDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage, IViewFor<ContactsViewModel>
    {
        public ContactsPage()
        {
            InitializeComponent();
            var vm = new ContactsViewModel(); 
            BindingContext = ViewModel;

            this.BindCommand(ViewModel, t => t.ClearCommand, v => v.txtSearch, "TextChanged");
        }

        public ContactsViewModel ViewModel { get => new ContactsViewModel(); set { } }
        object IViewFor.ViewModel { get; set; }
    }
}