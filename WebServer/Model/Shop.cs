using System.Collections;

namespace WebServer.Model
{
    public class Shop
    {

        public Shop()
        {
            for (int i = 1; i <= 10; i++) 
            {
                _items.Add(new Item(i, i * 100));
            }
        }

        public string ShowItems()
        {
            string res = "";
            foreach (Item item in _items) 
            {
                res += item.ShowInfo() + '\n';
            }
            return res;
        }

        private List<Item> _items = new List<Item>();
    }
}
