using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
    [Table("cards")]
    public class Card : INotifyPropertyChanged
    {
        public Card(String front, String back) {
            Front = front;
            Back = back;
        }

        public Card() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int CardId { get; set; }

        
        private String front;
        [Column("front")]
        public String Front {
            get { return front; }
            set {
                if (value != front) {
                    front = value;
                    OnPropertyChanged(nameof(front));
                }
            }
        }

        private String back;
        [Column("back")]
        public String Back {
            get { return back; }
            set {
                if (value != back) {
                    back = value;
                    OnPropertyChanged(nameof(back));
                }
            }
        }

        [Column("isCorrect")]
        public bool IsCorrect { get; set; }

        public int CardSetId { get; set; }

        [ForeignKey(nameof(CardSetId))]
        public virtual CardSet CardSet { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String name) { 
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name)); 
        }
    }
}
