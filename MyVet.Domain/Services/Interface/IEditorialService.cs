using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IEditorialService
    {
        List<EditorialDto> GetAllEditorials();
        Task<bool> InsertEditorialAsync(EditorialDto editorialDto);
        Task<bool> UpdateEditorialAsync(EditorialDto editDto);
        Task<ResponseDto> DeleteEditorialAsync(int idEdit);
    }
}
