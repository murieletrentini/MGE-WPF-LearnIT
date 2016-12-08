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
    
    public partial class AddCardSet : Window
    {
        private ObservableCollection<CardSet> sets;
        private ViewModel vm = ((MainWindow)Application.Current.MainWindow).Vm;
        public AddCardSet() {
            this.sets = vm.Sets;
            InitializeComponent();  
        }

        private void SaveCardSet_Click(object sender, RoutedEventArgs e) {
            CardSet set = new CardSet(CardSetTitle.Text);
            vm.addSet(set);    
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
