using api_for_moblie_app.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_for_moblie_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
           new User
           {
               Id=1,
               Name = "Nguyen Hoang Kiet",
               Age = 20,
               Created = DateTime.Now
           }
        };

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = users.Find(user => user.Id == id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            return Ok(user);
        }
        

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpadateUser(User request)
        {
            var user = users.Find(user => user.Id == request.Id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            user.Name = request.Name;
            user.Age = request.Age;
            user.Created = request.Created;

            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = users.Find(user => user.Id == id);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            users.Remove(user);

            return Ok(user);
        }
    }

   
}
