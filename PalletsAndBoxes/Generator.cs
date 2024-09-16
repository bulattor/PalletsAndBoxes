using Microsoft.EntityFrameworkCore;
using PalletsAndBoxes.Models;

namespace PalletsAndBoxes
{
    public class Generator
    {
        public DbContext context { get; set; }
        public Generator(DbContext context) { this.context = context; }
        public int Generate(int p, int minb, int maxb)
        {
            Random rnd = new Random();
            DateTime minDate = DateTime.Now.AddDays(-90);
            using var db = context;
            for (int i = 0; i < p; i++)
            {
                Pallet pallet = new Pallet
                {
                    Depth = Math.Round(rnd.NextDouble() * 2.5 + 0.5, 1),
                    Height = Math.Round(rnd.NextDouble() * 0.2 + 0.1, 1),
                    Width = Math.Round(rnd.NextDouble() * 1.5 + 0.5, 1),
                };
                for (int j = 0; j < rnd.Next(minb, maxb); j++)
                {
                    pallet.Boxes.Add(new Box
                    {
                        Depth = Math.Round(rnd.NextDouble() * (pallet.Depth - 0.1) + 0.1, 1, mode:MidpointRounding.ToZero),
                        Width = Math.Round(rnd.NextDouble() * (pallet.Width - 0.1) + 0.1, 1, mode:MidpointRounding.ToZero),
                        Height = Math.Round(rnd.NextDouble() * 0.9 + 0.1, 1),
                        ProductionDate = DateOnly.FromDateTime(minDate.AddDays(rnd.Next(0, 90))),
                        Weight = Math.Round(rnd.NextDouble() * 29.9 + 0.1, 1),
                    });
                }
                try
                {
                    db.Add(pallet);
                    db.SaveChanges();
                } catch { return -1; }
            }
            return 0;
        }
    }
}
