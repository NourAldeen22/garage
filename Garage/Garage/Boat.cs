namespace Garage
{
    public class Boat : Vehicle
    {
        public Boat(string regnr, int wheels, float length, int cylinderVolume) : base(regnr, wheels)
        {
            Length = length;
            CylinderVolume = cylinderVolume;
        }

        public float Length { get; private set; }
        public int CylinderVolume { get; private set; }

        public override string ToString()
        {
            return $"This is a Boat. " + base.ToString() + $" This Boat is {Length} meters and has an engine of {CylinderVolume} cc.";
        }
    }
}
