using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public class TableManager
    {

        private static TableManager tableManager = new TableManager();
        protected List<Level> _levelTable = null;
        protected List<MonsterData> _monsterTable = null;

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

        public void InItLevelTable()
        {

            if (_levelTable == null)
            {
                Console.WriteLine("레벨업 테이블 세팅 결과 ");
                Console.WriteLine("==============================");

                _levelTable = LevelTableSet();

            }
            Console.WriteLine("==============================");

        }
        public void InItLevelTables()
        {

            if (_levelTable == null)
            {
                Console.WriteLine("레벨업 테이블 세팅 결과 ");
                Console.WriteLine("==============================");

                _levelTable = LevelTableSet();

            }
            Console.WriteLine("==============================");
            if (_monsterTable == null)
            {
                Console.WriteLine("레벨업 테이블 세팅 결과 ");
                Console.WriteLine("==============================");

                _monsterTable = MonsterTableSet();

            }
            Console.WriteLine("==============================");
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
                monsterData.hp = 1000;
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
