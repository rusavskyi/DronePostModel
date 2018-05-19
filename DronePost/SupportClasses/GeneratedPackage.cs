using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronePost.SupportClasses
{
    public class GeneratedPackage
    {
        public int SenderId { get; set; }
        public int DepartureStationId { get; set; }
        public int DestinationStationId { get; set; }
        public int PackageSizeId { get; set; }
        public string RecipientNumber { get; set; }
        public float PackageWeight { get; set; }

        public GeneratedPackage()
        {
            
        }

        public GeneratedPackage(int senderId, int departureStationId, int destinationStationId, int packageSizeId, string recipientNumber, float packageWeight)
        {
            SenderId = senderId;
            DepartureStationId = departureStationId;
            DestinationStationId = destinationStationId;
            PackageSizeId = packageSizeId;
            RecipientNumber = recipientNumber;
            PackageWeight = packageWeight;
        }
    }
}
