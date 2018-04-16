using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    public enum DidPark
    {
        Parked,
        Full,
        AlreadyExist
    }

    // Exactly named as the vehicle classes, or else...
    public enum VehicleTypes
    {
        Vehicle, // Special for searches
        Airplane,
        Boat,
        Bus,
        Car,
        Motorcycle
    }

    public enum Properties
    {
        Any, // Special for searches
        RegNr,
        NrOfWheels,
        FuelType,
        NrOfSeats,
        CarType,
        Brand,
        Color,
        Length,
        CylinderVolume
    }

    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] collection;
        private int cap;
        private int count;

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
