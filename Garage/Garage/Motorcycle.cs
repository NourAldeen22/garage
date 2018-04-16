namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string regnr, string wheels, string brand, string color) : base(regnr, wheels)
        {
            Brand = brand;
            Color = color;
        }

        public string Brand { get; private set; }
        public string Color { get; private set; }

        public override string ToString()
        {
            return $"This is a Motorcycle. " + base.ToString() + $" This Motorcycle is a {Brand} and is {Color}.";
        }
    }
}
