namespace Garage
{
    public class Vehicle
    {
        private string regnr;

        public Vehicle(string regnr, int wheels)
        {
            Regnr = regnr;
            Wheels = wheels;
        }

        public string Regnr
        {
            get => regnr;
            private set { regnr = value; }
        }

        public int Wheels { get; private set; }

        public override string ToString()
        {
            return $"{regnr} has {Wheels} wheels.";
        }
    }
}