using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
    public class CardSet
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
        public String Name { get; set; }

        public int CardAmount {
            get
            {
                return cards.Count;
            }
        }
    }
}
