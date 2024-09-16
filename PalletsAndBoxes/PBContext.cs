using Microsoft.EntityFrameworkCore;
using PalletsAndBoxes.Models;

namespace PalletsAndBoxes
{
    public class PBContext : DbContext
    {
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Box> Boxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PalletsAndBoxesDB;Trusted_Connection=True;");
        }
    }
}
