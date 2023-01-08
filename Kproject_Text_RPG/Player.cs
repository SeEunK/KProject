using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public class Player : Character
    {

        public List<Item> inventory = new List<Item>();
        public Item item;
        public Player(string userInputName)
        {
            name = userInputName;
            level = 1;
            maxHP = 100_000;
            hp = 100_000;
            mp = 20_000;
            attackPower = 10;
            defense = 1;
            int exp = 0;
            

        }


        public override void Attack()
        {

        }
        public override void SpecialAttack()
        {

        }

        public void SetIventory(ItemData gainItem)
        {
            Item item = new Item(gainItem);
            inventory.Add(item);
        }

        public bool FindItemByType(ItemData.ItemType type)
        {
            for(int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].GetItemType() == type)
                {
                    return true;
                    
                }
            }
            return false;
        }

        public Item FindItemByID(int id)
        {
         
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetID() == id)
                {
                    item = inventory[i];
                    return item;

                }
            }
            return null;
        }


        public void UseItem(Item item)
        {
            ItemData.ItemType itemType = item.GetItemType();
            int itemProValue = item.GetItemPropertyValus();
            string itemName = item.GetItemName();

            // 1: 무기 //2 :방어구 //3:소모품

            switch (itemType)
            {
                case ItemData.ItemType.Weapon:
                    attackPower += itemProValue;
                    Console.WriteLine("{0}를 장착하여 공격력이 {1}상승했습니다.", itemName, itemProValue);
                    break;

                case ItemData.ItemType.Armor:
                    defense += itemProValue; 
                    Console.WriteLine("{0}를 장착하여 방어력이 {1}상승했습니다.", itemName, itemProValue);
                    break;

                case ItemData.ItemType.Potion:
                    
                    if (hp + itemProValue >= maxHP)
                    {
                        itemProValue = maxHP - hp;
                    }

                    hp += itemProValue;
                    Console.WriteLine("{0}을 사용하여 HP가 {1}만큼 회복했습니다.", itemName, itemProValue);
                    inventory.Remove(item);
                    break;

            }

        }
   

    }

}

