namespace Garage
{
    public class Car : Vehicle
    {
        public Car(string regnr, int wheels, string fuelType, bool isSportCar) : base(regnr, wheels)
        {
            FuelType = fuelType;
            IsSportCar = isSportCar;
        }

        public string FuelType { get; private set; }
        public bool IsSportCar { get; private set; }

        public override string ToString()
        {
            return $"This is a Car. " + base.ToString() + $" This Car runs on {FuelType} and is a {(IsSportCar ? "sport" : "family")} car.";
        }
    }
}
