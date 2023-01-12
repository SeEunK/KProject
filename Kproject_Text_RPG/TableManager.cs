using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kproject_Text_RPG
{
    public class TableManager
    {

        private static TableManager tableManager = new TableManager();
        protected List<Level> _levelTable = null;
        protected List<MonsterData> _monsterTable = null;
        protected List<ItemData> _itemTable = null;
        protected List<StageData> _stageTable = null;
        protected List<StageStepData> _stagestepTable = null;
        protected List<EnhanceData> _enhanceTable = null;
        protected List<EnhanceLevelData> _enhanceLevelTable = null;

        private TableManager()
        {
            InItTables();
        }
        public static TableManager getInstance()
        {
            return tableManager;
        }
        public List<Level> levelTable
        {
            get {
                if (_levelTable == null)
                {
                    _levelTable = LevelTableSet();
                }
                return _levelTable;
            }
        }


        public void InItTables()
        {
            if (_levelTable == null)
            {
               // Console.WriteLine("레벨업 테이블 세팅 ");
               // Console.WriteLine("==============================");
                _levelTable = LevelTableSet();
            }
            if (_monsterTable == null)
            {
                // Console.WriteLine("몬스터 테이블 세팅  ");
                // Console.WriteLine("==============================");
                _monsterTable = MonsterTableSet();
            }
            if (_itemTable == null)
            {
               // Console.WriteLine("아이템 테이블 세팅  ");
               // Console.WriteLine("==============================");
                _itemTable = ItemDataSet();
            }
            if (_stagestepTable == null)
            {
               // Console.WriteLine("스테이지 스텝 테이블 세팅  ");
               // Console.WriteLine("==============================");
                _stagestepTable = StageStepDataSet();
            }
            if (_stageTable == null)
            {
                //Console.WriteLine("스테이지 테이블 세팅  ");
                //Console.WriteLine("==============================");
                _stageTable = StageDataSet();
            }
            if(_enhanceLevelTable== null)
            {
              //  Console.WriteLine("강화 레벨 테이블 세팅");
                _enhanceLevelTable = EnhanceLevelDataSet();
            }
            if (_enhanceTable == null)
            {
               // Console.WriteLine("강화 테이블 세팅");
                _enhanceTable = EnhanceDataSet();
            }
        }

        public List<EnhanceData> GetEnhanceTable()
        {
            return _enhanceTable;
        }

        public List<ItemData> GetItemTable()
        {
            return _itemTable;
        }
        public List<StageData> GetStageTable()
        {
            return _stageTable;
        }
        public StageData GetStageByID(int StageID)
        {
            for (int i = 0; i < _stageTable.Count; i++)
            {
                if (_stageTable[i].id == StageID)
                {
                    return _stageTable[i];
                }
            }

            return null;
        }

        public List<StageStepData> GetStageStepByID(int StageID)
        {
            for (int i = 0; i < _stageTable.Count; i++)
            {
                if (_stageTable[i].id == StageID)
                {
                    return _stageTable[i].stageStepList;
                }
            }

            return null;
        }

        public string[] GetStageNameList()
        {  
            string[] result = new string[_stageTable.Count];

            for (int i = 0; i < _stageTable.Count; i++)
            {
                result[i] = _stageTable[i].stageName;
            }

            return result;
        }

        public  int GetEnhanceCost(int enhanceID, int enhanceLevel)
        {
            for(int i = 0; i< _enhanceTable.Count; i++)
            {
                if(_enhanceTable[i].id == enhanceID)
                {
                    return _enhanceTable[i].enhanceLevelList[enhanceLevel - 1].enhanceCost;
                }
            }
            return 0;
        }
        public int GetEnhanceValue(int enhanceID, int enhanceLevel)
        {
            for (int i = 0; i < _enhanceTable.Count; i++)
            {
                if (_enhanceTable[i].id == enhanceID)
                {
                    return _enhanceTable[i].enhanceLevelList[enhanceLevel - 1].enhanceValue;
                }
            }
            return 0;
        }
        public float GetEnhanceSuccessRate(int enhanceID, int enhanceLevel)
        {
            for (int i = 0; i < _enhanceTable.Count; i++)
            {
                if (_enhanceTable[i].id == enhanceID)
                {
                    return _enhanceTable[i].enhanceLevelList[enhanceLevel - 1].enhanceSuccessRate;
                }
            }
            return 0;
        }

        public int GetEnchanceMaxLevel()
        {
            return _enhanceLevelTable.Count;
        }
        public string GetStageName(int index)
        {
            return _stageTable[index].stageName;
        }
        public int GetStageCount()
        {
            return _stageTable.Count;
        }
        public List<StageData> StageDataSet()
        {
           
            List<StageData> stageTable = new List<StageData>();

            { //stage 1 
                StageData stageData = new StageData();
                stageData.id = 1;
                stageData.stageName = "왕의 골짜기";
                stageData.stageStepList = new List<StageStepData>(); 

                // stageStep Data 에서 stage id 조회해서 해당 stepData 가 가진 stepData에 add.
                for (int i = 0; i < _stagestepTable.Count; i++)
                {
                    if (_stagestepTable[i].StageID == stageData.id)
                    {
                        stageData.stageStepList.Add(_stagestepTable[i]);
                        
                    }
                }
                stageData.clearRewardID = 101;
                stageTable.Add(stageData);
            }
            { //stage 2 
                StageData stageData = new StageData();
                stageData.id = 2;
                stageData.stageName = "고요한 성터";
                stageData.stageStepList = new List<StageStepData>();

                // stageStep Data 에서 stage id 조회해서 해당 stepData 가 가진 stepData에 add.
                for (int i = 0; i < _stagestepTable.Count; i++)
                {
                    if (_stagestepTable[i].StageID == stageData.id)
                    {
                        stageData.stageStepList.Add(_stagestepTable[i]);

                    }
                }
                stageData.clearRewardID = 201;
                stageTable.Add(stageData);
            }
            return stageTable;
        }

    

        public List<EnhanceData> EnhanceDataSet()
        {
            List<EnhanceData> enhanceTable = new List<EnhanceData>();

            { //enhance 1 
                EnhanceData enhanceData = new EnhanceData();
                enhanceData.id = 1;
                enhanceData.enhanceLevelList = new List<EnhanceLevelData>();

                // EnhanceLevelData 에서 enhance id 조회 해서 해당 enhanceData 가 가진 enhanceLevelList 에 add.
                for (int i = 0; i < _enhanceLevelTable.Count; i++)
                {
                    if (_enhanceLevelTable[i].enhanceID == enhanceData.id)
                    {
                        enhanceData.enhanceLevelList.Add(_enhanceLevelTable[i]);
                    }
                }
                enhanceTable.Add(enhanceData);
            }

            { //enhance 2 
                EnhanceData enhanceData = new EnhanceData();
                enhanceData.id = 2;
                enhanceData.enhanceLevelList = new List<EnhanceLevelData>();

                // EnhanceLevelData 에서 enhance id 조회 해서 해당 enhanceData 가 가진 enhanceLevelList 에 add.
                for (int i = 0; i < _enhanceLevelTable.Count; i++)
                {
                    if (_enhanceLevelTable[i].enhanceID == enhanceData.id)
                    {
                        enhanceData.enhanceLevelList.Add(_enhanceLevelTable[i]);
                    }
                }
                enhanceTable.Add(enhanceData);
            }
            return enhanceTable;
        }

        public List<EnhanceLevelData> EnhanceLevelDataSet()
        {
            List<EnhanceLevelData> enhanceLevelTable = new List<EnhanceLevelData>();

            // enhance 1
            { //1-1
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 1;
                enhanceLevel.enhanceLevel = 1;
                enhanceLevel.enhanceSuccessRate = 90;
                enhanceLevel.enhanceCost = 150;
                enhanceLevel.enhanceStat = "AttackPower";
                enhanceLevel.enhanceValue = 3;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //1-2
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 1;
                enhanceLevel.enhanceLevel = 2;
                enhanceLevel.enhanceSuccessRate = 70;
                enhanceLevel.enhanceCost = 300;
                enhanceLevel.enhanceStat = "AttackPower";
                enhanceLevel.enhanceValue = 5;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //1-3
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 1;
                enhanceLevel.enhanceLevel = 3;
                enhanceLevel.enhanceSuccessRate = 50;
                enhanceLevel.enhanceCost = 500;
                enhanceLevel.enhanceStat = "AttackPower";
                enhanceLevel.enhanceValue = 10;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //1-4
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 1;
                enhanceLevel.enhanceLevel = 4;
                enhanceLevel.enhanceSuccessRate = 30;
                enhanceLevel.enhanceCost = 700;
                enhanceLevel.enhanceStat = "AttackPower";
                enhanceLevel.enhanceValue = 15;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //1-5
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 1;
                enhanceLevel.enhanceLevel = 5;
                enhanceLevel.enhanceSuccessRate = 20;
                enhanceLevel.enhanceCost = 1000;
                enhanceLevel.enhanceStat = "AttackPower";
                enhanceLevel.enhanceValue = 20;

                enhanceLevelTable.Add(enhanceLevel);
            }
            // enhance 2
            { //2-1
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 2;
                enhanceLevel.enhanceLevel = 1;
                enhanceLevel.enhanceSuccessRate = 90;
                enhanceLevel.enhanceCost = 100;
                enhanceLevel.enhanceStat = "defense";
                enhanceLevel.enhanceValue = 3;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //2-2
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 2;
                enhanceLevel.enhanceLevel = 2;
                enhanceLevel.enhanceSuccessRate =70;
                enhanceLevel.enhanceCost = 200;
                enhanceLevel.enhanceStat = "defense";
                enhanceLevel.enhanceValue = 5;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //2-3
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 2;
                enhanceLevel.enhanceLevel = 3;
                enhanceLevel.enhanceSuccessRate = 50;
                enhanceLevel.enhanceCost = 300;
                enhanceLevel.enhanceStat = "defense";
                enhanceLevel.enhanceValue = 10;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //2-4
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 2;
                enhanceLevel.enhanceLevel = 4;
                enhanceLevel.enhanceSuccessRate = 30;
                enhanceLevel.enhanceCost = 400;
                enhanceLevel.enhanceStat = "defense";
                enhanceLevel.enhanceValue = 15;

                enhanceLevelTable.Add(enhanceLevel);
            }
            { //2-5
                EnhanceLevelData enhanceLevel = new EnhanceLevelData();
                enhanceLevel.enhanceID = 2;
                enhanceLevel.enhanceLevel = 5;
                enhanceLevel.enhanceSuccessRate = 20;
                enhanceLevel.enhanceCost = 500;
                enhanceLevel.enhanceStat = "defense";
                enhanceLevel.enhanceValue = 20;

                enhanceLevelTable.Add(enhanceLevel);
            }
            return enhanceLevelTable;
        }
        public List<StageStepData> StageStepDataSet()
        {
            List<StageStepData> stageStepTable = new List<StageStepData>();

            //stage 1
            { //stage 1 -1
                StageStepData stageStep = new StageStepData();
                stageStep.StageID = 1;
                stageStep.StageStepNum = 1;
                stageStep.monsterID =1;
                stageStep.monsterDropItemID = 0;
                stageStep.rewardExp = 10;
                stageStep.rewardGold = 100;

                stageStepTable.Add(stageStep);
            }
            { //stage 1- 2
                StageStepData stageStep = new StageStepData();
                stageStep.StageID = 1;
                stageStep.StageStepNum = 2;
                stageStep.monsterID = 2;
                stageStep.monsterDropItemID = 0;
                stageStep.rewardExp = 10;
                stageStep.rewardGold = 100;

                stageStepTable.Add(stageStep);
            }
            { //stage 1- 3
                StageStepData stageStep = new StageStepData();
                stageStep.StageID = 1;
                stageStep.StageStepNum = 3;
                stageStep.monsterID = 2;
                stageStep.monsterDropItemID = 300;
                stageStep.rewardExp = 10;
                stageStep.rewardGold = 100;

                stageStepTable.Add(stageStep);
            }
            ///stage 2
            { //stage 2 -1
                StageStepData stageStep = new StageStepData();
                stageStep.StageID = 2;
                stageStep.StageStepNum = 1;
                stageStep.monsterID = 1;
                stageStep.monsterDropItemID = 0;
                stageStep.rewardExp = 10;
                stageStep.rewardGold = 100;

                stageStepTable.Add(stageStep);
            }
            { //stage 2- 2
                StageStepData stageStep = new StageStepData();
                stageStep.StageID = 2;
                stageStep.StageStepNum = 2;
                stageStep.monsterID = 2;
                stageStep.monsterDropItemID = 0;
                stageStep.rewardExp = 10;
                stageStep.rewardGold = 100;

                stageStepTable.Add(stageStep);
            }
            { //stage 2- 3
                StageStepData stageStep = new StageStepData();
                stageStep.StageID = 2;
                stageStep.StageStepNum = 3;
                stageStep.monsterID = 2;
                stageStep.monsterDropItemID = 300;
                stageStep.rewardExp = 10;
                stageStep.rewardGold = 100;

                stageStepTable.Add(stageStep);
            }
            { //stage 2- 4
                StageStepData stageStep = new StageStepData();
                stageStep.StageID = 2;
                stageStep.StageStepNum = 4;
                stageStep.monsterID = 2;
                stageStep.monsterDropItemID = 300;
                stageStep.rewardExp = 15;
                stageStep.rewardGold = 100;

                stageStepTable.Add(stageStep);
            }

            return stageStepTable;
        }


        public List<ItemData> ItemDataSet()
        {
            List <ItemData> itemTable = new List <ItemData>();

            { 
                ItemData item = new ItemData();
                item.id = 300;
                item.type = ItemData.ItemType.Potion; //소모품
                item.name = "HP 물약";
                item.desc = "사용하면, HP를 30만큼 회복합니다.";
                item.property = "hp+30";
                item.sellPrice = 10;
                item.price = 100;

                itemTable.Add(item);
            }

            {
                ItemData item = new ItemData();
                item.id = 100;
                item.type = ItemData.ItemType.Weapon; //무기
                item.name = "단단한 몽둥이";
                item.desc = "단단하지만 날카롭지 못하다.";
                item.property = "attackPower+10";
                item.sellPrice = 30;
                item.price = 300;
                item.maxDurability = 70;
               

                itemTable.Add(item);
            }
            {
                ItemData item = new ItemData();
                item.id = 101;
                item.type = ItemData.ItemType.Weapon; //무기
                item.name = "날카로운 몽둥이";
                item.desc = "날카롭게 생긴 몽둥이이다.";
                item.property = "attackPower+15";
                item.sellPrice = 50;
                item.price = 500;
                item.maxDurability = 100;

                itemTable.Add(item);
            }
            {
                ItemData item = new ItemData();
                item.id = 200;
                item.type = ItemData.ItemType.Armor;  //방어구
                item.name = "무명옷";
                item.desc = "흔한 천으로된 옷이다.";
                item.property = "defense+5";
                item.sellPrice = 20;
                item.price = 200;
                item.maxDurability = 50;

                itemTable.Add(item);
            }
            {
                ItemData item = new ItemData();
                item.id = 201;
                item.type = ItemData.ItemType.Armor;  //방어구
                item.name = "얇은 가죽 옷";
                item.desc = "얇은 가죽으로 된 옷이다.";
                item.property = "defense+7";
                item.sellPrice = 100;
                item.price = 400;
                item.maxDurability = 15;
                

                itemTable.Add(item);
            }

            return itemTable;
        }

        public ItemData FindItemDataByID(int id)
        {

            for (int i = 0; i < _itemTable.Count; i++)
            {
                if (_itemTable[i].id == id)
                {
                    return _itemTable[i];
                }
            }

            return null;
        }
        public List<MonsterData> MonsterTableSet()
        {
            List<MonsterData> monsterDataTable= new List<MonsterData>();

            {
                MonsterData monsterData = new MonsterData();
                monsterData.id = 1;
                monsterData.name = "슬라임";
                monsterData.type = 0;
                monsterData.level = 1;
                monsterData.hp = 150;
                monsterData.mp = 200;
                monsterData.attackPower = 10;
                monsterData.defense = 1;

                monsterDataTable.Add(monsterData);
            }

            {
                MonsterData monsterData = new MonsterData();
                monsterData.id = 2;
                monsterData.name = "늑대";
                monsterData.type = 1;
                monsterData.level = 1;
                monsterData.hp = 500;
                monsterData.mp = 200;
                monsterData.attackPower = 10;
                monsterData.defense = 1;

                monsterDataTable.Add(monsterData);
            }

            return monsterDataTable;
        }

        public MonsterData FindMonsterDataByID(int id)
        {
           
            for (int i = 0; i < _monsterTable.Count; i++)
            {
                if (_monsterTable[i].id == id)
                {
                    return _monsterTable[i];
                }
            }

            return null;
        }

        public static List<Level>  LevelTableSet()
        {
            List<Level> levelTable = new List<Level>();

            for (int i = 0; i < 10; i++)
            {
                Level level = new Level();
                level.levelNum = i + 1;
                level.needExp = (level.levelNum - 1) * 100 + (level.levelNum - 1) * level.levelNum * 50;
                levelTable.Add(level);
            }

           // Console.WriteLine("========LevelTable============");
           // 
           // foreach (Level level in levelTable)
           // {
           //     Console.WriteLine("LEVEL:  {0} /  Need EXP : {1} ", level.levelNum, level.needExp);
           // }
            return levelTable;
        }

        public int GetLevelByExp(int retentionExp)
        {
            for (int i = _levelTable.Count -1; i >= 0 ; --i)
            {
                if (retentionExp >= _levelTable[i].needExp)
                {
                    return _levelTable[i].levelNum;
                }
            }
            return 1; 

        }
        public int GetMaxLevel()
        {
            return _levelTable[_levelTable.Count - 1].levelNum;
        }
      
        public bool LevelUpCheck(int currExp, int gainExp)
        {

            int currLevel = GetLevelByExp(currExp);
            int nextLevel = GetLevelByExp(currExp + gainExp);
            int nextNeedExp = 0;

            int displayExp = 0;

            if(GetMaxLevel() == currLevel)
            {
                return false;
            }
           
            if (currLevel == nextLevel)
            {
                displayExp = currExp + gainExp;
                nextNeedExp = _levelTable[nextLevel].needExp;
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("Lv.{0} (Exp: {1} / {2}) ", nextLevel, displayExp, nextNeedExp);

                return false; //레벨업 X
            }
            else if (currLevel < nextLevel)
            {
                //실제 필요경험치보다 획득한 경험치가 크거나 같으면,
                nextNeedExp = _levelTable[nextLevel].needExp;
                displayExp = (currExp + gainExp) - _levelTable[currLevel].needExp;
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("Lv.{0} (Exp: {1} / {2}) ", nextLevel, displayExp, nextNeedExp);
                return true; // 레벨업
            }
           else
            { // 있을수없는 경우지만, 예외적인 애러 발생할수있으니...  

                Console.SetCursorPosition(40, 7);
                Console.WriteLine("[ERROR] 알수없는 레벨입니다.");
                return false;
            }
           
        }
    }
}
