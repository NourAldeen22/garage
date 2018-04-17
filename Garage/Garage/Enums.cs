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

    public enum CarTypes
    {
        Sport,
        Family
    }
}
