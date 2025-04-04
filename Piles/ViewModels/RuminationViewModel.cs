﻿using Piles.Models;

namespace Piles.ViewModels
{
    public class RuminationViewModel : ViewModelBase
    {
        private readonly Rumination _rumination;

        public string Description => _rumination.Description;

        private bool _isChecked = false;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                OnPropertyChanged();
            }
        }

        public RuminationViewModel(Rumination rumination)
        {
            _rumination = rumination;
        }

        public void CheckRumination()
        {
            IsChecked = true;
        }

        public void UncheckRumination()
        {
            IsChecked = false;
        }
    }
}
