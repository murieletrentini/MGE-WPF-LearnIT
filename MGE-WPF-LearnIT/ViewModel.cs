using MGE_WPF_LearnIT.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT
{
    class ViewModel
    {
        private ObservableCollection<CardSet> sets = new ObservableCollection<CardSet>();

        public void setUpCardSets() {
            // ToDo: possibly change to Database Access
            sets.Add(new CardSet("Englisch Voci"));
            sets.Add(new CardSet("Franz Voci"));
            sets[0].addCard(new Card("FrontTest", "BackTest"));
        }
       public ObservableCollection<CardSet> getSets () {
            return sets;
        }


    }
}
