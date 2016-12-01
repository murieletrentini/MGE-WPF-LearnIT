using MGE_WPF_LearnIT.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGE_WPF_LearnIT.domain {
    class Db : DbContext {
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardSet> CardSets { get; set; }
    }
}
