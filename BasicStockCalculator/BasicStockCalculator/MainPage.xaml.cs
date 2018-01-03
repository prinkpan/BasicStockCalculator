using BasicStockCalculator.Model;
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
        public static ObservableCollection<Calculation> PercentageCalculations { get; set; }

        public MainPage()
		{
            PercentageCalculations = new ObservableCollection<Calculation>();
            InitializeComponent();
		}

        void OnValueChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                BSCSettingsVM bscSettings = new BSCSettingsVM();
                var MaxRange = bscSettings.MaxRange;

                PercentageCalculations.Clear();
                if (e.NewTextValue.Length > 0)
                {
                    EnteredValue = Convert.ToDouble(e.NewTextValue);
                    for (int i = 1; i <= MaxRange; i++)
                    {
                        var percent = (i / 100.00) * EnteredValue;
                        var positive = EnteredValue + percent;
                        var negative = EnteredValue - percent;

                        PercentageCalculations.Add(new Calculation()
                        {
                            Percentage = i + "%",
                            Positive = String.Format("{0:0.00}", percent) + " : " + String.Format("{0:0.00}", positive),
                            Negative = "-" + String.Format("{0:0.00}", percent) + " : " + String.Format("{0:0.00}", negative)
                        });
                    }
                    PercentageListView.ItemsSource = PercentageCalculations;
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