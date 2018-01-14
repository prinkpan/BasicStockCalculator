using BasicStockCalculator.Model;
using BasicStockCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

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
            PerformCalculation(e.NewTextValue);
        }

        void OnSettingsClicked(object sender, EventArgs e)
        {
            var settings = new SettingsPage();
            MessagingCenter.Unsubscribe<SettingsPage>(settings, "SettingChanged");
            MessagingCenter.Subscribe<SettingsPage>(settings, "SettingChanged", (s) =>
            {
                PerformCalculation(stockAmount.Text);
            });
            this.Navigation.PushAsync(settings);
        }

        void PerformCalculation(string value)
        {
            try
            {
                BSCSettingsVM bscSettings = new BSCSettingsVM();
                var MaxRange = bscSettings.MaxRange;

                PercentageCalculations.Clear();
                if (value.Length > 0)
                {
                    EnteredValue = Convert.ToDouble(value);
                    for (int i = 1; i <= MaxRange; i++)
                    {
                        var percent = (i / 100.00) * EnteredValue;
                        var positive = EnteredValue + percent;
                        var negative = EnteredValue - percent;

                        PercentageCalculations.Add(new Calculation()
                        {
                            Percentage = i + "%",
                            PercentVal = String.Format("{0:0.00}", percent),
                            Positive = String.Format("{0:0.00}", positive),
                            Negative = String.Format("{0:0.00}", negative)
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

        //protected override async void OnAppearing()
        //{
        //    try
        //    {
        //        base.OnAppearing();
        //        // Waiting some time
        //        await Task.Delay(2000);

        //        // Start animation
        //        await Task.WhenAll(
        //            Logo.ScaleTo(10, 2000)
                    
        //            );
        //    }
        //    catch(Exception e)
        //    {
        //        //Handle error
        //    }
        //}
    }
}