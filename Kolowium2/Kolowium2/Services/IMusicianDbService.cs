using Kolowium2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolowium2.Services
{
    public interface IMusicianDbService
    {
        Task<MusicianDTO> GetMusician(int idMusician);
        Task DeleteMusician(int idMusician);
    }
}
