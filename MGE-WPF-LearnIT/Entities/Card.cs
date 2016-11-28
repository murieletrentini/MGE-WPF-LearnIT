using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.Entities
{
    public class Card
    {
        public String Front { get; set; }
        public String Back { get; set; }

        public Card(String front, String back) {
            Front = front;
            Back = back;
        }
    }
}
