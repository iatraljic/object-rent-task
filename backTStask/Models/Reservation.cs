using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backTStask.Models
{
    public class Reservation
    {
        public int Id {get; set;}
        
        public string fromDate { get; set; }

        public string toDate {get; set;}

        public int GuestID {get; set;}
        [ForeignKey("GuestID")]
        public virtual Guest Guest {get; set;}

        public int RoomID {get; set;}
        [ForeignKey("RoomID")]
        public virtual Room Room {get; set;}
    }
}