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
        public int StartRange
        {
            get => Settings.StartRange;
            set
            {
                if (Settings.StartRange == value)
                    return;
                Settings.StartRange = value;
                OnPropertyChanged();
            }
        }

        public int EndRange
        {
            get => Settings.EndRange;
            set
            {
                if (Settings.EndRange == value)
                    return;
                Settings.EndRange = value;
                OnPropertyChanged();
            }
        }

        public double Step
        {
            get => Settings.Step;
            set
            {
                if (Settings.Step == value)
                    return;
                Settings.Step = value;
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
