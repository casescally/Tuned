﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuned.Models.Data
{
    public class UserEvent
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
    }
}
