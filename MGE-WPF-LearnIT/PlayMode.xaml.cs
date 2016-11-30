using MGE_WPF_LearnIT.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MGE_WPF_LearnIT
{
    /// <summary>
    /// Interaction logic for PlayMode.xaml
    /// </summary>
    public partial class PlayMode : Window
    {
        private ObservableCollection<Card> cards;
        private CardSet Set { get; set; }
        private Card CurrentCard { get; set; }
        private int counter = 0;
        
        public PlayMode(CardSet set) {
            cards = set.getCards();
            Set = set;
            setCurrentCard();

            DataContext = this;

            InitializeComponent();
        }

        private void setCurrentCard() {
            CurrentCard = cards[counter];
        }

        private void KnewIt_Click(object sender, RoutedEventArgs e) {
           
        }

        private void DidntKnow_Click(object sender, RoutedEventArgs e) {
           
        }
    }
}
