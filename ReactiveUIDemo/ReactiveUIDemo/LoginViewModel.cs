using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ReactiveUIDemo
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Username))); 
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
