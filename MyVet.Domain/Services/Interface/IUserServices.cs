using Infraestructure.Entity.Models;
using MyVet.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IUserServices
    {
        #region Methods Crud
        List<ConsultUserDto> GetAll();

        UserEntity GetUser(int idUser);

        Task<bool> UpdateUser(UserEntity user);

        Task<bool> DeleteUser(int idUser);

        Task<ResponseDto> CreateUser(UserEntity user);
        #endregion

        #region Authentication
        TokenDto Login(LoginDto login);
        Task<ResponseDto> Register(UserDto data);
        #endregion
    }
}