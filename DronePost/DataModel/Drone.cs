﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DronePost.DataModel
{
    /// <summary>
    /// Represents drone.
    /// </summary>
    public class Drone
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DroneModel Model { get; set; }

        //public DroneTechInfo techInfo {get; set}

        [Required]
        public float Longitude { get; set; }

        [Required]
        public float Latitude { get; set; }

    }
}
