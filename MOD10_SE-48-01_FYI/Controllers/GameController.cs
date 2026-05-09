using Microsoft.AspNetCore.Mvc;

namespace MOD10_SE_48_01_FYI.Controllers
{
    [ApiController]
    [Route("/api/Game")]
    public class GameController : ControllerBase
    {
        public static List<Game> gameLists = new List<Game>
        {
            new Game(1, "Valorant", "Riot Games", 2020, "FPS", 8.5, new string[] { "PC" }, new string[] { "Multiplayer" }, true, 0),
            new Game(2, "GTA V", "Rockstar Games", 2013, "Open World", 9.5, new string[] { "PC", "PS4", "PS5", "Xbox" }, new string[] { "Singleplayer", "Multiplayer" }, true, 300000),
            new Game(3, "The Witcher 3", "CD Projekt Red", 2015, "RPG", 9.7, new string[] { "PC", "PS4", "PS5", "Xbox", "Switch" }, new string[] { "Singleplayer" }, false, 250000)
        };

        [HttpGet]
        public ActionResult<List<Game>> GetAllGames()
        {
            return Ok(gameLists);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var game = gameLists.FirstOrDefault(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<Game> AddGame( Game newGame)
        {
            gameLists.Add(newGame);
            //return CreatedAtAction(nameof(GetGameById), new { id = newGame.id }, newGame);
            return Ok(newGame);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGame(int id, Game updatedGame)
        {
            var game = gameLists.FirstOrDefault(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Nama = updatedGame.Nama;
            game.Developer = updatedGame.Developer;
            game.TahunRilis = updatedGame.TahunRilis;
            game.Genre = updatedGame.Genre;
            game.Rating = updatedGame.Rating;
            game.Platform = updatedGame.Platform;
            game.Mode = updatedGame.Mode;
            game.IsOnlie = updatedGame.IsOnlie;
            game.Harga = updatedGame.Harga;
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteGame(int id)
        {
            var game = gameLists.FirstOrDefault(g => g.id == id);
            if (game == null)
            {
                return NotFound();
            }
            gameLists.Remove(game);
            return NoContent();

        }
    }
}
