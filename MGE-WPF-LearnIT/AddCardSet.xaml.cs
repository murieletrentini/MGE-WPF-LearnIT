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
    /// Interaction logic for AddCardSet.xaml
    /// </summary>
    public partial class AddCardSet : Window
    {
        private ObservableCollection<CardSet> sets;
        private ViewModel vm = new ViewModel();
        public AddCardSet(ObservableCollection<CardSet> sets) {
            this.sets = sets;
            InitializeComponent();
        }

        private void SaveCardSet_Click(object sender, RoutedEventArgs e) {
            CardSet set = new CardSet(CardSetTitle.Text);
            sets.Add(set);
            vm.listenToNewSet(set);
            vm.addSetToDb(set);    
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
