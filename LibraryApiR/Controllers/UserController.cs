using Common.Utils.Enums;
using LibraryApiR.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApiR.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : ControllerBase
    {
        #region Attributes
        private readonly IUserServices _userServices;
        #endregion
        #region Builder
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region Controller
        /// <summary>
        /// Muestra todos los usuarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllUsers")]
        [CustomPermissionFilter(Enums.Permission.ConsultarUsuarios)]
        public IActionResult GetAllUsers()
        {
            List<ConsultUserDto> list = _userServices.GetAll();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }
        #endregion
    }
}
