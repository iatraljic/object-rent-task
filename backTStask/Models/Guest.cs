using System;
using System.Collections.Generic;

namespace backTStask.Models
{
    public class Guest
    {
        public int Id {get; set;}
        public string FullName {get; set;}
        public string Adress {get; set;}
        public string City {get; set;}
        public string Card {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}

        public virtual ICollection<Reservation> Reservations {get; set;}
    }
}