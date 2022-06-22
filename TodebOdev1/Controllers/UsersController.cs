using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodebOdev1.Models;

namespace TodebOdev1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public List<User> Users = new List<User>()
        {
            new User() {Id =1, Firstname = "Ahnmet",Lastname = "Kutan"},
            new User() {Id =1, Firstname = "Beyza",Lastname = "Salkım"},
            new User() {Id =1, Firstname = "Deniz",Lastname = "Gözde"},
        };

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
          var user = Users.Where(x=>x.Id==id).FirstOrDefault();

          if (user == null)
              return NotFound(); 

          return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(Users);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            Users.Add(user);

            return Ok("User added");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,User user)
        {
            var currentUseruser = Users.Where(x => x.Id == id).FirstOrDefault();


            Users.Remove(currentUseruser);
            Users.Add(user);

            return Ok("User Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Users.Remove(Users.Where(x=>x.Id==id).FirstOrDefault());

            return Ok("User removed");
        }

    }
}

 

