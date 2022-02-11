using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Models;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<UserEntity> UserRepository { get; }

        IRepository<RolEntity> RolRepository { get; }

        IRepository<RolUserEntity> RolUserRepository { get; }

        IRepository<StateEntity> StateRepository { get; }

        IRepository<TypeStateEntity> TypeStateRepository { get; }

        IRepository<PermissionEntity> PermissionRepository { get; }

        IRepository<TypePermissionEntity> TypePermissionRepository { get; }

        IRepository<RolPermissionEntity> RolesPermissionRepository { get; }

        IRepository<AuthorEntity> AuthorRepository { get; }

        IRepository<BookEntity> BookRepository { get; }

        IRepository<TypeBookEntity> TypeBookRepository { get; }

        IRepository<UserBookEntity> UserBookRepository { get; }


        void Dispose();

        Task<int> Save();
    }
}