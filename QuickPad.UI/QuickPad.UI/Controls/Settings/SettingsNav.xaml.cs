﻿using QuickPad.UI.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using QuickPad.Mvvm.ViewModels;
using QuickPad.UI.Common.Theme;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace QuickPad.UI.Controls.Settings
{
    public sealed partial class SettingsNav : UserControl
    {
        public VisualThemeSelector VisualThemeSelector => VisualThemeSelector.Current;

        public SettingsNav()
        {
            this.InitializeComponent();

            SettingsFrame.Navigate(typeof(General), new SuppressNavigationTransitionInfo());
        }

        private void settingNavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var pageType = (args.InvokedItemContainer.Tag?.ToString()) switch
            {
                "General" => typeof(General),
                "Theme" => typeof(Theme),
                "Font" => typeof(Font),
                "Advanced" => typeof(Advanced),
                "About" => typeof(About),
                _ => null
            };

            if(pageType != null)
            {
                SettingsFrame.Navigate(pageType, new SuppressNavigationTransitionInfo());
            }
        }

        private void settingNavView_BackRequested(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs args)
        {
            General.IsSelected = true;
            App.Settings.ShowSettings = false;
        }
    }
}
