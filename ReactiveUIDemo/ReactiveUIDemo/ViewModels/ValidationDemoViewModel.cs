using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace ReactiveUIDemo.ViewModels
{
    public class ValidationDemoViewModel : ReactiveObject, IValidatableViewModel
    {
        public ValidationContext ValidationContext { get; } = new ValidationContext();

        private DateTime _birthdate; 
        public DateTime Birthdate
        {
            get => _birthdate;
            set { this.RaiseAndSetIfChanged(ref _birthdate, value); }
        }

        public ICommand SubmitCommand { get; }

        public ValidationDemoViewModel()
        {
            this.ValidationRule(vm => vm.Birthdate,
                                value => value > new DateTime(1970, 1, 1) && value < new DateTime(1999, 12, 31),
                                "Birthday should be between 1-1-1970 and 21-31-1999");

            var isValid = this.IsValid();

            SubmitCommand = ReactiveCommand.Create(() =>
            {
                Debug.WriteLine($"{Birthdate} submitted!");
            }, isValid);
        }
    }
}
