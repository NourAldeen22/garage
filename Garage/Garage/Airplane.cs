namespace Garage
{
    public class Airplane : Vehicle
    {
        public Airplane(string regnr, string wheels, string fuelType, string nrOfSeats) : base(regnr, wheels)
        {
            FuelType = fuelType;
            NrOfSeats = nrOfSeats;
        }

        public string FuelType { get; private set; }
        public string NrOfSeats { get; private set; }

        public override string ToString()
        {
            return $"This is an Airplane. " + base.ToString() + $" This plane runs on {FuelType} and has {NrOfSeats} seats.";
        }
    }
}