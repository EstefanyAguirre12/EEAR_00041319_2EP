using System;
using System.Collections.Generic;
using System.Data;

namespace Solucion
{
    public static class AddressDAO
    {
        public static List<Address> getLista(int iduser)
        {
            string sql = String.Format("SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE idUser = {0}", iduser);

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Address> lista = new List<Address>();
            foreach (DataRow fila in dt.Rows)
            {
                Address a = new Address();
                a.idAddress = Convert.ToInt32(fila[0]);
                a.address = fila[1].ToString();
                 lista.Add(a);
            }
            return lista;
        }
  

        public static void Agregar(int iduser, string address)
        {
            string sql = String.Format("INSERT INTO ADDRESS(idUser, address)" + "VALUES({0}, '{1}');", iduser, address);
            
            Conexion.realizarAccion(sql);
        }

        public static void Modificar(string address,int idaddres )
        {
            string sql = String.Format(
                "UPDATE ADDRESS SET address = '{0}' WHERE idAddress = {1};",address,idaddres);
            
            Conexion.realizarAccion(sql);
        }

        public static void Eliminar(int idaddress)
        {
            string sql = String.Format(
                "DELETE FROM APPORDER WHERE idAddress = {0}; " +
                "DELETE FROM ADDRESS WHERE idAddress = {0}; ",
                idaddress);
            
            Conexion.realizarAccion(sql);
        }
    }
     
}