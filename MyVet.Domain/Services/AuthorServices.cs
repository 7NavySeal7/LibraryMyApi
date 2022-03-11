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
    public class AuthorServices: IAuthorService
    {
        #region Atributtes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public AuthorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<AuthorDto> GetAllAuthors()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll();

            List<AuthorDto> listAuthors = authors.Select(x => new AuthorDto
            {
                IdAuthor = x.IdAuthor,
                NameAuthor = x.Name,
                LastNameAuthor = x.LastName
            }).ToList();

            return listAuthors;
        }

        public AuthorDto GetAuthor(int idAuthor)
        {
            var author = _unitOfWork.AuthorRepository.FirstOrDefault(x =>x.IdAuthor == idAuthor);

            AuthorDto authors = new AuthorDto()
            {
                IdAuthor = author.IdAuthor,
                NameAuthor = author.Name,
                LastNameAuthor = author.LastName
            };

            return authors;
        }

        public async Task<bool> InsertAuthorAsync(AuthorDto authorDto)
        {
            AuthorEntity author = new AuthorEntity()
            {
                Name = authorDto.NameAuthor,
                LastName = authorDto.LastNameAuthor
            };

            _unitOfWork.AuthorRepository.Insert(author);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateAuthorAsync(AuthorDto authorDto)
        {
            bool result = false;
            AuthorEntity author = _unitOfWork.AuthorRepository.FirstOrDefault(x => x.IdAuthor == authorDto.IdAuthor);
            if (author != null)
            {
                author.Name = authorDto.NameAuthor;
                author.LastName = authorDto.LastNameAuthor;

                _unitOfWork.AuthorRepository.Update(author);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }

        public async Task<ResponseDto> DeleteAuthorAsync(int idAuthor) 
        {
            ResponseDto response = new ResponseDto();
            _unitOfWork.AuthorRepository.Delete(idAuthor);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente el autor";
            else
                response.Message = "Hubo un error al eliminar el autor, por favor vuelva a intentalo";

            return response;
        }
        #endregion

    }
}
