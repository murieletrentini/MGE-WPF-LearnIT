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
    public partial class MainWindow : Window {     
        public ViewModel Vm { get; set; }

        public MainWindow() {
            InitializeComponent();

            Vm = new ViewModel(); 
            Vm.setUpCardSets();
            DataContext = this;  
        }
               
        private void AddCardEvent(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                Vm.CurrentSet = (CardSet)CardSetListView.SelectedItems[0];  
                AddCardWindow addCardWindow = new AddCardWindow(Vm.CurrentSet);
                addCardWindow.Show();
            }                  
        }                    

        private void AddCardSet_Click(object sender, RoutedEventArgs e) {
            AddCardSet addCardSetWindow = new AddCardSet(Vm.getSets());
            addCardSetWindow.Show();
        }

        private void RemoveSetEvent(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                CardSet setToRemove = Vm.CurrentSet;
                Vm.Sets.Remove(setToRemove);
                Vm.removeSetFromDb(setToRemove);
             /*   Vm.CurrentSet = null;      
                CardListView.ItemsSource = null;
                CardSetTitle.Text = "No title to display";      */
            }
        }

        private void RemoveCardEvent(object sender, RoutedEventArgs e) {
            if (CardListView.SelectedItems.Count > 0) {
                Card card = (Card)CardListView.SelectedItems[0];
                Vm.CurrentSet.Cards.Remove(card);
                Vm.RemoveCardFromDb(card);  
            }
        }

        private void StartPlayMode(object sender, RoutedEventArgs e) {
            if (CardSetListView.SelectedItems.Count > 0) {
                PlayMode playMode = new PlayMode(Vm.CurrentSet);
                playMode.Show();
            }
        }
    }
}
