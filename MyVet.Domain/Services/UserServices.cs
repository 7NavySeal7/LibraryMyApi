 using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils.Helpers;
using static Common.Utils.Enums.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Common.Utils.Constant.Const;
using Common.Utils.Exceptions;
using Common.Utils.Resources;

namespace MyVet.Domain.Services
{
    public class UserServices : IUserServices
    {
        #region Attribute
        //atributo--Interfaz de solo lectura
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        #endregion

        #region Builder
        //El constructor recibe la instacia de unitOfWork por medio de la interfaz
        public UserServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork; //Le pasamos el valor de esa instancia a atributo global.
            _configuration = configuration;
        }
        #endregion

        #region Authentication
        public TokenDto Login(LoginDto login)
        {
            //Con esto verificamos la similitud de contraseña y usuario
            UserEntity resultUser = _unitOfWork.UserRepository.FirstOrDefault(x => x.Email == login.UserName 
                                                                            && x.Password == login.Password,
                                                                            r=>r.RolUserEntities);
            if (resultUser == null)
                throw new BusinessException(GeneralMessages.BadCredentials);

            //TOKEN
            return GenerateTokenJWT(resultUser);
        }

        //Generación de Token
        public TokenDto GenerateTokenJWT(UserEntity userEntity)
        {
            //Aqui estoy llamando la configuracion que tengo en el appsettings.
            IConfigurationSection tokenAppSetting = _configuration.GetSection("Tokens");

            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenAppSetting.GetSection("Key").Value));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(TypeClaims.IdUser,userEntity.IdUser.ToString()),
                new Claim(TypeClaims.UserName,userEntity.FullName),
                new Claim(TypeClaims.Email,userEntity.Email),
                new Claim(TypeClaims.IdRol,string.Join(",",userEntity.RolUserEntities.Select(x=>x.IdRol))),
            };

            //Payload Cuerpo del Token
            var _payload = new JwtPayload(
                    issuer: tokenAppSetting.GetSection("Issuer").Value,
                    audience: tokenAppSetting.GetSection("Audience").Value,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(60)
                );

            var _token = new JwtSecurityToken(
                    _header,
                    _payload
                );

            TokenDto token = new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(_token),
                Expiration = Utils.ConvertToUnixTimestamp(_token.ValidTo),
            };
            return token;
        }

        #endregion

        #region Methods Crud
        //Esta función sirve para devolverme una lista de usuarios
        //El metodo GetAll es del repositorio
        //El UserRepository es de la unidad de trabajo
        public List<ConsultUserDto> GetAll()
        {
            var user = _unitOfWork.RolUserRepository.GetAll(x => x.RolEntity, x =>x.UserEntity);

            List<ConsultUserDto> listBooks = user.Select(x => new ConsultUserDto
            {
                IdUser = x.UserEntity.IdUser,
                Name = x.UserEntity.Name,
                NameRol = x.RolEntity.Rol,
                LastName = x.UserEntity.LastName,
                UserName = x.UserEntity.Email,
                Password = "Oculto",
                ConfirmPassword = "Oculto"
            }).ToList();

            return listBooks;
        }

        //Esta función sirve para traerme un usuario especifico
        public UserEntity GetUser(int idUser)
        {
            return _unitOfWork.UserRepository.FirstOrDefault(x => x.IdUser == idUser);
        }

        public async Task<bool> UpdateUser(UserEntity user)
        {
            //Esto sirve para consultar el usuario
            UserEntity _user = GetUser(user.IdUser);

            _user.Name = user.Name;
            _user.LastName = user.LastName;
            _unitOfWork.UserRepository.Update(_user);

            return await _unitOfWork.Save() > 0;
            //return _unitOfWork.UserRepository.FirstOrDefault(x=>x.IdUser == idUser);
        }

        public async Task<bool> DeleteUser(int idUser)
        {
            //Con el patron repositorio tenemos un delete
            _unitOfWork.UserRepository.Delete(idUser);
            //El metodo save proviene de la unidad de trabajo
            return await _unitOfWork.Save() > 0;
        }

        public async Task<ResponseDto> CreateUser(UserEntity data)
        {
            ResponseDto result = new ResponseDto();

            //Esta condicional me devuelve un booleano, según la validación que se realize en utils.
            if (Utils.ValidateEmail(data.Email))
            {
                //Si es igual a nulo significa que no hay nigún otro email.
                if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.Email) == null)
                {
                    int idRol = data.IdUser;
                    data.Password = "1234";
                    data.IdUser = 0;
                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdRol = idRol,
                        UserEntity = data
                    };
                    _unitOfWork.RolUserRepository.Insert(rolUser);
                    result.IsSuccess = await _unitOfWork.Save() > 0;
                }
                else
                {
                    result.Message = "Email ya se encuentra registrado, utilizar otro!";
                }
            }
            else
            {
                result.Message = "Usuario con Email inválido";
            }
            // _unitOfWork.UserRepository.Update(_user);
            return result;
            //return _unitOfWork.UserRepository.FirstOrDefault(x=>x.IdUser == idUser);
        }

        public async Task<ResponseDto> Register(UserDto data)
        {
            ResponseDto result = new ResponseDto();

            //Esta condicional me devuelve un booleano, según la validación que se realize en utils.
            if (Utils.ValidateEmail(data.UserName))
            {
                //Si es igual a nulo significa que no hay nigún otro email.
                if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.UserName) == null)
                {

                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdRol = Rol.Estandar.GetHashCode(),
                        UserEntity = new UserEntity()
                        {
                            Email = data.UserName,
                            LastName = data.LastName,
                            Name = data.Name,
                            Password = data.Password
                        }
                    };

                    _unitOfWork.RolUserRepository.Insert(rolUser);
                    result.IsSuccess = await _unitOfWork.Save() > 0;
                }
                else
                    result.Message = "Email ya se encuestra registrado, utilizar otro!";
            }
            else
            {
                result.Message = "Usuarioc con Email Inválido";
            }
            return result;
        }
        #endregion
    }
}