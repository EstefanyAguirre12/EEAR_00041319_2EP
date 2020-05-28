using System;
using System.Collections.Generic;
using System.Data;

namespace Solucion
{
    public static class UsuarioDAO
    {
         public static List<Usuario> getLista()
        {
            string sql = "SELECT * FROM APPUSER;";

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();
                u.idUser = Convert.ToInt32(fila[0].ToString());
                u.fullname = fila[1].ToString();
                u.username = fila[2].ToString();
                u.password = fila[3].ToString();
                u.userType = fila[4].ToString();

                lista.Add(u);
            }
            return lista;
        }

        public static void ModificarContra(string username, string newcontra)
        {
            string sql = String.Format("UPDATE APPUSER SET password = '{0}' WHERE username = '{1}';", newcontra, username);
            
            Conexion.realizarAccion(sql);
        }

        public static void Agregar(string fullname, string username, string password, bool userType)
        {
            string sql = String.Format("INSERT INTO APPUSER(fullname, username, password, userType)" + "values('{0}', '{1}', '{2}', {3});",
               fullname,username,password,userType );
            
            Conexion.realizarAccion(sql);
        }

        public static void Eliminar(int iduser)
        {
            string sql = String.Format(
                "DELETE FROM ADDRESS WHERE idUser = {0}; " +
                "DELETE FROM APPUSER WHERE idUser ={0};", iduser);
            
            Conexion.realizarAccion(sql);
        }
    }
}