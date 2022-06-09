using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolowium2.Models
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }


        [ForeignKey("IdTrack")]
        public virtual Track Track { get; set; }

        [ForeignKey("IdMusician")]
        public virtual Musician Musician { get; set; }
    }
}
