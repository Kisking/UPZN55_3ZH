using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UPZN55_3ZH.Controllers
{

    [Route("api/jokes")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        JokeModels.FunnyDatabaseContext context = new JokeModels.FunnyDatabaseContext();

        //GET: api/jokes
       [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Jokes.ToList());
        }

        // DELETE api/jokes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var törlendőVicc = (from x in context.Jokes
                                where x.JokeSk == id
                                select x).FirstOrDefault();
            context.Remove(törlendőVicc);
            context.SaveChanges();
        }
    }
}
