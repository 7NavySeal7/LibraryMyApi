using Common.Utils.Helpers;
using Common.Utils.Resources;
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
using LibraryApiR.Handlers;
using static Common.Utils.Constant.Const;
using Common.Utils.Enums;

namespace LibraryApiR.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class BookController : ControllerBase
    {
        #region Attributes
        private readonly IBookService _bookService;
        #endregion

        #region Builder
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Obtiene todos los libros de la Biblioteca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllBooks")]
        [CustomPermissionFilter(Enums.Permission.ConsultarLibros)]
        public IActionResult GetAllBooks()
        {
            List<ConsultBookDto> list = _bookService.GetAllBooks();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };
            return Ok(response);
        }


        /// <summary>
        /// Obtiene todos los Tipos de estado del libro
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllTypeBooks")]
        [CustomPermissionFilter(Enums.Permission.ConsultarLibros)]
        public IActionResult GetAllTypeBooks()
        {
            List<TypeBookDto> list = _bookService.GetAllTypeBooks();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };
            return Ok(response);
        }


        /// <summary>
        /// Obtiene todos los Estados
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllState")]
        [CustomPermissionFilter(Enums.Permission.ConsultarLibros)]
        public IActionResult GetAllState()
        {
            List<StateDto> list = _bookService.GetAllState();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Obtiene solo un Libro
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetBook")]
        [CustomPermissionFilter(Enums.Permission.ConsultarLibros)]
        public IActionResult GetBook(int idBook)
        {
            ConsultBookDto list = _bookService.GetBook(idBook);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Insertar Libros
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertBooks")]
        [CustomPermissionFilter(Enums.Permission.CrearLibros)]
        public async Task<IActionResult> InsertBooks(InsertBookDto book)
        {
            //Bandera =>Tipo de respuesta que vamos a usar
            IActionResult response;
            bool result = await _bookService.InsertBookAsync(book);
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
        /// Actualizar Libros
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateBooks")]
        [CustomPermissionFilter(Enums.Permission.ActualizarLibros)]
        public async Task<IActionResult> UpdateBooks(BookDto book)
        {
            IActionResult response;
            bool result = await _bookService.UpdateBookAsync(book);
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
        /// Eliminar Libros
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteBooks")]
        [CustomPermissionFilter(Enums.Permission.EliminarLibros)]
        public async Task<IActionResult> DeleteBooks(int idBook)
        {
            IActionResult response;
            ResponseDto result = await _bookService.DeleteBooksAsync(idBook);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return response;
        }
        #endregion
    }
}
