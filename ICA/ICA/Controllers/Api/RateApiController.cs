using ICA.Data;
using ICA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace ICA.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateApiController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public RateApiController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IActionResult Rating(string IP,string ratinglevel,string Comment)
        {

            var rating = new Rating()
            {
                Comment = Comment,
                IP = IP,
                RatingLevel=ratinglevel
            };
            context.Rating.Add(rating);
            context.SaveChanges();
            return Ok();
        }

    }
}
