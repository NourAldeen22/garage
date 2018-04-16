namespace Garage
{
    public class Vehicle
    {
        private string regnr;

        public Vehicle(string regnr, string nrOfWheels)
        {
            Regnr = regnr;
            NrOfWheels = nrOfWheels;
        }

        public string Regnr
        {
            get => regnr;
            private set { regnr = value; }
        }

        public string NrOfWheels { get; private set; }

        public override string ToString()
        {
            return $"{regnr} has {NrOfWheels} wheels.";
        }
    }
}