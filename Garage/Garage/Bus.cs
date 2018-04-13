namespace Garage
{
    public class Bus : Vehicle
    {
        public Bus(string regnr, int wheels, string fuelType, int nrOfSeats) : base(regnr, wheels)
        {
            FuelType = fuelType;
            NrofSeats = nrOfSeats;
        }

        public string FuelType { get; private set; }
        public int NrofSeats { get; private set; }

        public override string ToString()
        {
            return $"This is a Bus. " + base.ToString() + $" This Bus runs on {FuelType} and has {NrofSeats} seats.";
        }
    }
}
