using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace ReactiveUIDemo.ViewModels
{
    public class CommandBindViewModel : ReactiveObject
    {

        public ICommand TestCommand { get; }

        public CommandBindViewModel()
        {
            TestCommand = ReactiveCommand.Create(() =>
            {
                Debug.WriteLine("Command Executed"); 
            });
        }
    }
}
