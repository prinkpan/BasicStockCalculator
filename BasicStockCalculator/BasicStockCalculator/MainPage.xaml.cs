using BasicStockCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicStockCalculator
{
    public partial class MainPage : ContentPage
	{
        public static double EnteredValue { get; set; }
        public static ObservableCollection<string> Calculations { get; set; }

		public MainPage()
		{
            Calculations = new ObservableCollection<string>();
            InitializeComponent();
		}

        void OnValueChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                BSCSettingsVM bscSettings = new BSCSettingsVM();
                Calculations.Clear();
                if(e.NewTextValue.Length > 0)
                {
                    EnteredValue = Convert.ToDouble(e.NewTextValue);
                    var percent = Convert.ToDouble(bscSettings.StartRange);
                    for(double i = bscSettings.StartRange; percent < bscSettings.EndRange; i += bscSettings.Step)
                    {
                        percent = Math.Round(i, 1);
                        Calculations.Add(percent + "% : " + String.Format("{0:0.00}", ((i / 100) * EnteredValue) + EnteredValue));
                    }
                }
            }
            catch
            {
                //Handle exception
            }
        }

        void OnSettingsClicked(object sender, EventArgs e)
        {
            var settings = new SettingsPage();
            this.Navigation.PushAsync(settings);
        }
    }
}