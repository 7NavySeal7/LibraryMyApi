using Common.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Services.Interface
{
    public interface IPermissionServices
    {
        bool ValidatePermissionByUser(Enums.Permission permission, int idUser);
    }
}
