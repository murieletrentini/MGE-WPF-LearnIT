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
        // ToDo: possibly move this plus adding removing CardSets/Cards ect to App.xaml.cs
        private ObservableCollection<CardSet> sets = new ObservableCollection<CardSet>();
        private CardSet currentSet;

        public MainWindow() {
            InitializeComponent();

            setUpCardSets();

            // Populate list
            displayAllCardSets();

            // Listens for Changes in CardSet-Collection
            sets.CollectionChanged += CardSetsChanged;
        }

        private void CardSetsChanged(object sender, NotifyCollectionChangedEventArgs e) {
            displayAllCardSets();
        }

        private void displayAllCardSets() {
            CardSetListView.Items.Clear();
            if (sets.Count == 0) {
                // ToDo: Find better way to do this!
                CardSetListView.Items.Add(new CardSet("No Sets to display"));
            } else {
                foreach (CardSet set in sets) {
                    CardSetListView.Items.Add(set);
                }
            }
        }

        private void setUpCardSets() {
           // ToDo: possibly change to Database Access
            sets.Add(new CardSet("Englisch Voci"));
            sets.Add(new CardSet("Franz Voci"));
            sets[0].addCard(new Card("FrontTest","BackTest"));     
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

        private void AddCard(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                CardSet currentSet = (CardSet)CardSetListView.SelectedItems[0];
                AddCard addCardWindow = new AddCard(currentSet);
                addCardWindow.Show();
            }
            
        }

        private void AddCardSet_Click(object sender, RoutedEventArgs e) {
            AddCardSet addCardSetWindow = new AddCardSet(sets);
            addCardSetWindow.Show();
        }
    }
}
