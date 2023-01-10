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
        int enhanceLevel;
        public int durability;
        public Item(ItemData data)
        {
            this.itemdata = data;
            enhanceLevel = 0;
            durability = data.maxDurability;
            
        }

        public int GetID()
        {
            return itemdata.id;
        }
        public int GetDurability()
        {
            return durability;
        }

        public int GetMaxDurability()
        {
            return itemdata.maxDurability;
        }
        public void SetDurability(int value)
        {
            durability += value;
        }

        public int GetEnhanceLevel()
        {
            return enhanceLevel;
        }
        public void SetEnhanceLevelUp(int incValue)
        {
            string stat = GetItemPropertyStat();
            int statValue = GetItemPropertyValue();
            int statUpValue = statValue + incValue;
            
            itemdata.property = string.Format($"{stat} + {statUpValue.ToString()}");
            enhanceLevel ++;
            
        }


        public ItemData.ItemType GetItemType()
        {
            return itemdata.type;
        }

        public int GetItemPropertyValue()
        {

            string[] itemProperty = itemdata.property.Split("+");
            int.TryParse(itemProperty[1], out int value);

            return value;
        }
        public string GetItemPropertyStat()
        {

            string[] itemProperty = itemdata.property.Split("+");
            string Stat = itemProperty[0];

            return Stat;
        }
        public string GetItemProperty()
        {
            
            return itemdata.property;
        }

        public string GetDescription()
        {
            return itemdata.desc;
        }
        public int GetSellPrice()
        {
            return itemdata.sellPrice;
        }

        public string GetItemName()
        {
            return itemdata.name;
        }
    }
}
