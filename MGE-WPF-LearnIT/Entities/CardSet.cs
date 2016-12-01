using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
    [Table("cardsets")]
    public class CardSet : INotifyPropertyChanged
    {
        [NotMapped]
        private ObservableCollection<Card> cards = new ObservableCollection<Card>();

        public CardSet(String name) {
            Name = name;
            cards.CollectionChanged += cardsChanged;
        }

        public CardSet() { }

        private void cardsChanged(object sender, NotifyCollectionChangedEventArgs e) {
            OnPropertyChanged(nameof(cardAmount));
        }
        public ObservableCollection<Card> getCards() {
            return cards;
        }
        public void addCard(Card card) {
            cards.Add(card);
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int CardSetId { get; set; }

        private String name;
        [Column("name")]
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
        [NotMapped]
        public int CardAmount {
            get
            {
                cardAmount = cards.Count;
                return cardAmount;
            }     
        }
        [NotMapped]
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

        public virtual List<Card> Cards { set; get; }
    }
}
