using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backTStask.Models
{
    public class Room
    {
        public int Id {get; set;}
        public string RoomName {get; set;}
        public string BedNumber {get; set;}
        public string PersonNumber {get; set;}
        public string Area {get; set;}
        public string Dodatno {get; set;}

        public int ObjectRentID {get; set;}
        [ForeignKey("ObjectRentID")]
        public ObjectRent ObjectRent {get;set;}

        public virtual ICollection<Reservation> Reservations {get; set;}
    }
}