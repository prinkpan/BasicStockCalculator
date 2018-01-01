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
                var SliderVal = bscSettings.SliderVal;

                PercentageCalculations.Clear();
                if(e.NewTextValue.Length > 0)
                {
                    EnteredValue = Convert.ToDouble(e.NewTextValue);
                    for (double i = 0; i <= SliderVal; i++)
                    {
                        PercentageCalculations.Add(new Calculation()
                        {
                            Percentage = Math.Round(i, 1) + "%",
                            Positive = String.Format("{0:0.00}", ((i / 100) * EnteredValue)) + " : " + String.Format("{0:0.00}", ((i / 100) * EnteredValue) + EnteredValue),
                            Negative = String.Format("{0:0.00}", ((i / 100) * EnteredValue)) + " : " + String.Format("{0:0.00}", ((i / 100) * EnteredValue) + EnteredValue),
                            BgColorPercentage = Color.FromHex("#FFFFFF"),
                            BgColorPositive = Color.FromHex("#EFFCD7"),
                            BgColorNegative = Color.FromHex("#FDF3F2")
                        });
                    }
                    if (PercentageCalculations.Count == 0)
                    {
                        PercentageCalculations.Add(new Calculation() { Percentage = "Not applicable", BgColorPercentage = Color.White, Positive = "Not applicable", BgColorPositive= Color.White, Negative= "Not applicable", BgColorNegative= Color.White });
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