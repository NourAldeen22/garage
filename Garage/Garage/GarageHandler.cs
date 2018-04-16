using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageHandler
    {
        private Garage<Vehicle> theGarage;

        public GarageHandler()
        {
            theGarage = null;
        }

        public int ParkedCount { get { return theGarage.Count; } }
        public bool GarageExist { get { return !(theGarage == null); } }

        public void BuildGarage(int capacity)
        {
            theGarage = new Garage<Vehicle>(capacity);
        }

        public void RazeGarage()
        {
            theGarage = null;
        }

        public DidPark Park(Vehicle v)
        {
            return theGarage.Park(v);
        }

        public Vehicle UnPark(string regnr)
        {
            return theGarage.UnPark(regnr);
        }

        public string ListAllParked()
        {
            string output = "";

            foreach (var v in theGarage)
            {
                output += v.ToString() + Environment.NewLine;
            }

            return output;
        }

        public string ListAllTypes()
        {
            string output = "";

            if (theGarage.Count > 0)
            {
                var typedGarage = theGarage.GroupBy(x => x.GetType().Name);

                foreach (var t in typedGarage)
                {
                    output += t.Key + Environment.NewLine;
                }
            }

            return output;
        }

        public string ListAllVehiclesWithProperty(VehicleTypes vehicleType, Properties property, string value)
        {
            string output = "";

            foreach (var v in theGarage)
            {
                if (property == Properties.RegNr && v.Regnr.ToLower() == value.ToLower())
                    output += v.ToString() + Environment.NewLine;
                else if (property == Properties.NrOfWheels && v.NrOfWheels.ToLower() == value.ToLower())
                    output += v.ToString() + Environment.NewLine;

                if (vehicleType == VehicleTypes.Airplane && v is Airplane ap)
                {
                    if (property == Properties.FuelType && ap.FuelType.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.NrOfSeats && ap.NrOfSeats.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.Any)
                        output += v.ToString() + Environment.NewLine;
                }

                if (vehicleType == VehicleTypes.Boat && v is Boat boat)
                {
                    if (property == Properties.Length && boat.Length.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.CylinderVolume && boat.CylinderVolume.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.Any)
                        output += v.ToString() + Environment.NewLine;
                }

                if (vehicleType == VehicleTypes.Bus && v is Bus bus)
                {
                    if (property == Properties.FuelType && bus.FuelType.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.NrOfSeats && bus.NrOfSeats.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.Any)
                        output += v.ToString() + Environment.NewLine;
                }

                if (vehicleType == VehicleTypes.Car && v is Car car)
                {
                    if (property == Properties.FuelType && car.FuelType.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.CarType && car.CarType.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.Any)
                        output += v.ToString() + Environment.NewLine;
                }

                if (vehicleType == VehicleTypes.Motorcycle && v is Motorcycle mc)
                {
                    if (property == Properties.Brand && mc.Brand.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.Color && mc.Color.ToLower() == value.ToLower())
                        output += v.ToString() + Environment.NewLine;
                    else if (property == Properties.Any)
                        output += v.ToString() + Environment.NewLine;
                }
            }

            return output;
        }
    }
}
