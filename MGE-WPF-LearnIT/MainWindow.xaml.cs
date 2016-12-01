using MGE_WPF_LearnIT.Entities;
using System.Collections.Generic;
using System.Windows;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using MGE_WPF_LearnIT.domain;
using System.Linq;

namespace MGE_WPF_LearnIT
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {                                       
        private CardSet currentSet;
        private ViewModel vm;

        public MainWindow() {
            InitializeComponent();

            vm = new ViewModel(); 
            vm.setUpCardSets();
            using (var db = new Db()) {
                var cards = db.Cards.ToList();
            }

                CardSetListView.ItemsSource = vm.getSets();      
        }
                            

        private void displaySelectedCardSet(object sender, MouseButtonEventArgs e) {
            currentSet = (CardSet) CardSetListView.SelectedItems[0];
            CardListView.ItemsSource = currentSet.getCards();
            CardSetTitle.DataContext = currentSet; 
        }

        private void AddCardEvent(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                currentSet = (CardSet)CardSetListView.SelectedItems[0];
                AddCardWindow addCardWindow = new AddCardWindow(currentSet);
                addCardWindow.Show();
            }                  
        }

        private void AddCardSet_Click(object sender, RoutedEventArgs e) {
            AddCardSet addCardSetWindow = new AddCardSet(vm.getSets());
            addCardSetWindow.Show();
        }

        private void RemoveSetEvent(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                vm.getSets().Remove(currentSet);
                currentSet = null;      
                CardListView.ItemsSource = null;
            }
        }

        private void RemoveCardEvent(object sender, RoutedEventArgs e) {
            if (CardListView.SelectedItems.Count > 0) {
                currentSet.getCards().Remove((Card)CardListView.SelectedItems[0]);  
            }
        }

        private void StartPlayMode(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                PlayMode playMode = new PlayMode(currentSet);
                playMode.Show();
            }
        }
    }
}
