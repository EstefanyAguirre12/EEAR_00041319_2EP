using System;
using System.Collections.Generic;
using System.Data;

namespace Solucion
{
    public static class BusinessDAO
    {
        public static List<Business> getLista()
        {
            string sql = String.Format("SELECT * FROM BUSINESS");

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Business> lista = new List<Business>();
            foreach (DataRow fila in dt.Rows)
            {
                Business b = new Business();
                b.idBusiness = Convert.ToInt32(fila[0]);
                b.name = fila[1].ToString();
                b.description = fila[2].ToString();
                lista.Add(b);
            }
            return lista;
        }
  

        public static void Agregar(string name, string des)
        {
            string sql = String.Format("INSERT INTO BUSINESS(name, description)" + "VALUES('{0}', '{1}');", name, des);
            
            Conexion.realizarAccion(sql);
        }

        public static void Eliminar(int idBusiness)
        {
            string sql = String.Format(
                "DELETE FROM PRODUCT WHERE idBusiness = {0}; " +
                "DELETE FROM BUSINESS WHERE idBusiness = {0}; ",
                idBusiness);
            
            Conexion.realizarAccion(sql);
        }
    }
}