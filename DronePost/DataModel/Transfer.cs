using System;
using System.ComponentModel.DataAnnotations;

namespace DronePost.DataModel
{
    /// <summary>
    /// This class represents log of events happening in system, like package and drone movements.
    /// </summary>
    public class Transfer
    {
        [Required]
        public int Id { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        public Station ArrivalStation { get; set; }

        public Station DepartureStation { get; set; }

        public Drone Drone { get; set; }

        public Package Package { get; set; }
    }
}