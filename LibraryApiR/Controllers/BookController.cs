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

        /// <summary>
        /// Obtiene todos los libros de la Biblioteca
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        #region Methods
        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);

            List<ConsultBookDto> list = _bookService.GetAllBooks(Convert.ToInt32(idUser));

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
        public async Task<IActionResult> DeleteBooks(int idBook)
        {
            IActionResult response;
            ResponseDto result = await _bookService.DeleteBooksAsync(idBook);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }


        /// <summary>
        /// Insertar mis Libros
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertMyBooks")]
        public async Task<IActionResult> InsertMyBooks(int idBook)
        {
            IActionResult response;

            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);

            bool result = await _bookService.InsertMyBooksAsync(Convert.ToInt32(idBook), Convert.ToInt32(idUser));

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

            return Ok(response);
        }

        //[HttpGet]
        //public IActionResult GetAllMyDates()
        //{
        //    var user = HttpContext.User;
        //    string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;

        //    List<DatesDto> result = _datesServices.GetAllMyDates(Convert.ToInt32(idUser));
        //    return Ok(result);
        //}


        //[HttpPut]
        //public async Task<IActionResult> UpdateDates(DatesDto dates)
        //{
        //    bool result = await _datesServices.UpdateDatesAsync(dates);
        //    return Ok(result);
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteDates(int idDates)
        //{
        //    ResponseDto result = await _datesServices.DeleteDatesAsync(idDates);
        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> CancelDates(int idDates)
        //{
        //    bool result = await _datesServices.CancelDatesAsync(idDates, idUserVet: null);
        //    return Ok(result);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateDatesVet(DatesDto dates)
        //{
        //    var user = HttpContext.User;
        //    string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;
        //    dates.IdUserVet = Convert.ToInt32(idUser);

        //    bool result = await _datesServices.UpdateDatesVetAsync(dates);
        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> CancelDatesVet(int idDates)
        //{
        //    var user = HttpContext.User;
        //    string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;

        //    bool result = await _datesServices.CancelDatesAsync(idDates, Convert.ToInt32(idUser));
        //    return Ok(result);
        //}

        #endregion
    }
}
