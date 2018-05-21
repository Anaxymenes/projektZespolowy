using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class EventDTO
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
