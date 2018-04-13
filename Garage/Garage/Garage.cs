using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] collection;
        private int cap;
        private int count;

        public enum DidPark
        {
            Parked,
            Full,
            AlreadyExist
        }

        public int Count { get { return count; } }

        public Garage(int capacity)
        {
            cap = capacity < 1 ? 1 : capacity;
            count = 0;
            collection = new T[cap];
        }

        public DidPark Park(T v)
        {
            if (cap <= count) return DidPark.Full;
            if (count > 0)
                if (this.Any(x => x.Regnr == v.Regnr))
                    return DidPark.AlreadyExist;

            collection[count++] = v;
            return DidPark.Parked;
        }

        public T UnPark(string regnr)
        {
            T v = this.FirstOrDefault(x => x.Regnr == regnr); // could be added to the for loop
            if (v == null) return null;

            int i = 0;
            for (; i < count; i++)
            {
                if (collection[i].Regnr == regnr)
                {
                    //v = collection[i];
                    collection[i] = null;
                    break;
                }
            }
            for (; i < count - 1; i++)
            {
                collection[i] = collection[i + 1];
            }
            collection[i] = null;
            count--;
            return v;
        }

        public string ListAllPark()
        {
            string output = "";

            foreach (var v in this)
            {
                output += v.ToString() + Environment.NewLine;
            }

            return output;
        }

        public string ListAllTypes()
        {
            string output = "";

            if (count > 0)
            {
                var typedGarage = this.GroupBy(x => x.GetType().Name);

                foreach (var t in typedGarage)
                {
                    output += t.Key + Environment.NewLine;
                }
            }

            return output;
        }

        public string ListAllVehiclesWithProperty(string vehicleType, string property, object value)
        {
            string output = "";
            if (count > 0)
            {
                Garage<Vehicle> filteredGarage = null;
                switch (vehicleType)
                {
                    case "Airplane":
                        var airplaneGarage = (Garage<Airplane>)this.Where(x => x.GetType().Name == vehicleType);
                        switch (property)
                        {
                            case "FuelType":
                                filteredGarage = (Garage<Vehicle>)airplaneGarage.Where(x => x.FuelType == (string)value);
                                break;
                            case "Seats":
                                filteredGarage = (Garage<Vehicle>)airplaneGarage.Where(x => x.NrofSeats == (int)value);
                                break;
                            case "Regnr":
                                filteredGarage = (Garage<Vehicle>)airplaneGarage.Where(x => x.Regnr == (string)value);
                                break;
                            case "Wheel":
                                filteredGarage = (Garage<Vehicle>)airplaneGarage.Where(x => x.Wheels == (int)value);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Car":
                        var carGarage = (Garage<Car>)this.Where(x => x.GetType().Name == vehicleType);
                        switch (property)
                        {
                            case "FuelType":
                                filteredGarage = (Garage<Vehicle>)carGarage.Where(x => x.FuelType == (string)value);
                                break;
                            case "IsSportCar":
                                filteredGarage = (Garage<Vehicle>)carGarage.Where(x => x.IsSportCar == (bool)value);
                                break;
                            case "Regnr":
                                filteredGarage = (Garage<Vehicle>)carGarage.Where(x => x.Regnr == (string)value);
                                break;
                            case "Wheel":
                                filteredGarage = (Garage<Vehicle>)carGarage.Where(x => x.Wheels == (int)value);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Motorcycle":
                        var motorcycleGarage = (Garage<Motorcycle>)this.Where(x => x.GetType().Name == vehicleType);
                        switch (property)
                        {
                            case "Type":
                                filteredGarage = (Garage<Vehicle>)motorcycleGarage.Where(x => x.Type == (string)value);
                                break;
                            case "Color":
                                filteredGarage = (Garage<Vehicle>)motorcycleGarage.Where(x => x.Color == (string)value);
                                break;
                            case "Regnr":
                                filteredGarage = (Garage<Vehicle>)motorcycleGarage.Where(x => x.Regnr == (string)value);
                                break;
                            case "Wheel":
                                filteredGarage = (Garage<Vehicle>)motorcycleGarage.Where(x => x.Wheels == (int)value);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Bus":
                        var busGarage = (Garage<Bus>)this.Where(x => x.GetType().Name == vehicleType);
                        switch (property)
                        {
                            case "FuelType":
                                filteredGarage = (Garage<Vehicle>)busGarage.Where(x => x.FuelType == (string)value);
                                break;
                            case "Seats":
                                filteredGarage = (Garage<Vehicle>)busGarage.Where(x => x.NrofSeats == (int)value);
                                break;
                            case "Regnr":
                                filteredGarage = (Garage<Vehicle>)busGarage.Where(x => x.Regnr == (string)value);
                                break;
                            case "Wheel":
                                filteredGarage = (Garage<Vehicle>)busGarage.Where(x => x.Wheels == (int)value);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Boat":
                        var boatGarage = (Garage<Boat>)this.Where(x => x.GetType().Name == vehicleType);
                        switch (property)
                        {
                            case "Length":
                                filteredGarage = (Garage<Vehicle>)boatGarage.Where(x => x.Length == (int)value);
                                break;
                            case "CylinderVolume":
                                filteredGarage = (Garage<Vehicle>)boatGarage.Where(x => x.CylinderVolume == (float)value);
                                break;
                            case "Regnr":
                                filteredGarage = (Garage<Vehicle>)boatGarage.Where(x => x.Regnr == (string)value);
                                break;
                            case "Wheel":
                                filteredGarage = (Garage<Vehicle>)boatGarage.Where(x => x.Wheels == (int)value);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Vehicle":
                        switch (property)
                        {
                            case "Regnr":
                                filteredGarage = (Garage<Vehicle>)this.Where(x => x.Regnr == (string)value);
                                break;
                            case "Wheel":
                                filteredGarage = (Garage<Vehicle>)this.Where(x => x.Wheels == (int)value);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                foreach (var v in filteredGarage)
                {
                    output += v.ToString() + Environment.NewLine;
                }
            }
            return output;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                if (collection[i] != null)
                    yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
