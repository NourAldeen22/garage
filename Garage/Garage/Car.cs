namespace Garage
{
    public enum CarTypes
    {
        Sport,
        Family
    }

    public class Car : Vehicle
    {
        public Car(string regnr, string wheels, string fuelType, string carType) : base(regnr, wheels)
        {
            FuelType = fuelType;
            CarType = carType;
        }

        public string FuelType { get; private set; }
        public string CarType { get; private set; }

        public override string ToString()
        {
            return $"This is a Car. " + base.ToString() + $" This Car runs on {FuelType} and is a {CarType.ToLower()} car.";
        }
    }
}
