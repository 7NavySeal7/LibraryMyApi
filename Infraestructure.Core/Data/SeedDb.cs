﻿using Common.Utils.Enums;
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
            //await CheckRolAsync();
            await CheckRolPermissionAsync();
            //await CheckTypeBookAsync();
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
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        TypeState="Estado de Usuarios"
                    },                    
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoLibro,
                        TypeState="Estado del Libro"
                    },
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
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioActivo,
                        State="Activo"
                    },                    
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioInactivo,
                        State="Inactivo"
                    },                      
                    new StateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.EstadoUsuario,
                        IdState=(int)Enums.State.UsuarioSuspendido,
                        State="Suspendido"
                    },           
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
                        Description="Consultar los estados de los libros"
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
                });
                await _context.SaveChangesAsync();
            }
        }

        #region Roles
        //Roles
        //private async Task CheckRolAsync()
        //{
        //    if (_context.RolEntity.Any())
        //    {
        //        _context.RolEntity.AddRange(new List<RolEntity>
        //        {
        //            new RolEntity
        //            {
        //                IdRol=(int)Enums.Rol.Administrador,
        //                Rol="Administrador"
        //            },
        //            new RolEntity
        //            {
        //                IdRol=(int)Enums.Rol.Bibliotecario,
        //                Rol="Bibliotecario"
        //            },
        //            new RolEntity
        //            {
        //                IdRol=(int)Enums.Rol.Estandar,
        //                Rol="Estandar"
        //            },
        //        });
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //RolPermisos 
        #endregion

        //Tipos de Libros
        //private async Task CheckTypeBookAsync()
        //{
        //    if (!_context.TypeBookEntity.Any())
        //    {
        //        _context.TypeBookEntity.AddRange(new List<TypeBookEntity>
        //        {
        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Literatura,
        //                TypeBook="Literatura"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Fantasia,
        //                TypeBook="Fantasia"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Infantil,
        //                TypeBook="Infantil"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Juvenil,
        //                TypeBook="Juvenil"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Ciencia,
        //                TypeBook="Ciencia"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Matematicas,
        //                TypeBook="Matematicas"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Salud,
        //                TypeBook="Salud"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Gastronomia,
        //                TypeBook="Gastronomia"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Gastronomia,
        //                TypeBook="Gastronomia"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Ocio,
        //                TypeBook="Ocio"
        //            },

        //            new TypeBookEntity
        //            {
        //                IdTypeBook=(int)Enums.TypeBook.Poesia,
        //                TypeBook="Poesia"
        //            },
        //        });

        //        await _context.SaveChangesAsync();
        //    }
        //}
        private async Task CheckRolPermissionAsync()
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
    }
}
