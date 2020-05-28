using System;
using System.Collections.Generic;
using System.Data;

namespace Solucion
{
    public static class ProductDAO
    {
        public static List<Product> getLista(int idBusiness)
        {
            string sql = String.Format("SELECT p.idProduct, p.name FROM PRODUCT p WHERE idBusiness = {0}", idBusiness);

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Product> lista = new List<Product>();
            foreach (DataRow fila in dt.Rows)
            {
                Product p = new Product();
                p.idProduct = Convert.ToInt32(fila[0]);
                p.name = fila[1].ToString();
                lista.Add(p);
            }
            return lista;
        }
        
        public static void Agregar(int idBusiness, string name)
        {
            string sql = String.Format("INSERT INTO PRODUCT(idBusiness, name)" + "VALUES({0}, '{1}');", idBusiness, name);
            
            Conexion.realizarAccion(sql);
        }

        public static void Eliminar(int idProduct )
        {
            string sql = String.Format(
                "DELETE FROM APPORDER WHERE idProduct = {0}; " +
                "DELETE FROM PRODUCT WHERE idProduct = {0}; ",
                idProduct );
            
            Conexion.realizarAccion(sql);
        }
    }
}