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
        List<ConsultBookDto> GetAllBooks(int idUser);
        List<ConsultBookDto> GetAllMyBooks(int idUser);
        Task<bool> InsertBookAsync(InsertBookDto book);
        Task<bool> InsertMyBooksAsync(int idBook, int idUser);
        Task<bool> UpdateBookAsync(BookDto book);
        Task<ResponseDto> DeleteBooksAsync(int idBook);
    }
}
