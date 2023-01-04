using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsAndPortal
{
    public class Generator
    {
        public static Random random = new Random();

        // gameBoard 상태
        // - -5 : 포탈
        // - -3 : 코너
        // - -2 : 벽
        // - -1 : 유저 
        // -  n : 빈 공간
        // -  1 : 코인
        // -  2 : 장애물?
        // -  3 : 물약?

        public static int[] RandomPositionGenerator(int BOARD_SIZE_Y, int BOARD_SIZE_X)
        {
            int[] randomPos = new int[2];

            
            int randomItemPosY = random.Next(1, BOARD_SIZE_Y - 1); // 랜덤 위치 Y 좌표
            int randomItemPosX = random.Next(1, BOARD_SIZE_X - 1);   // 랜덤 위치 X 좌표

            randomPos[0] = randomItemPosY;
            randomPos[1] = randomItemPosX;

            return randomPos;
        }

        public static void ItemGenerator(int BOARD_SIZE_Y, int BOARD_SIZE_X, int[,] gameBoard, int itemType)
        {
            //itemType
            // 1 : 재화(코인) / 2 : 장애물 / 3 : 물약

            while (true)
            {
                int[] randomItemPos = RandomPositionGenerator(BOARD_SIZE_Y, BOARD_SIZE_X);


                // 뽑은 랜덤 좌표가 빈 공간인 경우
                if (gameBoard[randomItemPos[0], randomItemPos[1]] == 0)
                {
                    gameBoard[randomItemPos[0], randomItemPos[1]] = itemType;
                    // 해당 좌표에 아이템 설정.
                    break;
                }
                else
                {
                    //랜덤 좌표 다시 뽑으러가자!
                    /*nothing*/
                }

            }
        }
        public static void PortalGenerator(int BOARD_SIZE_Y, int BOARD_SIZE_X, int[,] gameBoard, int portalType)
        {

            int randomDirectionPortal = random.Next(0, 4);

            switch (randomDirectionPortal)
            {
                case 0:
                    gameBoard[0,( BOARD_SIZE_X / 2)-1] = portalType;
                    break;

                case 1:
                    gameBoard[(BOARD_SIZE_Y / 2)-1, 0] = portalType;
                    break;
                case 2:
                    gameBoard[BOARD_SIZE_Y-1, (BOARD_SIZE_X / 2)-1] = portalType;
                    break;
                case 3:
                    gameBoard[(BOARD_SIZE_Y / 2)-1, BOARD_SIZE_X-1] = portalType;
                    break;

                default:
                    break;

            }

        }



    }
}
