using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
    public class CardSet
    {
        private List<Card> cards = new List<Card>();
        public CardSet(String name) {
            this.Name = name;
        }
        public List<Card> getCards() {
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
