using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReactiveUIDemo.ViewModels
{
    public class ColorsDemoViewModel : ReactiveObject
    {

        #region Properties 
        private int _red;
        public int Red
        {
            get => _red;
            set
            {
                this.RaiseAndSetIfChanged(ref _red, value);
                this.RaisePropertyChanged(nameof(BackgroundColor));
            }
        }

        private int _green;
        public int Green
        {
            get => _green;
            set
            {
                this.RaiseAndSetIfChanged(ref _green, value);
                this.RaisePropertyChanged(nameof(BackgroundColor));
            }
        }

        private int _blue; 
        public int Blue
        {
            get => _blue; 
            set
            {
                this.RaiseAndSetIfChanged(ref _blue, value);
                this.RaisePropertyChanged(nameof(BackgroundColor));
            }
        }

        public Color BackgroundColor
        {
            get => Color.FromRgb(Red, Green, Blue);
        }

        #endregion 

    }
}
