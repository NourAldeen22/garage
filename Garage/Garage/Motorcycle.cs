namespace Garage
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string regnr, int wheels, string type, string color) : base(regnr, wheels)
        {
            Type = type;
            Color = color;
        }

        public string Type { get; private set; }
        public string Color { get; private set; }

        public override string ToString()
        {
            return $"This is a Motorcycle. " + base.ToString() + $" This Motorcycle is a {Type} and is {Color}.";
        }
    }
}
