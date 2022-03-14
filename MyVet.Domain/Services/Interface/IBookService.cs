using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IBookService
    {
        List<ConsultBookDto> GetAllBooks();
        List<TypeBookDto> GetAllTypeBooks();
        List<StateDto> GetAllState();
        ConsultBookDto GetBook(int idBook);
        Task<bool> InsertBookAsync(InsertBookDto book);
        Task<bool> UpdateBookAsync(BookDto book);
        Task<ResponseDto> DeleteBooksAsync(int idBook);
    }
}
