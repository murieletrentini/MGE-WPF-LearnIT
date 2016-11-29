using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
    public class CardSet : INotifyPropertyChanged
    {
        private ObservableCollection<Card> cards = new ObservableCollection<Card>();

        public CardSet(String name) {
            Name = name;
        }
        public ObservableCollection<Card> getCards() {
            return cards;
        }
        public void addCard(Card card) {
            cards.Add(card);
        }
        private String name;
        public String Name {
            get { return name; }
            set {
                if (value != name) {
                    name = value;
                    OnPropertyChanged(nameof(name));
                    
                }
            }
        }

        public int CardAmount {
            get
            {
                return cards.Count;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String name) {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
