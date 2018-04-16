namespace Garage
{
    public class Bus : Vehicle
    {
        public Bus(string regnr, string wheels, string fuelType, string nrOfSeats) : base(regnr, wheels)
        {
            FuelType = fuelType;
            NrOfSeats = nrOfSeats;
        }

        public string FuelType { get; private set; }
        public string NrOfSeats { get; private set; }

        public override string ToString()
        {
            return $"This is a Bus. " + base.ToString() + $" This Bus runs on {FuelType} and has {NrOfSeats} seats.";
        }
    }
}
