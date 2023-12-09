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
                res += item.ShowInfo();
            }
            return res;
        }

        public int GetItemPrice(int idx)
        {
            if (idx < 0 || idx >= _items.Count())
            {
                return -1;
            }
            return _items[idx].Price;

        }

        public Item GetItem(int idx)
        {
            if (idx < 0 || idx >= _items.Count())
            {
                return null;
            }
            return _items[idx];

        }

        private List<Item> _items = new List<Item>();
    }
}
