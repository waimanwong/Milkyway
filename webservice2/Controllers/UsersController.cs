using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webservice2.Domain.Users;

namespace webservice2.Controllers
{
    public class UserViewModel
    {
        public long Id {get;set;}
        public string Firstname {get;set;}
        public string Lastname {get;set;}
    }

    public class UserFormViewModel
    {
        public string Firstname {get;set;}
        public string Lastname {get;set;}
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<UserViewModel> Get(long id)
        {
            var user = await _userService.GetUserById(id);

            return new UserViewModel 
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserFormViewModel userForm)
        {
            var registrationForm = new UserRegistrationForm 
            {
                Firstname = userForm.Firstname,
                Lastname  = userForm.Lastname
            };

            await _userService.RegisterUser(registrationForm);

            return new OkResult();
        }

    }
}
