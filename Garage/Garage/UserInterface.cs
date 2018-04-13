using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class UserInterface
    {
        public void MainMenu()
        {

            bool KeepRunning = true;
            Garage<Vehicle> theGarage = null;

            Console.Clear();
            while (KeepRunning)
            {
                Console.WriteLine("Enter number for choice.");
                Console.WriteLine("1) Park.");
                Console.WriteLine("2) UnPark.");
                if (theGarage == null)
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
                        Park(theGarage);
                        break;

                    case "2":
                        UnPark(theGarage);
                        break;

                    case "3":
                        BuildRazeGarage(ref theGarage);
                        break;

                    case "4":
                        ListAll(theGarage);
                        break;

                    case "5":
                        ListAllTypes(theGarage);
                        break;

                    case "6":
                        ListAllWithProperty(theGarage);
                        break;

                    case "0":
                        KeepRunning = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Incorrect Input");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private void ListAllWithProperty(Garage<Vehicle> theGarage)
        {
            //Console.Clear();
            //if (theGarage == null)
            //{
            //    ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
            //    return;
            //}


        }

        private void ListAllTypes(Garage<Vehicle> theGarage)
        {
            Console.Clear();
            if (theGarage == null)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }
            Console.WriteLine(theGarage.ListAllTypes());
        }

        private void ListAll(Garage<Vehicle> theGarage)
        {
            Console.Clear();
            if (theGarage == null)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }
            Console.WriteLine(theGarage.ListAllPark());
        }

        private void BuildRazeGarage(ref Garage<Vehicle> theGarage)
        {
            Console.Clear();
            if (theGarage == null)
            {
                Console.Write("Enter the size of garage: ");
                if (Int32.TryParse(Console.ReadLine(), out var size))
                {
                    theGarage = new Garage<Vehicle>(size);
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
                    if (theGarage.Count > 0)
                        Console.WriteLine("Oh, nooes. What about all the vehicles. We forgot to unpark them.");
                    theGarage = null;
                }
                Console.WriteLine();
            }
        }

        private void UnPark(Garage<Vehicle> theGarage)
        {
            Console.Clear();
            if (theGarage == null)
            {
                ErrorMessage("Sorry for the inconvenience but the garage is not build yet. Come again after you've built it.");
                return;
            }
            Console.Write("Enter registration number:");
            var regnr = Console.ReadLine();
            var vehicle = theGarage.UnPark(regnr);
            if (vehicle == null)
                ErrorMessage($"There is no vehicle with the registraton number {regnr}. Thank you, come back again.");
            else
            {
                Console.WriteLine("Here you go. " + vehicle);
                Console.WriteLine("Thank you for parking here. Please come back again.");
                Console.WriteLine();
            }
        }

        private void Park(Garage<Vehicle> theGarage)
        {
            Console.Clear();
            if (theGarage == null)
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
            if (!Int32.TryParse(Console.ReadLine(), out var nrOfWheels))
            {
                ErrorMessage("Number of wheels is not a correct number, drive around and try again.");
                return;
            }

            Garage<Vehicle>.DidPark didPark;
            switch (vehicleType)
            {
                case "1":
                    Console.Write("Type of fuel:");
                    var typeOfFuelAP = Console.ReadLine();
                    Console.Write("Number of seats:");
                    if (!Int32.TryParse(Console.ReadLine(), out var nrOfSeatsAP))
                    {
                        ErrorMessage("Number of seats is not a correct number, fly around and try again.");
                        return;
                    }
                    didPark = theGarage.Park(new Airplane(regnr, nrOfWheels, typeOfFuelAP, nrOfSeatsAP));
                    break;
                case "2":
                    Console.Write("Length of boat:");
                    if (!Single.TryParse(Console.ReadLine(), out var lengthOfBoat))
                    {
                        ErrorMessage("Length is not a correct number, go around and try again.");
                        return;
                    }
                    Console.Write("cc of cylinder volume:");
                    if (!Int32.TryParse(Console.ReadLine(), out var cylinderVolume))
                    {
                        ErrorMessage("Length is not a correct number, go around and try again.");
                        return;
                    }
                    didPark = theGarage.Park(new Boat(regnr, nrOfWheels, lengthOfBoat, cylinderVolume));
                    break;
                case "3":
                    Console.Write("Type of fuel:");
                    var typeOfFuelBus = Console.ReadLine();
                    Console.Write("Number of seats:");
                    if (!Int32.TryParse(Console.ReadLine(), out var nrOfSeatsBus))
                    {
                        ErrorMessage("Number of seats is not a correct number, drive around and try again.");
                        return;
                    }
                    didPark = theGarage.Park(new Bus(regnr, nrOfWheels, typeOfFuelBus, nrOfSeatsBus));
                    break;
                case "4":
                    Console.Write("Type of fuel:");
                    var typeOfFuelCar = Console.ReadLine();
                    Console.Write("Is it a sports car (Yes/No):");
                    var isSportsCar = Console.ReadLine();
                    bool bIsSportsCar;
                    if (isSportsCar.ToLower() == "yes")
                        bIsSportsCar = true;
                    else if (isSportsCar.ToLower() == "no")
                        bIsSportsCar = false;
                    else
                    {
                        ErrorMessage("We do not accept funny answers. Drive around and try again.");
                        return;
                    }
                    didPark = theGarage.Park(new Car(regnr, nrOfWheels, typeOfFuelCar, bIsSportsCar));
                    break;
                case "5":
                    Console.Write("Type of bike:");
                    var typeOfBike = Console.ReadLine();
                    Console.Write("Color of bike:");
                    var color = Console.ReadLine();
                    didPark = theGarage.Park(new Motorcycle(regnr, nrOfWheels, typeOfBike, color));
                    break;
                default:
                    Console.WriteLine("No valid vehicle selected. We don't want your vehicle in here.");
                    Console.WriteLine();
                    return;
            }
            if (didPark == Garage<Vehicle>.DidPark.Parked)
                Console.WriteLine("Your vehicle is parked");
            else if (didPark == Garage<Vehicle>.DidPark.AlreadyExist)
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