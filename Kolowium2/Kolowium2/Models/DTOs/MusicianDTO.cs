using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolowium2.Models.DTOs
{
    public class MusicianDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public ICollection<TrackDTO> Tracks { get; set; }
    }
}
