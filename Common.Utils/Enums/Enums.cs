using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
    public class Enums
    {
        public enum TypeState
        {
            //Usuario
            EstadoUsuario = 1,
            //Libro
            EstadoLibro = 2
        }

        public enum State
        {
            //Usuario
            UsuarioActivo = 1,
            UsuarioInactivo = 2,
            UsuarioSuspendido = 3,

            //Libros
            Nuevo= 4,
            Usado = 5
        }

        public enum TypePermission
        {
            Usuario = 1,
            Roles = 2,
            Permisos = 3,
            Estados = 4,
            Libros = 5,
        }

        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,
            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,

            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,

            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,

            //Estados
            ConsultarEstados = 10,
            ActualizarEstados =11,

            //Libros
            CrearLibros = 12,
            ActualizarLibros = 13,
            EliminarLibros = 14,
            ConsultarLibros = 15
        }

        public enum Rol
        {
            Administrador = 1,
            Bibliotecario = 2,
            Estandar = 3 
        }

        public enum TypeBook
        {
            Literatura = 1,
            Fantasia = 2,
            Infantil = 3,
            Juvenil = 4,
            Ciencia = 5,
            Matematicas = 6,
            Salud = 7,
            Gastronomia = 8,
            Ocio = 9,
            Poesia = 10
        }
    }
}
