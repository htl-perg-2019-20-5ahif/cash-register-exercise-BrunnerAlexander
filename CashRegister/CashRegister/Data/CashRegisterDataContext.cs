using CashRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashRegister.Data
{
    public class CashRegisterDataContext : DbContext
    {
        public CashRegisterDataContext(DbContextOptions<CashRegisterDataContext> options) : base(options)
        { }

        public DbSet<Product> Products;
        public DbSet<ReceiptLine> ReceiptLines;
        public DbSet<Receipt> Receipts;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Price).IsRequired();
                e.HasData(
                    new Product{ Id = 1, Name = "Bananen 1kg",Price = 1.99M },
                    new Product{ Id = 2, Name = "Äpfel 1kg", Price = 2.99M },
                    new Product{ Id = 3, Name = "Trauben Weiß 500g", Price = 2.49M },
                    new Product{ Id = 4, Name = "Himbeeren 125g", Price = 1.89M },
                    new Product{ Id = 5, Name = "Karotten 500g", Price = 1.19M },
                    new Product{ Id = 6, Name = "Eissalat 1 Stück", Price = 0.99M },
                    new Product{ Id = 7, Name = "Zucchini 1 Stück", Price = 0.99M },
                    new Product{ Id = 8, Name = "Knoblauch 150g", Price = 2.49M },
                    new Product{ Id = 9, Name = "Joghurt 200g", Price = 0.49M },
                    new Product{ Id = 10, Name = "Butter", Price = 2.59M }
                );
            });

            modelBuilder.Entity<ReceiptLine>(e =>
            {
                e.Property(rl => rl.Amount).IsRequired();
                e.Property(rl => rl.TotalPrice).IsRequired();
            });

            modelBuilder.Entity<Receipt>(e =>
            {
                e.Property(r => r.Timestamp).IsRequired();
                e.Property(r => r.TotalPrice).IsRequired();
            });
        }

        public DbSet<CashRegister.Models.Product> Product { get; set; }

        public DbSet<CashRegister.Models.Receipt> Receipt { get; set; }

    }
}
