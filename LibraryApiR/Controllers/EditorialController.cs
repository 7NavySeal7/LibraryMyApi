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
    [TypeFilter(typeof(CustomExceptionHandler))] // <=Try Catch
    public class EditorialController : ControllerBase
    {
        #region Attribute
        private readonly IEditorialService _editorialService;
        #endregion

        #region Builder
        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }
        #endregion

        /// <summary>
        /// Obtiene todas las Editoriales
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllEditorial")]
        public IActionResult GetAllEditorial()
        {
            List<EditorialDto> list = _editorialService.GetAllEditorials();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Inserta Editoriales
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertEditorial")]
        public async Task<IActionResult> InsertEditorial(EditorialDto editDto)
        {
            IActionResult response;
            bool result = await _editorialService.InsertEditorialAsync(editDto);
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
        /// Actualiza Editoriales
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateEditorial")]
        public async Task<IActionResult> UpdateEditorial(EditorialDto editDto)
        {
            IActionResult response;
            bool result = await _editorialService.UpdateEditorialAsync(editDto);
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
        /// Elimina Editoriales
        /// </summary>
        /// <param name="idEdit"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteEditorial")]
        public async Task<IActionResult> DeleteEditorial(int idEdit)
        {
            IActionResult response;
            ResponseDto result = await _editorialService.DeleteEditorialAsync(idEdit);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }
    }
}
