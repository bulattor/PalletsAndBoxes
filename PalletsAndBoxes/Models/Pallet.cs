using System.ComponentModel.DataAnnotations.Schema;

namespace PalletsAndBoxes.Models
{
    public class Pallet : Base
    {
        public List<Box> Boxes { get; } = new();
        [NotMapped]
        public override double Weight { get => 30 + Boxes.Sum(b => b.Weight); set { } }
        public override double GetVolume() => Width * Height * Depth + Boxes.Sum(b => b.GetVolume());
        public override DateOnly GetExpireDate() => Boxes.Select(d => d.GetExpireDate()).Min();
        public override string ToString()
        {
            string s = $"Pallet_{Id}({Math.Round(Weight, 1)} kg, {Math.Round(GetVolume(), 2)} m^3): w={Width}, d={Depth}, h={Height}, expireAt={GetExpireDate()}\n";
            foreach (Box b in Boxes.OrderBy(b => b.GetExpireDate())) s += $"\t{b}\n";
            return s;
        }
    }
}
