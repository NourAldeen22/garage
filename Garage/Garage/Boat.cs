namespace Garage
{
    public class Boat : Vehicle
    {
        public Boat(string regnr, string wheels, string length, string cylinderVolume) : base(regnr, wheels)
        {
            Length = length;
            CylinderVolume = cylinderVolume;
        }

        public string Length { get; private set; }
        public string CylinderVolume { get; private set; }

        public override string ToString()
        {
            return $"This is a Boat. " + base.ToString() + $" This Boat is {Length} meters and has an engine of {CylinderVolume} cc.";
        }
    }
}
