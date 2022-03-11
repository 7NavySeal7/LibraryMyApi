using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using Microsoft.EntityFrameworkCore.Internal;
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
            var books = _unitOfWork.AuthorBookRepository.GetAll(x => x.BookEntity,
                                                                    x =>x.AuthorEntity,
                                                                    x =>x.BookEntity.EditorialEntity,
                                                                    x =>x.BookEntity.TypeBookEntity,
                                                                    x =>x.BookEntity.StateEntity);
          
            List<ConsultBookDto> listBooks = books.Select(x => new ConsultBookDto
            {
                IdAuthorBook = x.IdAuthorBook,
                IdBook = x.BookEntity.IdBook,
                Name = x.BookEntity.Name,
                DateRelease = x.BookEntity.DateRelease,
                Description = x.BookEntity.Description,
                IdEditorial = x.BookEntity.IdEditorial,
                IdTypeBook = x.BookEntity.IdTypeBook,
                IdState = x.BookEntity.IdState,
                IdAuthor = x.AuthorEntity.IdAuthor, 
                NameEditorial = x.BookEntity.EditorialEntity.Editorial,
                NameAuthor = x.AuthorEntity.Name,
                LastNameAuthor = x.AuthorEntity.LastName,
                NameTypeBook = x.BookEntity.TypeBookEntity.TypeBook,
                NameState = x.BookEntity.StateEntity.State,
                StrDateRelease = x.BookEntity.DateRelease == null ? "No disponible" : x.BookEntity.DateRelease.Value.ToString("yyyy-MM-dd")
            }).ToList();

            return listBooks;
        }

        public ConsultBookDto GetBook(int idBook)
        {
            var books = _unitOfWork.AuthorBookRepository.FirstOrDefault(x => x.BookEntity.IdBook == idBook,
                                                                        x => x.BookEntity,
                                                                        x => x.AuthorEntity,
                                                                        x => x.BookEntity.EditorialEntity,
                                                                        x => x.BookEntity.TypeBookEntity,
                                                                        x => x.BookEntity.StateEntity);

            ConsultBookDto listMybooks = new ConsultBookDto()
            {
                IdAuthorBook = books.IdAuthorBook,
                IdBook = books.BookEntity.IdBook,
                Name = books.BookEntity.Name,
                DateRelease = books.BookEntity.DateRelease,
                Description = books.BookEntity.Description,
                IdEditorial = books.BookEntity.IdEditorial,
                IdTypeBook = books.BookEntity.IdTypeBook,
                IdState = books.BookEntity.IdState,
                IdAuthor = books.AuthorEntity.IdAuthor,
                NameEditorial = books.BookEntity.EditorialEntity.Editorial,
                NameAuthor = books.AuthorEntity.Name,
                LastNameAuthor = books.AuthorEntity.LastName,
                NameTypeBook = books.BookEntity.TypeBookEntity.TypeBook,
                NameState = books.BookEntity.StateEntity.State,
                StrDateRelease = books.BookEntity.DateRelease == null ? "No disponible" : books.BookEntity.DateRelease.Value.ToString("yyyy-MM-dd")
            };

            return listMybooks;
        }

        public async Task<bool> InsertBookAsync(InsertBookDto book)
        {
            AuthorBookEntity authBook = new AuthorBookEntity()
            {
                IdAuthor = book.IdAuthor,
                BookEntity = new BookEntity()
                {
                    Name = book.Name,
                    DateRelease = book.DateRelease,
                    Description = book.Description,
                    IdEditorial = book.IdEditorial,
                    IdTypeBook = book.IdTypeBook,
                    IdState = book.IdState
                }
            };
            
            _unitOfWork.AuthorBookRepository.Insert(authBook);

            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateBookAsync(BookDto book)
        {
            bool result = false;

            AuthorBookEntity authBooks =
                _unitOfWork.AuthorBookRepository.FirstOrDefault(x => x.IdAuthorBook == book.IdAuthorBook,
                                                                x => x.BookEntity);

            if (authBooks != null)
            {
                authBooks.IdAuthor = book.IdAuthor;
                authBooks.BookEntity.Name = book.Name;
                authBooks.BookEntity.DateRelease = book.DateRelease;
                authBooks.BookEntity.Description = book.Description;
                authBooks.BookEntity.IdEditorial = book.IdEditorial;
                authBooks.BookEntity.IdTypeBook = book.IdTypeBook;
                authBooks.BookEntity.IdState = book.IdState;

                _unitOfWork.AuthorBookRepository.Update(authBooks);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        public async Task<ResponseDto> DeleteBooksAsync(int idBook)
        {
            ResponseDto response = new ResponseDto();
            var auth = _unitOfWork.AuthorBookRepository.FirstOrDefault(x => x.IdBook == idBook);
            _unitOfWork.AuthorBookRepository.Delete(auth);
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
