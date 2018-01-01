using BasicStockCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicStockCalculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
            InitializeComponent ();
            BindingContext = new BSCSettingsVM();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var StepValue = 1.0;
            var newStep = Math.Round(e.NewValue / StepValue);
            settingSlider.Value = newStep * StepValue;
        }
    }
}