using ChessVariants.Shared.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessVariants.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private IMemoryCache _cache;

        public GameController(IMemoryCache cache)
        {
            _cache = cache;
        }

        /*
        [Route("updategame/{gameId}")]
        [HttpGet]
        public Game UpdateGame(string gameId) =>
            _cache.Get<List<Game>>("GameCacheKey").FirstOrDefault(_ => _.Id == gameId);
        */

    }
}
