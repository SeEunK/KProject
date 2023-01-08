using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{

    public class ItemData
    {
        public enum ItemType
        {
            None = 0,
            Weapon = 1,
            Armor = 2,
            Potion = 3
        }

        public int id = 0;
        public string name = string.Empty;
        public ItemType type = ItemType.None;
        public string desc = string.Empty;
        public string property = string.Empty;
       
    }
}
