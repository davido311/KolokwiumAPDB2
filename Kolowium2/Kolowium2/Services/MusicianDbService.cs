using Kolowium2.Models;
using Kolowium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolowium2.Services
{
    public class MusicianDbService : IMusicianDbService
    {
        private readonly MainDbContext _mainDbContext;

        public MusicianDbService(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task DeleteMusician(int idMusician)
        {
            var musician = await _mainDbContext.Musicians.FirstOrDefaultAsync(e => e.IdMusician == idMusician);
            bool musicianExists = (await _mainDbContext.Musicians.FirstOrDefaultAsync(e => e.IdMusician == idMusician)) != null;
            if (musicianExists == false)
                throw new Exception("This musician doesn't exist!");

            var musicianTrack = await _mainDbContext.Musician_Tracks.FirstOrDefaultAsync(e => e.IdMusician == idMusician);

            bool musicianTracksExists = (await _mainDbContext.Musician_Tracks.FirstOrDefaultAsync(e => e.IdMusician == idMusician)) != null;
            if(musicianTracksExists==false)
                throw new Exception("This musician haven't make any tracks yet!");

             var track = await _mainDbContext.Tracks
                 .Where(e => e.IdTrack == musicianTrack.IdTrack)
                 .Where(e => e.IdMusicAlbum == null)
                 .FirstOrDefaultAsync();
            //idmusicalbum==null -> piosenki muzyka nie opjawiły sie na albumie

            if (track == null)
                throw new Exception("Utwór muzyka pojawił się na albumie, nie można usunąc muzyka!");

            if (musicianExists && musicianTracksExists && track != null) {
                _mainDbContext.Musicians.Remove(musician);
                _mainDbContext.Musician_Tracks.Remove(musicianTrack);
                _mainDbContext.SaveChanges();
}
        }

        public async Task<MusicianDTO> GetMusician(int idMusician)
        {
            if ((await _mainDbContext.Musicians.FirstOrDefaultAsync(e => e.IdMusician == idMusician)) == null)
                throw new Exception("This musician doesn't exist!");

            var musician = await _mainDbContext.Musicians
                .Where(e => e.IdMusician == idMusician)
                .Select(e => new MusicianDTO
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    NickName = e.NickName,

                    Tracks = e.Musician_Tracks
                    .Select(t => new TrackDTO
                    {
                        TrackName = t.Track.TrackName,
                        Duration = t.Track.Duration
                    }).OrderBy(t=>t.Duration).ToList()

                }).FirstOrDefaultAsync();

            return musician;
        }
    }
}
