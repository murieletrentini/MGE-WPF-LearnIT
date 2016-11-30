using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
            cards.CollectionChanged += cardsChanged;
        }

        private void cardsChanged(object sender, NotifyCollectionChangedEventArgs e) {
            OnPropertyChanged(nameof(cardAmount));
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

        private int cardAmount;
        public int CardAmount {
            get
            {
                cardAmount = cards.Count;
                return cardAmount;
            }     
        }

        public int AmountCorrectCards {
            get {
                int counter = 0;
               foreach (Card card in cards) {
                    if (card.IsCorrect) { counter++; }
                }
                return counter;
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
