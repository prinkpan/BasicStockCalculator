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
        public static ObservableCollection<Calculation> NegativeCalculations { get; set; }
        public static ObservableCollection<Calculation> PositiveCalculations { get; set; }

        //Both these shades array starts from dark and goes till light
        public readonly string[] GreenShades = { "#000E0C", "#001B16", "#002820", "#00352A", "#004234", "#004F3E", "#005C48", "#006952", "#00765C", "#008366", "#1A8F75", "#349B84", "#4EA793", "#68B3A2", "#82BFB1", "#9CCBC0", "#B6D7CF", "#D0E3DE", "#EAEFED", "#ECF1EF", "#EEF3F1", "#F0F5F3", "#F2F7F5", "#F4F9F7", "#F6FBF9" };
        public readonly string[] RedShades = { "#260908", "#390F0E", "#4C1514", "#5F1B1A", "#722120", "#852726", "#982D2C", "#AB3332", "#BE3938", "#C54D4C", "#CC6160", "#D37574", "#DA8988", "#E19D9C", "#E8B1B0", "#EFC5C4", "#F6D9D8", "#FDEDEC", "#FDEFEE", "#FDF1F0", "#FDF3F2", "#FDF5F4", "#FDF7F6", "#FDF9F8", "#FDFBFA" };

        public MainPage()
		{
            NegativeCalculations = new ObservableCollection<Calculation>();
            PositiveCalculations = new ObservableCollection<Calculation>();
            InitializeComponent();
		}

        void OnValueChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                BSCSettingsVM bscSettings = new BSCSettingsVM();
                var EndRange = bscSettings.EndRange;
                var StartRange = bscSettings.StartRange;
                var Step = bscSettings.Step;

                NegativeCalculations.Clear();
                PositiveCalculations.Clear();
                if(e.NewTextValue.Length > 0)
                {
                    EnteredValue = Convert.ToDouble(e.NewTextValue);
                    var shadeIndex = 0;
                    for (double i = StartRange; i <= EndRange; i += Step)
                    {
                        if(i <= 0)
                        {
                            NegativeCalculations.Add(new Calculation()
                            {
                                Data = Math.Round(i, 1) + "% : " + String.Format("{0:0.00}", ((i / 100) * EnteredValue)) + " : " + String.Format("{0:0.00}", ((i / 100) * EnteredValue) + EnteredValue),
                                BgColor = Color.FromHex("#d26260")
                            });
                        }
                        if(i >= 0)
                        {
                            PositiveCalculations.Add(new Calculation()
                            {
                                Data = Math.Round(i, 1) + "% : " + String.Format("{0:0.00}", ((i / 100) * EnteredValue)) + " : " + String.Format("{0:0.00}", ((i / 100) * EnteredValue) + EnteredValue),
                                BgColor = Color.FromHex("#00cca3")
                            });
                        }
                        shadeIndex++;
                    }

                    if(NegativeCalculations.Count == 0)
                    {
                        NegativeCalculations.Add(new Calculation() { Data = "Not applicable", BgColor = Color.White });
                    }
                    if(PositiveCalculations.Count == 0)
                    {
                        PositiveCalculations.Add(new Calculation() { Data = "Not applicable", BgColor = Color.White });
                    }

                    NegativeListView.ItemsSource = NegativeCalculations;
                    PositiveListView.ItemsSource = PositiveCalculations;
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