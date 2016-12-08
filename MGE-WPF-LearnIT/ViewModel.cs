using MGE_WPF_LearnIT.domain;
using MGE_WPF_LearnIT.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT
{
    public class ViewModel
    {
        public ViewModel() {
            this.sets.CollectionChanged += (o, a) => {
                Console.WriteLine(  "changed");
            };
        }
        private ObservableCollection<CardSet> sets = new ObservableCollection<CardSet>();
        public ObservableCollection<CardSet> Sets { get; set; }

        public void setUpCardSets() {
            using (var db = new Db()) {
                var setsfromdb = from s in db.CardSets
                                 select s;
                foreach (CardSet set in setsfromdb) {
                    sets.Add(set);
                    var cardsFromDb = from c in db.Cards
                                      where c.CardSetId == set.CardSetId
                                      select c;
                    foreach (Card card in cardsFromDb) {
                        set.addCard(card);
                    }
                }
            }                                         
        }
       public ObservableCollection<CardSet> getSets () {
            return sets;
        }

        public void addSetToDb(CardSet set) {
            using (var db = new Db()) {
                db.CardSets.Add(set);
                db.SaveChanges();
            }
        }

        public void removeSetFromDb(CardSet set) {
            using (var db = new Db()) {
                var setToDelete = db.CardSets.First(s => s.CardSetId == set.CardSetId);

                ((IObjectContextAdapter)db).ObjectContext.DeleteObject(setToDelete);
                   
                db.SaveChanges();
            } 
        }

        public void addCardToDb(Card card, CardSet set) {
            using (var db = new Db()) {
                card.CardSetId = set.CardSetId;
                db.Cards.Add(card);
                db.SaveChanges();
            }
        }

        public void RemoveCardFromDb(Card card) {
            using (var db = new Db()) {
                var cardToDelete = db.Cards.First(c => c.CardId == card.CardId);
                ((IObjectContextAdapter)db).ObjectContext.DeleteObject(cardToDelete); 
                db.SaveChanges();
            }
        }


        public void updateCard(Card card) {
            using (var db = new Db()) {    
                if (card.CardId != 0) {
                    db.Entry(card).State = EntityState.Modified;
                    db.SaveChanges();
                }     
            }
        }
        public void updateSet(CardSet set) {
            using (var db = new Db()) { 
                if (set.CardSetId != 0) {
                    db.Entry(set).State = EntityState.Modified;
                    db.SaveChanges();
                }      
            }
        }
    }
}
