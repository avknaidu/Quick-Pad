﻿using Windows.UI.Xaml.Controls;
using QuickPad.Mvvm.ViewModels;
using QuickPad.UI.Common;
using System.ComponentModel;
using System.Reflection.Metadata;
using QuickPad.UI.Common.Theme;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace QuickPad.UI.Controls
{
    public sealed partial class StatusBar : UserControl
    {
        public VisualThemeSelector VisualThemeSelector => VisualThemeSelector.Current;

        public SettingsViewModel Settings => App.Settings;

        public DocumentViewModel ViewModel
        {
            get => DataContext as DocumentViewModel;
            set
            {
                if (value == null || DataContext == value) return;

                if (DataContext is DocumentViewModel documentViewModel)
                {
                    documentViewModel.PropertyChanged -= DocumentViewModelOnPropertyChanged;
                }

                DataContext = value;

                value.PropertyChanged += DocumentViewModelOnPropertyChanged;
            }
        }

        private void DocumentViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(DocumentViewModel.CurrentLine):
                case nameof(DocumentViewModel.CurrentColumn):
                    Bindings.Update();
                    break;
            }
        }

        public StatusBar()
        {
            this.InitializeComponent();

            Settings.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(SettingsViewModel.StatusText):
                    Bindings.Update();
                    break;
            }
        }
    }
}
