using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BrowserGame_courseSimbirSoft_.Models;

namespace BrowserGame_courseSimbirSoft_.Models
{
    public class Door
    {
        public int Id { get; set; }

        [ForeignKey("RoomFrom")]
        public int RoomFromId { get; set; }
        public Room RoomFrom { get; set; }

        [ForeignKey("RoomTo")]
        public int RoomToId { get; set; }
        public Room RoomTo { get; set; }
    }
}
