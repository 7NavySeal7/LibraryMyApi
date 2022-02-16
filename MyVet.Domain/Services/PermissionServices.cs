using Common.Utils.Enums;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyVet.Domain.Services
{
    public class PermissionServices: IPermissionServices
    {
        #region Attribute
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        #region Builder
        public PermissionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public bool ValidatePermissionByUser(Enums.Permission permission, int idUser)
        {
            RolUserEntity result = _unitOfWork.RolUserRepository.FirstOrDefault(X => X.idUser == idUser
                                                                        && X.RolEntity.RolPermissionEntities
                                                                            .Any(p => p.IdPermission == permission.GetHashCode()));

            return result != null;
        }
        #endregion
    }
}
