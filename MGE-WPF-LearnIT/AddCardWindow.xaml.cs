using MGE_WPF_LearnIT.Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddCard.xaml
    /// </summary>
    public partial class AddCardWindow : Window
    {
        private CardSet set;
        private ViewModel vm = new ViewModel();

        public AddCardWindow(CardSet set) {
            this.set = set;
            InitializeComponent();
        }

        private void SaveCard_Click(object sender, RoutedEventArgs e) {
            Card newCard = new Card(Front.Text, Back.Text);
            set.addCard(newCard);
            vm.addCardToDb(newCard, set);
            this.Close();
        }

        private void CancelAddCard_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
