using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationSimulator
{
    interface IMessageHandler
    {
        void Handle(string message);
    }
}
