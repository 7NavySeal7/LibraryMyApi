using Infraestructure.Core.UnitOfWork.Interface;
using MyVet.Domain.Dto.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyVet.Domain.Services
{
    public class AdminService
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<AdminDto> GetAllPermission()
        {
            var admin = _unitOfWork.RolUserRepository.GetAll();

            List<AdminDto> listBooks = admin.Select(x => new AdminDto
            {
                
            }).ToList();

            return listBooks;
        }
        #endregion
    }
}
