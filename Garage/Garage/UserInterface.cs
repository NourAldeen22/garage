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
                        if (!valet.GarageExist)
                        {
                            BuildGarage();
                        }
                        else
                        {
                            RazeGarage();
                        }
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
                        TESTING();
                        break;

                    default:
                        Console.Clear();
                        ErrorMessage("Incorrect Input");
                        break;
                }
            }
        }

        public void ErrorMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }

        public bool GarageExist()
        {
            if (!valet.GarageExist)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return false;
            }
            return true;
        }

        private void TESTING()
        {
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
        }

        private bool AskYesNo(string str)
        {
            Console.Write(str);
            var shouldRaze = Console.ReadLine();
            if (shouldRaze.ToLower() == "yes")
                return true;
            else if (shouldRaze.ToLower() == "no")
                return false;
            else
            {
                throw new Exception();
            }
        }

        private string AskOptions(string str, params string[] options)
        {
            Console.Write(str);
            var input = Console.ReadLine();
            foreach (var o in options)
            {
                if (input.ToLower() == o.ToLower())
                    return o;
            }
            throw new Exception();
        }

        private void RazeGarage()
        {
            Console.Clear();
            bool shouldRaze = false;
            try
            {
                shouldRaze = AskYesNo("Do you REALLY want to raze the garage (Yes/No): ");
            }
            catch (Exception)
            {
                ErrorMessage("We do not accept funny answers. The stocks plummets.");
                return;
            }
            if (shouldRaze)
            {
                Console.Write("A team of demolition guys has been hired. The garage is gone. ");
                if (valet.ParkedCount > 0)
                    Console.WriteLine("Oh, nooes. What about all the vehicles. We forgot to unpark them.");
                else
                    Console.WriteLine();
                valet.RazeGarage();
            }
            Console.WriteLine();
        }

        private void BuildGarage()
        {
            Console.Clear();
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

        private Vehicle CreateVehicle()
        {
            Console.WriteLine("1) Airplane");
            Console.WriteLine("2) Boat");
            Console.WriteLine("3) Bus");
            Console.WriteLine("4) Car");
            Console.WriteLine("5) Motorcycle");
            var vehicleType = Console.ReadLine();

            Console.Write("Enter registration number: ");
            var regnr = Console.ReadLine();
            string nrOfWheels;
            do
            {
                Console.Write("Enter number of wheels: ");
                nrOfWheels = Console.ReadLine();
            } while (!Int32.TryParse(nrOfWheels, out int temp));


            switch (vehicleType)
            {
                case "1":
                    Console.Write("Type of fuel: ");
                    var typeOfFuelAP = Console.ReadLine();
                    string nrOfSeatsAP;
                    do
                    {
                        Console.Write("Number of seats: ");
                        nrOfSeatsAP = Console.ReadLine();
                    } while (!Int32.TryParse(nrOfSeatsAP, out int temp));
                    return new Airplane(regnr, nrOfWheels, typeOfFuelAP, nrOfSeatsAP);

                case "2":
                    string lengthOfBoat;
                    do
                    {
                        Console.Write("Length of boat: ");
                        lengthOfBoat = Console.ReadLine();
                    } while (!Int32.TryParse(lengthOfBoat, out int temp));
                    string cylinderVolume;
                    do
                    {
                        Console.Write("cc of cylinder volume: ");
                        cylinderVolume = Console.ReadLine();
                    } while (!float.TryParse(cylinderVolume, out float temp));
                    return new Boat(regnr, nrOfWheels, lengthOfBoat, cylinderVolume);

                case "3":
                    Console.Write("Type of fuel: ");
                    var typeOfFuelBus = Console.ReadLine();
                    string nrOfSeatsBus;
                    do
                    {
                        Console.Write("Number of seats: ");
                        nrOfSeatsBus = Console.ReadLine();
                    } while (!Int32.TryParse(nrOfSeatsBus, out int temp));
                    return new Bus(regnr, nrOfWheels, typeOfFuelBus, nrOfSeatsBus);

                case "4":
                    Console.Write("Type of fuel: ");
                    var typeOfFuelCar = Console.ReadLine();
                    string carType = "";
                    try
                    {
                        carType = AskOptions($"What type of car is it ({CarTypes.Sport}/{CarTypes.Family}): ",
                            CarTypes.Sport.ToString(),
                            CarTypes.Family.ToString());
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    return new Car(regnr, nrOfWheels, typeOfFuelCar, carType);

                case "5":
                    Console.Write("Type of bike: ");
                    var typeOfBike = Console.ReadLine();
                    Console.Write("Color of bike: ");
                    var color = Console.ReadLine();
                    return new Motorcycle(regnr, nrOfWheels, typeOfBike, color);

                default:
                    Console.WriteLine("No valid vehicle selected. We cannot park your vehicle in here.");
                    return null;
            }
        }

        private void Park()
        {
            Console.Clear();
            if (!GarageExist()) return;

            Console.WriteLine("Welcome to the Garage! What type of vehicle are you operating?");
            var vehicle = CreateVehicle();
            if (vehicle == null)
            {
                Console.WriteLine("No valid vehicle selected. We cannot park your vehicle in here.");
                Console.WriteLine();
                return;
            }
            DidPark didPark = valet.Park(vehicle);
            if (didPark == DidPark.Parked)
                Console.WriteLine("Your vehicle is parked");
            else if (didPark == DidPark.AlreadyExist)
                Console.WriteLine("Your vehicle has a registration number that already exists in our garage. Get a new vehicle and try again.");
            else
                Console.WriteLine("The garage has reached its maximum capacity.");
            Console.WriteLine();
        }

        private void UnPark()
        {
            Console.Clear();
            if (!GarageExist()) return;

            Console.Write("Enter registration number:");
            var regnr = Console.ReadLine();
            var vehicle = valet.UnPark(regnr);
            if (vehicle == null)
                ErrorMessage($"There is no vehicle with the registraton number {regnr}. Thank you, come back again.");
            else
            {
                Console.WriteLine("Here you go.");
                Console.WriteLine(vehicle);
                Console.WriteLine("Thank you for parking here. Please come back again.");
                Console.WriteLine();
            }
        }

        private void ListAll()
        {
            Console.Clear();
            if (!GarageExist()) return;
            Console.WriteLine(valet.ListAllParked());
        }

        private void ListAllTypes()
        {
            Console.Clear();
            if (!GarageExist()) return;
            Console.WriteLine(valet.ListAllTypes());
        }

        private void ListAllWithProperty()
        {
            Console.Clear();
            if (!GarageExist()) return;

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
            switch (vehicleType + " " + propertySelected)
            {
                case "1 1": // airplane + regnr
                case "2 1": // boat + regnr
                case "3 1": // bus + regnr
                case "4 1": // car + regnr
                case "5 1": // bike + regnr
                case "6 1": // ALL + regnr
                    Console.Write("Enter registration number:");
                    ppProperty = Properties.RegNr;
                    break;

                case "1 2": // airplane + nr of wheels
                case "2 2": // boat + nr of wheels
                case "3 2": // bus + nr of wheels
                case "4 2": // car + nr of wheels
                case "5 2": // bike + nr of wheels
                case "6 2": // all + nr of wheels
                    Console.Write("Enter number of wheels:");
                    ppProperty = Properties.NrOfWheels;
                    break;

                case "1 3": // airplane + type of fuel
                case "3 3": // bus + type of fuel
                case "4 3": // car + type of fuel
                    Console.Write("Type of fuel:");
                    ppProperty = Properties.FuelType;
                    break;

                case "1 4": // airplane + seats
                case "3 4": // bus + seats
                    Console.Write("Number of seats:");
                    ppProperty = Properties.NrOfSeats;
                    break;

                case "2 3": // boat + length
                    Console.Write("Length of boat:");
                    ppProperty = Properties.Length;
                    break;

                case "2 4": // boat + cylinder volume
                    Console.Write("cc of cylinder volume:");
                    ppProperty = Properties.CylinderVolume;
                    break;

                case "4 4": // car + is sports car
                    //Console.Write("What type of car is it (Sport/Family):");
                    ppProperty = Properties.CarType;
                    break;

                case "5 3": // bike + type
                    Console.Write("Type of bike:");
                    ppProperty = Properties.Brand;
                    break;

                case "5 4": // bike + color
                    Console.Write("Color of bike:");
                    ppProperty = Properties.Color;
                    break;

                case "1 5": // all airplanes
                case "2 5": // all boats
                case "3 5": // all buses
                case "4 5": // all cars
                case "5 5": // all bikes
                    ppProperty = Properties.Any;
                    break;

                default:
                    Console.WriteLine("Not a valid entry. Back to main you go.");
                    Console.WriteLine();
                    return;
            }

            if (vtVehicleType == VehicleTypes.Car && ppProperty == Properties.CarType)
            {
                string carType = "";
                try
                {
                    carType = AskOptions($"What type of car is it ({CarTypes.Sport}/{CarTypes.Family}): ",
                        CarTypes.Sport.ToString(),
                        CarTypes.Family.ToString());
                }
                catch (Exception)
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

            Console.Clear();
            Console.WriteLine(valet.ListAllVehiclesWithProperty(vtVehicleType, ppProperty, propertyValue));
            Console.WriteLine();
        }
    }
}