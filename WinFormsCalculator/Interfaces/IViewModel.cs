﻿using System.ComponentModel;

namespace WinFormsCalculator.Interfaces
{
    /// <summary>
    /// Interface enforces base requirements of all 'ViewModel' types.
    /// </summary>
    public interface IViewModel
    {
        // Should raise property changed events upon internal properties updating.
        void OnPropertyChanged(PropertyChangedEventArgs e);
    }
}