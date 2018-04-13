namespace Garage
{
    public class Airplane : Vehicle
    {
        public Airplane(string regnr, int wheels, string fuelType, int nrOfSeats) : base(regnr, wheels)
        {
            FuelType = fuelType;
            NrofSeats = nrOfSeats;
        }

        public string FuelType { get; private set; }
        public int NrofSeats { get; private set; }

        public override string ToString()
        {
            return $"This is an Airplane. " + base.ToString() + $" This plane runs on {FuelType} and has {NrofSeats} seats.";
        }
    }
}