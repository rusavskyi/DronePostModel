using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronePost.SupportClasses
{
    public class DroneTechInfo
    {
        private string Name;
        private string Model;
        private double Weight; // drone's weight in gramms
        private double Carrying; // carrying capacity in gramms
        private double BatteryCapacity; // in mAh
        private DroneSize Size;


        // ToDo will be defined later
    }

    public enum DroneSize
    {
        Small, Medium, Large
    }
}
