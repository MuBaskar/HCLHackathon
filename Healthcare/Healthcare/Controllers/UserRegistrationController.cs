using DBRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {

        //private readonly IUserRepository _repositoryFactory;

        //public UserController(IRepositoryFactory repositoryFactory)
        //{
        //    _repositoryFactory = repositoryFactory;
        //}

        //[HttpPost]
        //public async Task<ActionResult> AddUser(User user)
        //{
        //    var repository = _repositoryFactory.CreateUserRepository();
        //    await repository.AddUser(user);
        //    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        //}

    }
}
