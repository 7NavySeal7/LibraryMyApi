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
    public class BookService: IBookService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<ConsultBookDto> GetAllBooks()
        {
            var books = _unitOfWork.BookRepository.GetAll(p=>p.EditorialEntity,
                                                            p=>p.AuthorEntity,
                                                            p=>p.TypeBookEntity,
                                                            p=>p.StateEntity);

            List<ConsultBookDto> listBooks = books.Select(x => new ConsultBookDto
            {
                IdBook = x.IdBook,
                Name = x.Name,
                DateRelease = x.DateRelease,
                Description = x.Description,
                IdEditorial = x.IdEditorial,
                IdAuthor = x.IdAuthor,
                IdTypeBook = x.IdTypeBook,
                IdState = x.IdState,
                NameEditorial = x.EditorialEntity.Editorial,
                NameAuthor = x.AuthorEntity.NameAuthor,
                NameTypeBook = x.TypeBookEntity.TypeBook,
                NameState = x.StateEntity.State,
                StrDateRelease = x.DateRelease == null ? "No disponible" : x.DateRelease.Value.ToString("yyyy-MM-dd")
            }).ToList();

            return listBooks;
        }

        public ConsultBookDto GetBook(int idBook)
        {
            var books = _unitOfWork.BookRepository.FirstOrDefault(x => x.IdBook == idBook,
                                                                    p => p.EditorialEntity,
                                                                    p => p.AuthorEntity,
                                                                    p => p.TypeBookEntity,
                                                                    p => p.StateEntity);


            ConsultBookDto listMybooks = new ConsultBookDto()
            {
                IdBook = books.IdBook,
                Name = books.Name,
                DateRelease = books.DateRelease,
                Description = books.Description,
                IdEditorial = books.IdEditorial,
                IdAuthor = books.IdAuthor,
                IdTypeBook = books.IdTypeBook,
                IdState = books.IdState,
                NameEditorial = books.EditorialEntity.Editorial,
                NameAuthor = books.AuthorEntity.NameAuthor,
                NameTypeBook = books.TypeBookEntity.TypeBook,
                NameState = books.StateEntity.State,
                StrDateRelease = books.DateRelease == null ? "No disponible" : books.DateRelease.Value.ToString("yyyy-MM-dd")
            };

            return listMybooks;
        }

        public async Task<bool> InsertBookAsync(InsertBookDto book)
        {
            BookEntity books = new BookEntity()
            {
                Name = book.Name,
                DateRelease = book.DateRelease,
                Description = book.Description,
                IdEditorial = book.IdEditorial,
                IdAuthor = book.IdAuthor,
                IdTypeBook = book.IdTypeBook,
                IdState = book.IdState
            };
            _unitOfWork.BookRepository.Insert(books);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateBookAsync(BookDto book)
        {
            bool result = false;

            BookEntity books = _unitOfWork.BookRepository.FirstOrDefault(x => x.IdBook == book.IdBook);
            if (books != null)
            {
                books.Name = book.Name;
                books.DateRelease = book.DateRelease;
                books.Description = book.Description;
                books.IdAuthor = book.IdAuthor;
                books.IdTypeBook = book.IdTypeBook;
                books.IdState = book.IdState;

                _unitOfWork.BookRepository.Update(books);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        public async Task<ResponseDto> DeleteBooksAsync(int idBook)
        {
            ResponseDto response = new ResponseDto();
            _unitOfWork.BookRepository.Delete(idBook);
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
