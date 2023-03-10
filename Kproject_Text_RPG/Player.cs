using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public class Player : Character
    {

        public List<Item> inventory;
        public Item[] equipSlot;
        public Item item;
        protected int exp;
        protected int gold;
        protected int invenMaxSize;
        public Player(string userInputName)
        {
            name = userInputName;
            level = 1;
            maxHP = 100_000;
            hp = 100_000;
            mp = 20_000;
            attackPower = 100;
            defense = 1;
            exp = 0;
            gold = 0;
            inventory = new List<Item>();
            invenMaxSize = 10;

            equipSlot = new Item[3];
        }


        public void SetEquipSlot(Item eqiupItem)
        {
            Item tempItem = null;
            int typeIndex = 0;

            if (eqiupItem.GetItemType() == ItemData.ItemType.Weapon)
            {
                typeIndex = 0; }
            else if (eqiupItem.GetItemType() == ItemData.ItemType.Armor) {
                typeIndex = 1;
            }
            else
            {
                Console.SetCursorPosition(45, 15);
                Console.WriteLine("장착할수없는 아이템입니다.");
                Task.Delay(1000).Wait();
                Console.SetCursorPosition(45, 15);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("                                                                                  ");
                Console.ResetColor();
                typeIndex = -1;
            }


            if (equipSlot[typeIndex] != null)
            {
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("{0}가 장착중입니다. 해제하고 장착하시겠습니까? Y/N  ", equipSlot[typeIndex].GetItemName());
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Y)
                {
                    UnEquipItem(equipSlot[typeIndex]);
                    tempItem = equipSlot[typeIndex];
                    equipSlot[typeIndex] = eqiupItem;
                    inventory.Add(tempItem);
                    UseItem(eqiupItem);

                    Task.Delay(1000).Wait();
                    Console.SetCursorPosition(45, 15);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                                                  ");
                    Console.ResetColor();
                }
                else if (inputKey.Key == ConsoleKey.N)
                {
                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("장착 진행을 종료하였습니다.");
                    Task.Delay(1000).Wait();
                    Console.SetCursorPosition(45, 15);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                                                    ");
                    Console.ResetColor();
                }
            }
            else if (typeIndex == -1)
            {
                Console.SetCursorPosition(45, 15);
                Console.WriteLine("장착할수없는 아이템입니다.");
                Task.Delay(1000).Wait();
                Console.SetCursorPosition(45, 15);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("                                                                                    ");
                Console.ResetColor();
            }
            else
            {
                equipSlot[typeIndex] = eqiupItem;
                UseItem(eqiupItem);
            }

        }


        public override void Attack()
        {

        }
        public override void SpecialAttack()
        {

        }

        public void SetInvenSize(int plusSize)
        {
            invenMaxSize += plusSize;

        }

        public  Item[]  GetEquipSlotList()
        {
            return equipSlot;
        }
        public Item GetEquipItemBySlotIndex(int slotIndex)
        {
            return equipSlot[slotIndex];
        }


        public int GetInvenMaxSize()
        {
            return invenMaxSize;
        }
        public int GetExp()
        {
            return exp;
        }
        public int GetGold()
        {
            return gold;
        }
        

        public void SetExp(int gainExp)
        {
            exp += gainExp;
        }
        public void SetGold(int gainGold)
        {
            
            gold += gainGold;
        }

        public void SetIventory(ItemData gainItem)
        {
            Item item = new Item(gainItem);
            inventory.Add(item);
        }


        public bool FindItemByType(ItemData.ItemType type)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetItemType() == type)
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

        public string LevelDisplay()
        {
            TableManager tableManager = TableManager.getInstance();

            int prevNeedExp = 0;
            int displayExp = 0;

            if (level > 1)
            {
                prevNeedExp = tableManager.levelTable[level - 1].needExp;
                displayExp = prevNeedExp - exp;
            }
            else
            {
                prevNeedExp = 0;
                displayExp = exp;
            }

            int nextNeedExp = tableManager.levelTable[level].needExp;

            string returnValue = $"Lv.{level} (Exp: {displayExp} / {nextNeedExp})";

            return returnValue;

        }



        public void UnEquipItem(Item item)
        {
            ItemData.ItemType itemType = item.GetItemType();
            int itemProValue = item.GetItemPropertyValue();
            switch (itemType)
            {
                case ItemData.ItemType.Weapon:
                    attackPower -= itemProValue;
                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("{0}를 장착해제하였습니다. (공격력 - {1})", item.GetItemName(), itemProValue);
                    Task.Delay(1000).Wait();
                    Console.SetCursorPosition(30, 7);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                                                    ");
                    Console.ResetColor();
                    
                    break;

                case ItemData.ItemType.Armor:
                    defense -= itemProValue;
                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("{0}를 장착해제하였습니다.(방어력 - {1})", item.GetItemName(), itemProValue);
                    Task.Delay(1000).Wait();
                    Console.SetCursorPosition(30, 7);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                                                    ");
                    Console.ResetColor();
                    
                    break;
            }

             
        }

        public void UseItem(Item item )
        {
            ItemData.ItemType itemType = item.GetItemType();
            int itemProValue = item.GetItemPropertyValue();
            string itemName = item.GetItemName();

            // 1: 무기 //2 :방어구 //3:소모품


            switch (itemType)
            {
                case ItemData.ItemType.Weapon:
                    attackPower += itemProValue;

                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("{0}를 장착하여 공격력이 {1}상승했습니다.", itemName, itemProValue);
                    Task.Delay(1000).Wait();
                    Console.SetCursorPosition(30, 7);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                                                  ");
                    Console.ResetColor();

                    inventory.Remove(item);
                 

                    break;

                case ItemData.ItemType.Armor:
                    defense += itemProValue;
                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("{0}를 장착하여 방어력이 {1}상승했습니다.", itemName, itemProValue);
                    Task.Delay(1000).Wait();
                    Console.SetCursorPosition(30, 7);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                                                  ");
                    Console.ResetColor();

                    inventory.Remove(item);
                    break;

                case ItemData.ItemType.Potion:

                    if (hp + itemProValue >= maxHP)
                    {
                        itemProValue = maxHP - hp;
                    }

                    hp += itemProValue;
                    Console.SetCursorPosition(30, 7);
                    Console.WriteLine("{0}을 사용하여 HP가 {1}만큼 회복했습니다.", itemName, itemProValue);
                    Task.Delay(1000).Wait();
                    Console.SetCursorPosition(30, 7);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("                                                                                   ");
                    Console.ResetColor();

                    inventory.Remove(item);
                    break;

            }

        }
    }
}







