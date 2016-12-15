﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
   public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
         protected bool SetProperty<T>(ref T field, T value, string name = null) {
                if (Equals(field, value)) return false;
                field = value;
                OnPropertyChanged(name);
                return true;
            }
            protected void OnPropertyChanged(string name = null) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
    }
}
