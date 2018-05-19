using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DronePost.Interfaces;

namespace CoreService
{
    public class CoreService : ICoreService
    {
        private ICore _core;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}
