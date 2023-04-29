using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApi.Models;

namespace MusicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicItemsController : ControllerBase
    {
        private List<MusicItem> _music = new List<MusicItem>();

        public MusicItemsController()
        {
            _music.Add(new MusicItem { Id = 1, Title  = "Honest", Genre = "Electropop", Artist = "The Neighbourhood" });
            _music.Add(new MusicItem { Id = 2, Title  = "Peaches", Genre = "Pop", Artist = "Justin Bieber", Album = "Justice" });
            _music.Add(new MusicItem { Id = 3, Title  = "Somewhere I Belong", Genre = "Alternative Rock", Artist = "Linkin Park", Album = "Meteora" });
            _music.Add(new MusicItem { Id = 4, Title  = "Pretty Girl Hi Reimagined", Genre = "R&B/Soul", Artist = "UMI", Album = "Introspection Reimagined" });
            _music.Add(new MusicItem { Id = 5, Title  = "Call Me, I Still Love You", Genre = "Alternative/Indie", Artist = "Two Feet", Album = "Pink" });

        }

        // GET: api/MusicItems
        [HttpGet]
        public ActionResult<IEnumerable<MusicItem>>  GetMusicItems()
        {
            return _music;
        }

        // GET: api/MusicItems/5
        [HttpGet("{id}")]
        public ActionResult<MusicItem> GetMusicItem(long id)
        {
            var musicItem = _music.Find(m => m.Id == id);

            if (musicItem == null)
            {
                return NotFound();
            }

            return musicItem;
        }

        // PUT: api/MusicItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult PutMusicItem(long id, MusicItem musicItem)
        {
            var music = _music.Find(m => m.Id == id);

            if (music == null)
            {
                return BadRequest();
            }

            music.Title = musicItem.Title;
            music.Genre = musicItem.Genre;
            music.Artist = musicItem.Artist;
            music.Album = musicItem.Album;

            return NoContent();
        }

        // POST: api/MusicItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<MusicItem>  PostMusicItem(MusicItem musicItem)
        {
            musicItem.Id = _music.Max(m => m.Id) + 1;
            _music.Add(musicItem);

            //return CreatedAtAction("GetMusicItem", new { id = musicItem.Id }, musicItem);
            return CreatedAtAction(nameof(GetMusicItem), new { id = musicItem.Id }, musicItem);
        }

        // DELETE: api/MusicItems/5
        [HttpDelete]
        public IActionResult  DeleteMusicItem(long id)
        {
            var musicItem = _music.Find(m => m.Id == id);

            if (musicItem == null)
            {
                return NotFound();
            }

            _music.Remove(musicItem);

            return NoContent();
        }
 
    }
}
