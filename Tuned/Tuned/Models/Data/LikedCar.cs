﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuned.Models.ViewModels;

namespace Tuned.Models.Data
{
    public class LikedCar
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUserViewModel User { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
