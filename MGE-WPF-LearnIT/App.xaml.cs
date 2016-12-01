using MGE_WPF_LearnIT.domain;
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
            using (var db = new Db()) {
                db.CardSets.Add(set);
                db.SaveChanges();
            }
        }
        public List<CardSet> getSetList() {
            return setList;
        }
    }
}
