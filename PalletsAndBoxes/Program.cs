using Microsoft.EntityFrameworkCore;
using PalletsAndBoxes;

using var db = new PBContext();

//var gen = new Generator(db);
//return gen.Generate(10, 5, 20);

Console.WriteLine("//////////// Grouped //////////////\n\n\n");

var groups = from p in db.Pallets.Include(p => p.Boxes).ToList()
             orderby p.GetExpireDate()
             group p by p.GetExpireDate();

int num = 0;
foreach (var g in groups)
{
    var tmp = g.OrderBy(p => p.Weight);
    Console.WriteLine($"<Group{num}>");
    foreach (var p in tmp) Console.WriteLine(p);
    Console.WriteLine($"<Group{num}/>\n");
    num++;
}

Console.WriteLine("\n\n\n//////////// Top3 //////////////\n\n\n");


var topPallets = (from b in db.Boxes.Include(b => b.Pallet).ToList()
            orderby b.GetExpireDate() descending
                group b by b.PalletId into bg select bg.First().Pallet).Take(3);

foreach (var p in topPallets.OrderBy(p => p.GetVolume())) Console.WriteLine(p);