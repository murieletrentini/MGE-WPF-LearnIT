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
        private int counter = -1;

        public PlayMode(CardSet set) {
            cards = set.getCards();
            Set = set;
            setCurrentCard();

            DataContext = this;

            InitializeComponent();
        }

        private void setCurrentCard() {
            if (counter < Set.getCards().Count - 1) {
                CurrentCard = cards[++counter];
            } else {
                PlayModeCard.Text = "You're Done!!";
                DidKnowBtn.Visibility = Visibility.Hidden;
                DidntKnowBtn.Visibility = Visibility.Hidden;
                CloseBtn.Visibility = Visibility.Visible;
            }  
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    

        private void NextCard_Click(object sender, RoutedEventArgs e) {
                if (((IconTextButton)sender).Name == "DidKnowBtn") {
                    CurrentCard.IsCorrect = true;
                } else {     
                    CurrentCard.IsCorrect = false;
                }
                setCurrentCard();
            }       
        }
}
