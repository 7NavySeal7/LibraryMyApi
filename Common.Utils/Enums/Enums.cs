using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
    public class Enums
    {
        public enum State
        {
            //Libros
            Nuevo= 1,
            Usado = 2
        }

        public enum TypePermission
        {
            Usuario = 1,
            Roles = 2,
            Permisos = 3,
            Estados = 4,
            Libros = 5,
            Editoriales = 6,
            Autores = 7
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
            ConsultarLibros = 15,            
                
            //Editorial
            CrearEditoriales = 16,
            ActualizarEditoriales = 17,
            EliminarEditoriales = 18,
            ConsultarEditoriales = 19,

            //Autores
            CrearAutores = 20,
            ActualizarAutores = 21,
            EliminarAutores = 22,
            ConsultarAutores = 23
        }

        public enum Rol
        {
            Administrador = 1,
            Estandar = 2 
        }

        public enum TypeBook
        {
            Literatura = 1,
            Programacion = 2,
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
