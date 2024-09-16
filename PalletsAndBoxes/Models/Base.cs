namespace PalletsAndBoxes.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public abstract double Weight { get; set; }
        public abstract DateOnly GetExpireDate();
        public abstract double GetVolume();
    }
}
