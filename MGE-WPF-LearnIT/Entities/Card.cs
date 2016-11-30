using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
    public class Card : INotifyPropertyChanged
    {
        public Card(String front, String back) {
            Front = front;
            Back = back;
        }

        private String front;
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
        public String Back {
            get { return back; }
            set {
                if (value != back) {
                    back = value;
                    OnPropertyChanged(nameof(back));
                }
            }
        }

        public bool IsCorrect { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String name) {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
