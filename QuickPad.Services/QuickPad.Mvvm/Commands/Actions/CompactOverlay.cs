﻿using System;
using System.Threading.Tasks;
using QuickPad.Mvvm.ViewModels;
using Windows.UI.ViewManagement;
using Windows.Foundation;

namespace QuickPad.Mvvm.Commands.Actions
{
    public class CompactOverlay : SimpleCommand<SettingsViewModel>
    {
        public CompactOverlay()
        {
            Executioner = async settings =>
            {
                //open settings page
                if (settings.CurrentMode == DisplayModes.LaunchCompactOverlay.ToString())
                {
                    settings.CurrentMode = settings.PreviousMode;
                    bool modeSwitched = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default);
                }
                else
                {
                    settings.CurrentMode = DisplayModes.LaunchCompactOverlay.ToString();
                    bool modeSwitched = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay);
                }
            };
        }
    }
}