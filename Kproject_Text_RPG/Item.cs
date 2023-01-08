using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public  class Item
    {


        ItemData itemdata;

       
        public Item(ItemData data)
        {
            this.itemdata = data;
            
          
        }

        public int GetID()
        {
            return itemdata.id;
        }

        public ItemData.ItemType GetItemType()
        {
            return itemdata.type;
        }

        public int GetItemPropertyValus()
        {

            string[] itemProperty = itemdata.property.Split("+");
            int.TryParse(itemProperty[1], out int value);

            return value;

        }
        public string GetItemName()
        {
            return itemdata.name;
        }
    }
}
