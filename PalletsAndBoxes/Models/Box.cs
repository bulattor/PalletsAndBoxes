using System;
using System.Collections.Generic;
using System.Linq;
namespace PalletsAndBoxes.Models
{
    public class Box : Base
    {
        public DateOnly ProductionDate { get; set; }
        public int PalletId { get; set; }
        public Pallet Pallet { get; set; }
        public override double Weight { get; set; }

        public override DateOnly GetExpireDate() => ProductionDate.AddDays(100);
        public override double GetVolume() => Width * Height * Depth;
        public override string ToString() => $"Box_{Id}({Weight} kg, {Math.Round(GetVolume(), 2)} m^3): w={Width}, d={Depth}, h={Height}, expAt={GetExpireDate()}";
    }
}
