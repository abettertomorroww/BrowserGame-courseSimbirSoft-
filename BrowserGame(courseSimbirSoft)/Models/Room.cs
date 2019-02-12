using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrowserGame_courseSimbirSoft_.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string Task { get; set; }
        public string Answer { get; set; }

        [InverseProperty("RoomTo")]
        public ICollection<Door> DoorsIn { get; set; }
        [InverseProperty("RoomFrom")]
        public ICollection<Door> DoorsOut { get; set; }


    }
}
