using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    class TableManager
    {
        
        private List<Level> _levelTable = null;
        public TableManager()
        {
            Console.WriteLine("===TableManager()===========================");
            InItLevelTable();
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

        public bool LevelUpCheck(int currLevel, int exp, int gainExp)
        {

            int currneedExp = 0;
            int nextNeedExp = 0;
            int levelUpOverExp = 0;
            int nextLevel = 0;
            
            currneedExp = _levelTable[currLevel].needExp; // 다음 레벨의 필요 경험치 - 현재 경험치 = 실제 필요 경험치

            nextLevel = currLevel + 1;


            levelUpOverExp = (exp + gainExp) - currneedExp;

            nextNeedExp = _levelTable[nextLevel].needExp;


            //5+10+200 = 215 --> 15/ 500

            if (currneedExp <= gainExp + exp)
            {
                //실제 필요경험치보다 획득한 경험치가 크거나 같으면,
                Console.WriteLine("Lv.{0} (Exp: {1} / {2}) ", nextLevel, levelUpOverExp, nextNeedExp);
                return true; // 레벨업
            }
            else
            {
                Console.WriteLine("Lv.{0} (Exp: {1} / {2}) ", currLevel, exp + gainExp, currneedExp);

                return false; //레벨업 X
            }

        }


    }
}
