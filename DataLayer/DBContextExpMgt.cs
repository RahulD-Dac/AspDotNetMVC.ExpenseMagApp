using ExpenseMangementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseMangementApp.DataLayer
{
    public class DBContextExpMgt : DbContext
    {
        public DBContextExpMgt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<ExpenseCategoryEntity> ExpenseCategorys { get; set;}

        public DbSet<UserProfile> UserProfile { get; set; }
    }
}
