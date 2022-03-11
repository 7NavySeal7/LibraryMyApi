using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IAuthorService
    {
        List<AuthorDto> GetAllAuthors();
        AuthorDto GetAuthor(int idAuthor);
        Task<bool> InsertAuthorAsync(AuthorDto authorDto);
        Task<bool> UpdateAuthorAsync(AuthorDto authorDto);
        Task<ResponseDto> DeleteAuthorAsync(int idAuthor);
    }
}
