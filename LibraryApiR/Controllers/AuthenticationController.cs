using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApiR.Handlers;

namespace LibraryApiR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AuthenticationController : ControllerBase
    {
        #region Attribute
        private readonly IUserServices _userServices; 
        #endregion

        #region Builder
        public AuthenticationController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "userName": "useradmin",
        ///        "password": "123456"
        ///     }
        ///
        /// </remarks>
        /// <param name="login"></param>
        /// <returns> Token</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Business Exception</response>
        /// <response code="401">User unauthorized</response>
        /// <response code="500">Oops! </response>
        [HttpPost]
        [Route("Login")] //=>Enruto a la accion o controlador login
        public IActionResult Login(LoginDto login)
        {
            TokenDto result = _userServices.Login(login);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };

            return Ok(response);
        }

        #endregion
    }
}
