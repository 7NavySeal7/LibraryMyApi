using Common.Utils.Enums;
using Infraestructure.Entity.Models;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //Comando para asegurarse que la base de datos este creada.
            await CheckTypeStateAsync();
            await CheckStateAsync();
            await CheckTypePermissionAsync();
            await CheckPermissionAsync();
            await CheckRolAsync();
            await CheckRolPermissonAsync();
            await CheckTypeBookAsync();
            await CheckAuthorsAsync();
            await CheckEditorialsAsync();
            await CheckUsersAsync();
        }

        //Tipos de Estados
        private async Task CheckTypeStateAsync()
        {
            if (!_context.TypeStateEntity.Any())
            {
                _context.TypeStateEntity.AddRange(new List<TypeStateEntity>
                {
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoLibro,
                        TypeState="Estado del Libro"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        //Estados
        private async Task CheckStateAsync()
        {
            if (!_context.StateEntity.Any())
            {
                _context.StateEntity.AddRange(new List<StateEntity>
                {        
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoLibro,
                        IdState=(int)Enums.State.Nuevo,
                        State="Libro Nuevo"
                    },                     
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoLibro,
                        IdState=(int)Enums.State.Usado,
                        State="Libro Usado"
                    },                     
                });

                await _context.SaveChangesAsync();
            }
        }

        //Tipos de Permisos
        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())//Si la tabla esta vacia y la condicion es verdadera se insertan los registros
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        TypePermission="Usuarios"
                    },

                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"
                    },                    
                    
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"
                    },                 
                    
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        TypePermission="Estados"
                    },                    
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        TypePermission="Libros"
                    },                    
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        TypePermission="Editoriales"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        //Permisos
        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    //Usuarios
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Crear Usuarios",
                        Description="Crear Usuarios al Sistemas"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un usuarios en el sistema"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuario del sistema"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Consultar Usuarios",
                        Description="Consulta todos los usuarios"
                    },

                    //Roles
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de los roles en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },

                    //Permisos
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un permiso en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar Permisos",
                        Description="Denegar Permisos a un rol del sistema"
                    },

                    //Estados
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Consultar Estado",
                        Description="Consultar los estados del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Actualizar Estado",
                        Description="Actualizar los estados del sistema"
                    },

                    //Libros
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Consultar Libros",
                        Description="Crear los estados de los libros"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Actualizar Libros",
                        Description="Actualizar los estados de los libros"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Eliminar Libros",
                        Description="Eliminar los estados de los libros"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Consultar Libros",
                        Description="Consultar los estados de los libros"
                    },

                    //Editoriales
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Crear Editoriales",
                        Description="Crear los estados de las editoriales"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Actualizar Editoriales",
                        Description="Actualizar los estados de las editoriales"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Eliminar Editoriales",
                        Description="Eliminar los estados de las editoriales"
                    },                    
                    
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Consultar Editoriales",
                        Description="Consultar los estados de las editoriales"
                    },
                });
                await _context.SaveChangesAsync();
            }
        }

        //Roles
        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        IdRol=(int) Enums.Rol.Administrador,
                        Rol= "Administrador"
                    },
                    new RolEntity
                    {
                        IdRol=(int) Enums.Rol.Bibliotecario,
                        Rol= "Bibliotecario"
                    },
                    new RolEntity
                    {
                        IdRol = (int)Enums.Rol.Estandar,
                        Rol = "Estandar"
                    },
                });
                await _context.SaveChangesAsync();
            }
        }

        //Roles Permisos
        private async Task CheckRolPermissonAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.Rol.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.Rol.Administrador,
                    IdPermission = x.IdPermission
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);
                await _context.SaveChangesAsync();
            }
        }

        //Tipos de Libros
        private async Task CheckTypeBookAsync()
        {
            if (!_context.TypeBookEntity.Any())
            {
                _context.TypeBookEntity.AddRange(new List<TypeBookEntity>
                {
                    new TypeBookEntity
                    {
                        TypeBook="Literatura"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Fantasia"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Infantil"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Juvenil"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Ciencia"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Matematicas"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Salud"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Gastronomia"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Ocio"
                    },

                    new TypeBookEntity
                    {
                        TypeBook="Poesia"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        //Lista de autores
        private async Task CheckAuthorsAsync()
        {
            if (!_context.AuthorEntity.Any())
            {
                _context.AuthorEntity.AddRange(new List<AuthorEntity>
                {
                    new AuthorEntity
                    {
                        NameAuthor = "Michael Abrash"
                    },

                    new AuthorEntity
                    {
                        NameAuthor = "Eric Allman"
                    },

                    new AuthorEntity
                    {
                        NameAuthor = "Paul Allen"
                    },

                    new AuthorEntity
                    {
                        NameAuthor = "Tarn Adams"
                    },
                }) ;

                await _context.SaveChangesAsync();
            }
        }

        //Lista de editoriales
        private async Task CheckEditorialsAsync()
        {
            if (!_context.EditorialEntity.Any())
            {
                _context.EditorialEntity.AddRange(new List<EditorialEntity>
                {
                    new EditorialEntity
                    {
                        Editorial = "Paenza"
                    },

                    new EditorialEntity
                    {
                        Editorial = "Edicions"
                    },

                    new EditorialEntity
                    {
                        Editorial = "Users"
                    },

                    new EditorialEntity
                    {
                        Editorial = "Atalanta"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        //Lista de Usuarios
        private async Task CheckUsersAsync()
        {
            if (!_context.UserEntity.Any())
            {
                _context.UserEntity.AddRange(new List<UserEntity>
                {
                    new UserEntity
                    {
                        Name = "Juan",
                        LastName = "Montenegro",
                        Email = "juan@gmail.com",
                        Password = "1234"
                    },

                    new UserEntity
                    {
                        Name = "Jorge",
                        LastName = "Montenegro",
                        Email = "jorge@gmail.com",
                        Password = "1234"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }
    }

}
