using Common.Utils.Enums;
using Common.Utils.Resources;
using LibraryApiR.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
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
    public class AuthorController : ControllerBase
    {
        #region Attributes
        private readonly IAuthorService _authorService;
        #endregion

        #region Builder
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Insertar Autores
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllAuthors")]
        [CustomPermissionFilter(Enums.Permission.ConsultarAutores)]
        public IActionResult GetAllAuthors()
        {
            List<AuthorDto> list = _authorService.GetAllAuthors();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }

        /// <summary>
        /// Traer un solo Autor
        /// </summary>
        /// <param name="idAuthor"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAuthor")]
        [CustomPermissionFilter(Enums.Permission.ConsultarLibros)]
        public IActionResult GetAuthor(int idAuthor)
        {
            AuthorDto list = _authorService.GetAuthor(idAuthor);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };
            return Ok(response);
        }


        /// <summary>
        /// Insert Autores
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertAuthors")]
        [CustomPermissionFilter(Enums.Permission.CrearAutores)]
        public async Task<IActionResult> InsertAuthors(AuthorDto author)
        {
            IActionResult response;
            bool result = await _authorService.InsertAuthorAsync(author);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }


        /// <summary>
        /// Actualizar Autores
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateAuthors")]
        [CustomPermissionFilter(Enums.Permission.ActualizarAutores)]
        public async Task<IActionResult> UpdateAuthors(AuthorDto author)
        {
            IActionResult response;
            bool result = await _authorService.UpdateAuthorAsync(author);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }


        /// <summary>
        /// Eliminar Autores
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteAuthors")]
        [CustomPermissionFilter(Enums.Permission.EliminarAutores)]
        public async Task<IActionResult> DeleteAuthors(int authors)
        {
            IActionResult response;
            ResponseDto result = await _authorService.DeleteAuthorAsync(authors);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }
        #endregion
    }
}
