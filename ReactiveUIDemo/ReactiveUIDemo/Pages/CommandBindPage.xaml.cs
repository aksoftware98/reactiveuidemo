using ReactiveUI;
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
    public partial class CommandBindPage : ReactiveContentPage<CommandBindViewModel>
    {
        public CommandBindPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = new CommandBindViewModel();

            this.BindCommand(ViewModel, vm => vm.TestCommand, page => page.slider, nameof(slider.ValueChanged));

        }
    }
}