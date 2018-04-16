using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModels
{
    public class EventDetails : Entity
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public virtual Post Post { get; set; }
    }
}
