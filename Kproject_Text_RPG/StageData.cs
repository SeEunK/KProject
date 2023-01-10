using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public class StageData
    {
        Monster monster;
        StageStepData stageStep;

        public int id = 0;
        public List<StageStepData> stageStepList=null;
        public int clearRewardID = 0;

    }
}
