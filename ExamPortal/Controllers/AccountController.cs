using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ExamPortal.Data.Users;
using ExamPortal.IRepository;
using ExamPortal.Models.Users;
using ExamPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(UserManager<User> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _unitOfWork = unitOfWork;
        }

        #region GetUser

        [Authorize]
        [HttpGet]
        [Route("info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            try
            {
                User user = await GetCurrentUser();
                var userDTO = _mapper.Map<UserDTO>(user);
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentUserInfo)}");
                return Problem($"Something Went Wrong in the {nameof(GetCurrentUserInfo)}", statusCode: 500);
            }
        }

        [Authorize(Roles = "Administrator,SuperAdministrator")]
        [HttpGet]
        [Route("/api/Admin/{userId:guid}/info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserInfo([FromRoute] Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _unitOfWork.Users.Get(x => x.Id == userId.ToString());
                var userDTO = _mapper.Map<UserDTO>(user);
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCurrentUserInfo)}");
                return Problem($"Something Went Wrong in the {nameof(GetCurrentUserInfo)}", statusCode: 500);
            }
        }

        #endregion

        #region Register

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRoleAsync(user, "User");

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [Authorize(Roles = "SuperAdministrator")]
        [HttpPost]
        [Route("/api/Admin/AdminRegister")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDTO userDTO)
        {
            _logger.LogInformation($"Admin registration Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRoleAsync(user, "Administrator");

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        #endregion

        #region Login

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new { Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }

        #endregion

        #region UpdateUser

        [Authorize]
        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCurrentUser([FromBody] UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                User user = await GetCurrentUser();
                UpdateUserInfo(userDTO, user);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateCurrentUser)}");
                return Problem($"Something Went Wrong in the {nameof(UpdateCurrentUser)}", statusCode: 500);
            }
        }

        [Authorize(Roles = "SuperAdministrator,Administrator")]
        [HttpPut]
        [Route("/api/Admin/update/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _unitOfWork.Users.Get(x => x.Id == userId.ToString());
                UpdateUserInfo(userDTO, user);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateUser)}");
                return Problem($"Something Went Wrong in the {nameof(UpdateUser)}", statusCode: 500);
            }
        }
        #endregion

        #region updatePassword

        [Authorize]
        [HttpPut]
        [Route("updatePassword")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePasswordCurrentUser([FromBody] UpdateUserPasswordDTO passwordDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                User user = await GetCurrentUser();
                var result = await _userManager.ChangePasswordAsync(user, passwordDTO.CurrentPassword, passwordDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdatePasswordCurrentUser)}");
                return Problem($"Something Went Wrong in the {nameof(UpdatePasswordCurrentUser)}", statusCode: 500);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("/api/Admin/update/{userId:guid}/password")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePasswordForUser([FromRoute] Guid userId, [FromBody] PasswordDTO passwordDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _unitOfWork.Users.Get(x => x.Id == userId.ToString());
                var result = await _userManager.RemovePasswordAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                var result2 = await _userManager.AddPasswordAsync(user, passwordDTO.Password);
                if (!result2.Succeeded)
                {
                    foreach (var error in result2.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdatePasswordForUser)}");
                return Problem($"Something Went Wrong in the {nameof(UpdatePasswordForUser)}", statusCode: 500);
            }
        }

        #endregion

        private async Task<User> GetCurrentUser()
        {
            var currentUser = User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userManager.FindByNameAsync(currentUserName);
            return user;
        }

        private void UpdateUserInfo(UpdateUserDTO userDTO, User user)
        {
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.StudentInfo.Index = userDTO.StudentInfo.Index;
            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();
        }
    }
}
