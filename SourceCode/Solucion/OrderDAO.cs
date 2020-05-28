using System;
using System.Collections.Generic;
using System.Data;

namespace Solucion
{
    public static class OrderDAO
    {
        public static List<Order> getLista()
        {
            string sql = String.Format("SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser;");

            DataTable dt = Conexion.realizarConsulta(sql);

            List<Order> lista = new List<Order>();
            foreach (DataRow fila in dt.Rows)
            {
                Order o = new Order();
                o.idOrder = Convert.ToInt32(fila[0]);
                o.createDate = fila[1].ToString();
                o.name = fila[2].ToString();
                o.fullname = fila[3].ToString();
                o.address = fila[4].ToString();
                lista.Add(o);
            }
            return lista;
        }
        public static List<Order> getListaUsuario(int iduser)
                {
                    string sql = String.Format("SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser AND au.idUser = {0};", iduser);
        
                    DataTable dt = Conexion.realizarConsulta(sql);
        
                    List<Order> lista = new List<Order>();
                    foreach (DataRow fila in dt.Rows)
                    {
                        Order o = new Order();
                        o.idOrder = Convert.ToInt32(fila[0]);
                        o.createDate = fila[1].ToString();
                        o.name = fila[2].ToString();
                        o.fullname = fila[3].ToString();
                        o.address = fila[4].ToString();
                        lista.Add(o);
                    }
                    return lista;
                }
  

        public static void Agregar(int idproduct, int address, string date)
        {
            string sql = String.Format("INSERT INTO APPORDER(createDate, idProduct, idAddress)" + "VALUES('{0}', {1},{2});", date, idproduct,address);
            
            Conexion.realizarAccion(sql);
        }

        public static void Eliminar(int idorder)
        {
            string sql = String.Format(
                "DELETE FROM APPORDER WHERE idOrder = {0}; ",
                idorder);
            
            Conexion.realizarAccion(sql);
        }
    }
}