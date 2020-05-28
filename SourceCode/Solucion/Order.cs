namespace Solucion
{
    public class Order
    {
        public int idOrder  { get; set; }
        public string createDate  { get; set; }
        public string name  { get; set; }
        public string address  { get; set; }
        public string fullname  { get; set; }

        public Order(){
            idOrder=0;
            createDate = "";
            name = "";
            address = "";
            fullname = "";
        }
    }
}