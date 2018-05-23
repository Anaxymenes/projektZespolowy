using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DBModel
{
    public class EventDetails : Entity {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
