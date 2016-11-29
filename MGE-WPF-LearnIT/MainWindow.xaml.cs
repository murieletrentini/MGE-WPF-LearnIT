using MGE_WPF_LearnIT.Entities;
using System.Collections.Generic;
using System.Windows;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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

            DataContext = vm;

            // Populate list
            displayAllCardSets();

            // Listens for Changes in CardSet-Collection
            vm.getSets().CollectionChanged += CardSetsChanged;
        }

        private void CardSetsChanged(object sender, NotifyCollectionChangedEventArgs e) {
            displayAllCardSets();
        }

        private void displayAllCardSets() {
            CardSetListView.Items.Clear();
            if (vm.getSets().Count == 0) {
                // ToDo: Find better way to do this!
                CardSetListView.Items.Add(new CardSet("No Sets to display"));
            } else {
                foreach (CardSet set in vm.getSets()) {
                    CardSetListView.Items.Add(set);
                }
            }
        }

        

        private void displaySelectedCardSet(object sender, MouseButtonEventArgs e) {
            currentSet = (CardSet) CardSetListView.SelectedItems[0];
            CardListView.Items.Clear();
            if (currentSet.getCards().Count == 0) {
                // ToDo: Find better way to do this!
                CardListView.Items.Add(new Card("No Cards to display", ""));
            } else {
                foreach (Card card in currentSet.getCards()) {
                    CardListView.Items.Add(card);
                }
            }
        }

        private void AddCardEvent(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                CardSet currentSet = (CardSet)CardSetListView.SelectedItems[0];
                AddCardWindow addCardWindow = new AddCardWindow(currentSet);
                addCardWindow.Show();
            }
            
        }

        private void AddCardSet_Click(object sender, RoutedEventArgs e) {
            AddCardSet addCardSetWindow = new AddCardSet(vm.getSets());
            addCardSetWindow.Show();
        }
    }
}
