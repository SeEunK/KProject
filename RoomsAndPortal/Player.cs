using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsAndPortal
{
    public class Player
    {
        public int playerCoinCount = 0;
        public int playerHeartCount = 3;
        public int heartMaxCount = 3;
        public int playerPosY = 0;
        public int playerPosX = 0;
        public bool isMove = false;
        public bool isAnothcrRoom = false;
        public int prevPosY = 0;
        public int prevPosX = 0;


        public void inItPosition(int BOARD_SIZE_Y, int BOARD_SIZE_X)
        {
            Random randomPosition = new Random();
            playerPosY = randomPosition.Next(1, BOARD_SIZE_Y - 1); // 플레이어 최초 랜덤 위치 Y 좌표
            playerPosX = randomPosition.Next(1, BOARD_SIZE_X - 1);   // 플레이어 최초 랜덤 위치 X 좌표
      
        }


    }
}
