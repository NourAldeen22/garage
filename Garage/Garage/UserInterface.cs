using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class UserInterface
    {
        private GarageHandler valet = new GarageHandler();

        public void MainMenu()
        {
            bool KeepRunning = true;

            Console.Clear();
            while (KeepRunning)
            {
                Console.WriteLine("Enter number for choice.");
                Console.WriteLine("1) Park.");
                Console.WriteLine("2) UnPark.");
                if (!valet.GarageExist)
                    Console.WriteLine("3) Build new Garage.");
                else
                    Console.WriteLine("3) Raze Garage.");
                Console.WriteLine("4) List All parked.");
                Console.WriteLine("5) List All Vehicle Types Parked.");
                Console.WriteLine("6) List All Parked Vehicle With Property.");
                Console.WriteLine("0) Quit.");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Park();
                        break;

                    case "2":
                        UnPark();
                        break;

                    case "3":
                        BuildRazeGarage();
                        break;

                    case "4":
                        ListAll();
                        break;

                    case "5":
                        ListAllTypes();
                        break;

                    case "6":
                        ListAllWithProperty();
                        break;

                    case "0":
                        KeepRunning = false;
                        break;

                    case "TEST":
                        if (valet.GarageExist)
                            valet.RazeGarage();
                        valet.BuildGarage(15);
                        valet.Park(new Boat("boat1", "0", "13", "55"));
                        valet.Park(new Car("car1", "4", "Gas", CarTypes.Sport.ToString()));
                        valet.Park(new Airplane("ap1", "3", "Kerosene", "250"));
                        valet.Park(new Car("car2", "5", "Disel", CarTypes.Family.ToString()));
                        valet.Park(new Car("car3", "4", "Gas", CarTypes.Sport.ToString()));
                        valet.Park(new Bus("bus1", "6", "Biodisel", "40"));
                        valet.Park(new Motorcycle("bike1", "2", "HD", "Black"));
                        valet.Park(new Motorcycle("bike2", "3", "Kawasaki 125", "Pink"));
                        valet.Park(new Boat("boat2", "0", "5", "600"));
                        valet.Park(new Airplane("ap2", "3", "Crude oil", "4"));
                        valet.Park(new Car("car4", "4", "Gas", CarTypes.Family.ToString()));
                        valet.Park(new Car("car5", "4", "Ethanol", CarTypes.Family.ToString()));
                        valet.Park(new Car("car6", "4", "Disel", CarTypes.Family.ToString()));
                        Console.Clear();
                        Console.WriteLine("Cheater!!!");
                        Console.WriteLine();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void ListAllWithProperty()
        {
            Console.Clear();
            if (!valet.GarageExist)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }

            Console.WriteLine("What type of vehicle are you searching for?");
            Console.WriteLine("1) Airplane");
            Console.WriteLine("2) Boat");
            Console.WriteLine("3) Bus");
            Console.WriteLine("4) Car");
            Console.WriteLine("5) Motorcycle");
            Console.WriteLine("6) Any type");
            var vehicleType = Console.ReadLine();
            Console.WriteLine();
            VehicleTypes vtVehicleType;

            Console.WriteLine("What property are you searching for?");
            Console.WriteLine("1) Registration number");
            Console.WriteLine("2) Number of wheels");
            switch (vehicleType)
            {
                case "1":
                    Console.WriteLine("3) Type of fuel");
                    Console.WriteLine("4) Number of seats");
                    Console.WriteLine("5) All airplanes");
                    vtVehicleType = VehicleTypes.Airplane;
                    break;
                case "2":
                    Console.WriteLine("3) Length");
                    Console.WriteLine("4) Cylinder volume");
                    Console.WriteLine("5) All boats");
                    vtVehicleType = VehicleTypes.Boat;
                    break;
                case "3":
                    Console.WriteLine("3) Type of fuel");
                    Console.WriteLine("4) Number of seats");
                    Console.WriteLine("5) All buses");
                    vtVehicleType = VehicleTypes.Bus;
                    break;
                case "4":
                    Console.WriteLine("3) Type of fuel");
                    Console.WriteLine("4) If it's a sports car");
                    Console.WriteLine("5) All cars");
                    vtVehicleType = VehicleTypes.Car;
                    break;
                case "5":
                    Console.WriteLine("3) Type of bike");
                    Console.WriteLine("4) Color of bike");
                    Console.WriteLine("5) All bikes");
                    vtVehicleType = VehicleTypes.Motorcycle;
                    break;
                case "6":
                    vtVehicleType = VehicleTypes.Vehicle;
                    // All vehicles, have no extra properties to search for
                    break;
                default:
                    Console.WriteLine("No valid vehicle search selected. Back to main you go.");
                    Console.WriteLine();
                    return;
            }
            var propertySelected = Console.ReadLine();
            Console.WriteLine();

            Properties ppProperty;
            string propertyValue = null;
            switch (vehicleType + propertySelected)
            {
                case "11": // airplane + regnr
                case "21": // boat + regnr
                case "31": // bus + regnr
                case "41": // car + regnr
                case "51": // bike + regnr
                case "61": // ALL + regnr
                    Console.Write("Enter registration number:");
                    ppProperty = Properties.RegNr;
                    break;

                case "12": // airplane + nr of wheels
                case "22": // boat + nr of wheels
                case "32": // bus + nr of wheels
                case "42": // car + nr of wheels
                case "52": // bike + nr of wheels
                case "62": // all + nr of wheels
                    Console.Write("Enter number of wheels:");
                    ppProperty = Properties.NrOfWheels;
                    break;

                case "13": // airplane + type of fuel
                case "33": // bus + type of fuel
                case "43": // car + type of fuel
                    Console.Write("Type of fuel:");
                    ppProperty = Properties.FuelType;
                    break;

                case "14": // airplane + seats
                case "34": // bus + seats
                    Console.Write("Number of seats:");
                    ppProperty = Properties.NrOfSeats;
                    break;

                case "23": // boat + length
                    Console.Write("Length of boat:");
                    ppProperty = Properties.Length;
                    break;

                case "24": // boat + cylinder volume
                    Console.Write("cc of cylinder volume:");
                    ppProperty = Properties.CylinderVolume;
                    break;

                case "44": // car + is sports car
                    Console.Write("What type of car is it (Sport/Family):");
                    ppProperty = Properties.CarType;
                    break;

                case "53": // bike + type
                    Console.Write("Type of bike:");
                    ppProperty = Properties.Brand;
                    break;

                case "54": // bike + color
                    Console.Write("Color of bike:");
                    ppProperty = Properties.Color;
                    break;

                case "15": // all airplanes
                case "25": // all boats
                case "35": // all buses
                case "45": // all cars
                case "55": // all bikes
                    ppProperty = Properties.Any;
                    break;

                default:
                    Console.WriteLine("Not a valid entry. Back to main you go.");
                    Console.WriteLine();
                    return;
            }

            if (vtVehicleType == VehicleTypes.Car && ppProperty == Properties.CarType)
            {
                var carType = Console.ReadLine();
                if (carType.ToLower() == CarTypes.Sport.ToString().ToLower())
                    propertyValue = CarTypes.Sport.ToString();
                else if (carType.ToLower() == CarTypes.Family.ToString().ToLower())
                    propertyValue = CarTypes.Family.ToString();
                else
                {
                    ErrorMessage("We do not accept funny answers. Back to main you go.");
                    return;
                }
                Console.WriteLine();
            }
            else if (ppProperty != Properties.Any)
            {
                propertyValue = Console.ReadLine();
                Console.WriteLine();
            }

            Console.WriteLine(valet.ListAllVehiclesWithProperty(vtVehicleType, ppProperty, propertyValue));
            Console.WriteLine();
        }

        private void ListAllTypes()
        {
            Console.Clear();
            if (!valet.GarageExist)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }
            Console.WriteLine(valet.ListAllTypes());
        }

        private void ListAll()
        {
            Console.Clear();
            if (!valet.GarageExist)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }
            Console.WriteLine(valet.ListAllParked());
        }

        private void BuildRazeGarage()
        {
            Console.Clear();
            if (!valet.GarageExist)
            {
                Console.Write("Enter the size of garage: ");
                if (Int32.TryParse(Console.ReadLine(), out var size))
                {
                    valet.BuildGarage(size);
                    Console.WriteLine($"A new garage of size {size} has been created.");
                    Console.WriteLine();
                }
                else
                    ErrorMessage("The CEO does not like your joke. You are fired.");
            }
            else
            {
                Console.Write("Do you REALLY want to raze the garage (Yes/No):");
                var shouldRaze = Console.ReadLine();
                bool bShouldRaze;
                if (shouldRaze.ToLower() == "yes")
                    bShouldRaze = true;
                else if (shouldRaze.ToLower() == "no")
                    bShouldRaze = false;
                else
                {
                    ErrorMessage("We do not accept funny answers. The stocks plummets.");
                    return;
                }
                if (bShouldRaze)
                {
                    Console.Write("A team of demolition guys has been hired. The garage is gone. ");
                    if (valet.ParkedCount > 0)
                        Console.WriteLine("Oh, nooes. What about all the vehicles. We forgot to unpark them.");
                    valet.RazeGarage();
                }
                Console.WriteLine();
            }
        }

        private void UnPark()
        {
            Console.Clear();
            if (!valet.GarageExist)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }
            Console.Write("Enter registration number:");
            var regnr = Console.ReadLine();
            var vehicle = valet.UnPark(regnr);
            if (vehicle == null)
                ErrorMessage($"There is no vehicle with the registraton number {regnr}. Thank you, come back again.");
            else
            {
                Console.WriteLine("Here you go. " + vehicle);
                Console.WriteLine("Thank you for parking here. Please come back again.");
                Console.WriteLine();
            }
        }

        private void Park()
        {
            Console.Clear();
            if (!valet.GarageExist)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }

            Console.WriteLine("Welcome to the Garage! What type of vehicle do you want to park?");
            Console.WriteLine("1) Airplane");
            Console.WriteLine("2) Boat");
            Console.WriteLine("3) Bus");
            Console.WriteLine("4) Car");
            Console.WriteLine("5) Motorcycle");
            var vehicleType = Console.ReadLine();

            Console.Write("Enter registration number:");
            var regnr = Console.ReadLine();
            Console.Write("Enter number of wheels:");
            var nrOfWheels = Console.ReadLine();

            DidPark didPark;
            switch (vehicleType)
            {
                case "1":
                    Console.Write("Type of fuel:");
                    var typeOfFuelAP = Console.ReadLine();
                    Console.Write("Number of seats:");
                    var nrOfSeatsAP = Console.ReadLine();
                    didPark = valet.Park(new Airplane(regnr, nrOfWheels, typeOfFuelAP, nrOfSeatsAP));
                    break;

                case "2":
                    Console.Write("Length of boat:");
                    var lengthOfBoat = Console.ReadLine();
                    Console.Write("cc of cylinder volume:");
                    var cylinderVolume = Console.ReadLine();
                    didPark = valet.Park(new Boat(regnr, nrOfWheels, lengthOfBoat, cylinderVolume));
                    break;

                case "3":
                    Console.Write("Type of fuel:");
                    var typeOfFuelBus = Console.ReadLine();
                    Console.Write("Number of seats:");
                    var nrOfSeatsBus = Console.ReadLine();
                    didPark = valet.Park(new Bus(regnr, nrOfWheels, typeOfFuelBus, nrOfSeatsBus));
                    break;

                case "4":
                    Console.Write("Type of fuel:");
                    var typeOfFuelCar = Console.ReadLine();
                    Console.Write("Is it a sports car (Yes/No):");
                    var carType = Console.ReadLine();
                    if (carType.ToLower() == CarTypes.Sport.ToString().ToLower())
                        carType = CarTypes.Sport.ToString();
                    else if (carType.ToLower() == CarTypes.Family.ToString().ToLower())
                        carType = CarTypes.Family.ToString();
                    else
                    {
                        ErrorMessage("We do not accept funny answers. Back to main you go.");
                        return;
                    }
                    Console.WriteLine();
                    didPark = valet.Park(new Car(regnr, nrOfWheels, typeOfFuelCar, carType));
                    break;

                case "5":
                    Console.Write("Type of bike:");
                    var typeOfBike = Console.ReadLine();
                    Console.Write("Color of bike:");
                    var color = Console.ReadLine();
                    didPark = valet.Park(new Motorcycle(regnr, nrOfWheels, typeOfBike, color));
                    break;

                default:
                    Console.WriteLine("No valid vehicle selected. We don't want your vehicle in here.");
                    Console.WriteLine();
                    return;
            }
            if (didPark == DidPark.Parked)
                Console.WriteLine("Your vehicle is parked");
            else if (didPark == DidPark.AlreadyExist)
                Console.WriteLine("Your vehicle has a registration number that already exists in our garage. Get a new vehicle and try again.");
            else
                Console.WriteLine("The garage has reached its maximum capacity.");
            Console.WriteLine();
        }

        public void ErrorMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}