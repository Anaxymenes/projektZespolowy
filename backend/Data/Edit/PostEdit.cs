using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.DBModel
{
    public class PostEdit
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
