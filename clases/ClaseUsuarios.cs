using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerDeReparaciones.clases
{
    public class ClaseUsuarios
    {
        // Variables
        public static int UsuarioID { get; set; }
        public static string Nombre { get; set; }
        public static string CorreoElectronico { get; set; }
        public static string Telefono { get; set; }

        // Constructor
        public ClaseUsuarios(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            UsuarioID = usuarioID;
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
        }

        public ClaseUsuarios() { }

    }
}
