using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolowium2.Models
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Required]
        [MaxLength(20)]
        public string TrackName { get; set; }
        [Required]
        public float Duration { get; set; }
        
        public int? IdMusicAlbum { get; set; }

        [ForeignKey("IdMusicAlbum")]
        public virtual Album Album { get; set; }

        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }
    }
}
