using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BasicStockCalculator.Helpers;

namespace BasicStockCalculator.ViewModel
{
    public class BSCSettingsVM : INotifyPropertyChanged
    {
        public double SliderVal
        {
            get => Settings.SliderVal;
            set
            {
                if (Settings.SliderVal == value)
                    return;
                Settings.SliderVal = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
