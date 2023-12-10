using System.Collections;

namespace WebServer.Model
{
    public class Item
    {

        public Item(int id, int price)
        {
            this.Id = id;
            this.Price = price;
        }

        public string ShowInfo()
        {
            return $"아이템 Id : {Id}  아이템 가격 : {Price}\n";
        }

        public int Id { get; set; }

        public int Price { get; set; }
    }
}
