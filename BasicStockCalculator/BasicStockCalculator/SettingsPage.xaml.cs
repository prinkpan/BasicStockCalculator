﻿using BasicStockCalculator.ViewModel;
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

        protected override void OnDisappearing()
        {
            MessagingCenter.Send<SettingsPage>(this, "SettingChanged");
            base.OnDisappearing();
        }
    }
}