using MGE_WPF_LearnIT.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MGE_WPF_LearnIT
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private List<CardSet> setList = new List<CardSet>();
        public void addSet(CardSet set) {
            setList.Add(set);
        }
        public List<CardSet> getSetList() {
            return setList;
        }
    }
}
