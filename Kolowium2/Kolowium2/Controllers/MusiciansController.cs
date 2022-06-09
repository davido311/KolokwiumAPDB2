using Kolowium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolowium2.Controllers
{
    [Route("musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private readonly IMusicianDbService _musicianDbService;

        public MusiciansController(IMusicianDbService musicianDbService)
        {
            _musicianDbService = musicianDbService;
        }


        [HttpGet("{idMusician}")]

        public async Task<IActionResult> GetMusician(int idMusician)
        {
            try
            {
                return Ok(await _musicianDbService.GetMusician(idMusician));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{idMusician}")]
        public async Task<IActionResult> DeleteMusician(int idMusician)
        {

            try
            {
                await _musicianDbService.DeleteMusician(idMusician);
                return Ok("Deleted musician");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
