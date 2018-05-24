using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class HobbyDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Color { get; set; }

        public int AdministratorId { get; set; }
    }
}
