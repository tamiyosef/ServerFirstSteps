using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentServer.Models;
using TaskManagmentServer.DTO;

namespace TaskManagmentServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagmentAPIController : ControllerBase
    {
        //a variable to hold a reference to the db context!
        // החזקת המשתנה מסוג CONTEXT 
        // כדי שנוכל לגשת לפונקציות של הקונטקסט - לתקשר עם מסד הנתונים
        private TasksManagementDbContext context;
        //a variable that hold a reference to web hosting interface (that provide information like the folder on which the server runs etc...)
        private IWebHostEnvironment webHostEnvironment;
        //Use dependency injection to get the db context and web host into the constructor

        public TaskManagmentAPIController(TasksManagementDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.webHostEnvironment = env;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] DTO.AppUserDTO userDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                // example for dto and models app user difference
                // int bmi = calculatebmi(userDto.height);
                //Get model user class from DB with matching email. 
                Models.AppUser modelsUser = new AppUser()
                {
                    //UserBmi = bmi,
                    UserName = userDto.UserName,
                    UserLastName = userDto.UserLastName,
                    UserEmail = userDto.UserEmail,
                    UserPassword = userDto.UserPassword,
                    IsManager = userDto.IsManager
                };

                context.AppUsers.Add(modelsUser);
                context.SaveChanges();

                //User was added!
                //This conversion happens in order to get the generated id in the dto object
                DTO.AppUserDTO dtoUser = new DTO.AppUserDTO(modelsUser);
/*                dtoUser.ProfileImagePath = GetProfileImageVirtualPath(dtoUser.Id);*/
                return Ok(dtoUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
