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

        private TableManager()
        {
            Console.WriteLine("===TableManager()===========================");
            InItLevelTables();
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
                    Console.WriteLine("============get==================");
                    _levelTable = LevelTableSet();
                }
                return _levelTable;
            }
        }


        public void InItLevelTables()
        {

            if (_levelTable == null)
            {
                Console.WriteLine("레벨업 테이블 세팅 ");
                Console.WriteLine("==============================");

                _levelTable = LevelTableSet();

            }
            Console.WriteLine("==============================");
            if (_monsterTable == null)
            {
                Console.WriteLine("몬스터 테이블 세팅  ");
                Console.WriteLine("==============================");

                _monsterTable = MonsterTableSet();

            }
            Console.WriteLine("==============================");
            if (_itemTable == null)
            {
                Console.WriteLine("아이템 테이블 세팅  ");
                Console.WriteLine("==============================");

                _itemTable = ItemDataSet();

            }
            Console.WriteLine("==============================");
            if (_stagestepTable == null)
            {
                Console.WriteLine("스테이지 스텝 테이블 세팅  ");
                Console.WriteLine("==============================");

                _stagestepTable = StageStepDataSet();

            }
            Console.WriteLine("==============================");
            if (_stageTable == null)
            {
                Console.WriteLine("스테이지 테이블 세팅  ");
                Console.WriteLine("==============================");

                _stageTable = StageDataSet();

            }
            Console.WriteLine("==============================");
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

                itemTable.Add(item);
            }

            {
                ItemData item = new ItemData();
                item.id = 100;
                item.type = ItemData.ItemType.Weapon; //무기
                item.name = "단단한 몽둥이";
                item.desc = "단단하지만 날카롭지 못하다.";
                item.property = "attackPower+10";

                itemTable.Add(item);
            }
            {
                ItemData item = new ItemData();
                item.id = 101;
                item.type = ItemData.ItemType.Weapon; //무기
                item.name = "날카로운 몽둥이";
                item.desc = "날카롭게 생긴 몽둥이이다.";
                item.property = "attackPower+15";

                itemTable.Add(item);
            }
            {
                ItemData item = new ItemData();
                item.id = 200;
                item.type = ItemData.ItemType.Armor;  //방어구
                item.name = "무명옷";
                item.desc = "흔한 천으로된 옷이다.";
                item.property = "defense+5";

                itemTable.Add(item);
            }
            {
                ItemData item = new ItemData();
                item.id = 201;
                item.type = ItemData.ItemType.Armor;  //방어구
                item.name = "얇은 가죽 옷";
                item.desc = "얇은 가죽으로 된 옷이다.";
                item.property = "defense+7";

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

             Console.WriteLine("========LevelTable============");
            
             foreach (Level level in levelTable)
             {
                 Console.WriteLine("LEVEL:  {0} /  Need EXP : {1} ", level.levelNum, level.needExp);
             }
            
             return levelTable;
        }

        

        public int GetLevelByExp(int retentionExp)
        {
            int level = 0;

            for (int i = 0; i < _levelTable.Count; ++i)
            {
                if (retentionExp > _levelTable[i].needExp)
                {
                    level += 1;

                }
                else if (retentionExp <= _levelTable[i].needExp)
                {
                    break;
                }
            }
            return level;

        }
        public bool LevelUpCheck(int currExp, int gainExp)
        {

            int currLevel = GetLevelByExp(currExp);
            int nextLevel = GetLevelByExp(currExp + gainExp);
            int nextNeedExp = _levelTable[nextLevel].needExp;


            // 현재경험치 + 획득 경험치 적용 했을때, 레벨을 찾는 반복문.


            int displayExp = 0;

            if (currLevel == nextLevel)
            {
                displayExp = currExp + gainExp;
                Console.WriteLine("Lv.{0} (Exp: {1} / {2}) ", nextLevel, displayExp, nextNeedExp);

                return false; //레벨업 X
            }
            else if (currLevel < nextLevel)
            {
                //실제 필요경험치보다 획득한 경험치가 크거나 같으면,
                displayExp = (currExp + gainExp) - _levelTable[currLevel].needExp;
                Console.WriteLine("Lv.{0} (Exp: {1} / {2}) ", nextLevel, displayExp, nextNeedExp);
                return true; // 레벨업
            }
           else
            { // 있을수없는 경우지만, 예외적인 애러 발생할수있으니...  
                Console.WriteLine("[ERROR] 알수없는 레벨입니다.");
                return false;
            }
           

        }


    }
}
