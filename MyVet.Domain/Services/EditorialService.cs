using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class EditorialService: IEditorialService
    {
        #region Attribute
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public EditorialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<EditorialDto> GetAllEditorials()
        {
            var edit = _unitOfWork.EditorialRepository.GetAll().ToList();
            List<EditorialDto> editorial = edit.Select(x=> new EditorialDto
            { 
                IdEditorial = x.IdEditorial,
                Editorial = x.Editorial
            }).ToList();

            return editorial;
        }

        public async Task<bool> InsertEditorialAsync(EditorialDto editDto)
        {
            EditorialEntity edit = new EditorialEntity()
            {
                Editorial = editDto.Editorial
            };

            _unitOfWork.EditorialRepository.Insert(edit);
            return await _unitOfWork.Save() > 0;
        }        
        
        public async Task<bool> UpdateEditorialAsync(EditorialDto editDto)
        {
            bool result = false;

            EditorialEntity edit = _unitOfWork.EditorialRepository.FirstOrDefault(x => x.IdEditorial == editDto.IdEditorial);
            if (edit != null)
            {
                edit.Editorial = editDto.Editorial;

                _unitOfWork.EditorialRepository.Update(edit);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        public async Task<ResponseDto> DeleteEditorialAsync(int idEdit)
        {
            ResponseDto response = new ResponseDto();
            _unitOfWork.EditorialRepository.Delete(idEdit);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente el Libro";
            else
                response.Message = "Hubo un error al eliminar el Libro, por favor vuelva a intentalo";

            return response;
        }
        #endregion

    }
}
