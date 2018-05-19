using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronePost.SupportClasses
{
    public class DroneTechInfo
    {
        private string _name;
        private string _model;
        private double _weight; // drone's weight in gramms
        private double _carrying; // carrying capacity in gramms
        private double _batteryCapacity; // in mAh
        private DroneSize _size;


        // ToDo will be defined later
    }

    public enum DroneSize
    {
        Small, Medium, Large
    }
}
