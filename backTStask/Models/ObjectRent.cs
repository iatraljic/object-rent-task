using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backTStask.Models
{
    public class ObjectRent
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Category {get; set;}
        public string Adress {get; set;}
        public string City {get; set;}
        public virtual ICollection<Room> Rooms {get; set;}
    }
}