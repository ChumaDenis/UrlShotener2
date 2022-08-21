using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UrlShortener2.Context;
using UrlShortener2.Models;
namespace UrlShortener2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<UrlController> _logger;
        private readonly UrlDbContext _context;
        public UrlController(ILogger<UrlController> logger,UrlDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(_context.UrlInfos.ToList());
        }
        [HttpGet("{id?}")]
        public async Task<ActionResult> GetById(string id)
        {
            return Ok(_context.UrlInfos.ToList().Find(x=>x.Id==id)?.Url);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post(UrlInfo urlInfo)
        {
            if (urlInfo == null)
            {
                return BadRequest();
            }
            UrlValidator validator = new UrlValidator("https://"+ this.Request.Host.ToString() + this.Request.Path.ToString()+"/");
            if(_context.UrlInfos.ToList().Find(x=>x.Url== urlInfo.Url) == null)
            {
                _context.UrlInfos.Add(UrlManager.Create(urlInfo, validator));
                _context.SaveChanges();
                return Ok(_context.UrlInfos.ToList());
            }
            return BadRequest("This link already exists");
        }



    }
}
