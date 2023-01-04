using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PorkerGame
{
    public static class Checker
    {
        //로티플 : 무늬 같고, 1/ 10/11/12/13

        //백스트레이트 : 무늬 같고, 1/2/3/4/5

        //스티플 : 무늬 같고, 연속 수

        //포카드 : 4개 숫자 같음
        //풀 하우스 : 같은 숫자 3 + 같은 숫자 2
        
        //플러쉬 : 무늬 같음 5장 

        //

        public static bool IsRoyalStraightFlush(List<Card> cardList)
        {

            List<Card> typeSortList = new List<Card>();
         
            //type으로 정렬
            typeSortList = cardList.OrderBy(x => x.cardType).ToList();
          
                       
            int[] royalStraightFlush = { 1, 10, 11, 12, 13 };

            int searchStartIndex = 0;
            int searchEndIndex = 0;

            if (typeSortList.Count > 5)
            {// 카드가 5장 이상 인것 확인할때.

                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    searchStartIndex = 0;
                    searchEndIndex = 4;
                }
                else if (typeSortList[1].cardType == typeSortList[5].cardType)
                {
                    searchStartIndex = 1;
                    searchEndIndex = 5;
                }
                else if (typeSortList[2].cardType == typeSortList[6].cardType)
                {
                    searchStartIndex = 2;
                    searchEndIndex = 6;
                }
                else
                {
                    return false;
                }
            }
            else
            { // 카드가 5장인것 확인할때.
                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    searchStartIndex = 0;
                    searchEndIndex = 4;
                }
                else
                {
                    return false;
                }
            }

            int sameCount = 0;
            for (int i = 0; i < royalStraightFlush.Length;  i++)
            {
                for(int j = searchStartIndex; j <= searchEndIndex;  j++)
                {
                    if (cardList[j].cardNumber == royalStraightFlush[i])
                    {
                        ++sameCount;
                        if(sameCount == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        /*nothing*/
                    }
                }
            }
            return false;
        }



        public static bool IsBackStraightFlush(List<Card> cardList)
        {

            List<Card> typeSortList = new List<Card>();

            //type으로 정렬
            typeSortList = cardList.OrderBy(x => x.cardType).ToList();


            int[] backStraightFlush = { 1, 2, 3, 4, 5 };

            int searchStartIndex = 0;
            int searchEndIndex = 0;

            if (typeSortList.Count > 5)
            {// 카드가 5장 이상 인것 확인할때.

                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    searchStartIndex = 0;
                    searchEndIndex = 4;
                }
                else if (typeSortList[1].cardType == typeSortList[5].cardType)
                {
                    searchStartIndex = 1;
                    searchEndIndex = 5;
                }
                else if (typeSortList[2].cardType == typeSortList[6].cardType)
                {
                    searchStartIndex = 2;
                    searchEndIndex = 6;
                }
                else
                {
                    return false;
                }
            }
            else
            { // 카드가 5장인것 확인할때.
                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    searchStartIndex = 0;
                    searchEndIndex = 4;
                }
                else
                {
                    return false;
                }
            }

            int sameCount = 0;
            for (int i = 0; i < backStraightFlush.Length; i++)
            {
                for (int j = searchStartIndex; j <= searchEndIndex; j++)
                {
                    if (cardList[j].cardNumber == backStraightFlush[i])
                    {
                        ++sameCount;
                        if (sameCount == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        /*nothing*/
                    }
                }
            }
            return false;
        }

        public static bool IsStraightFlush(List<Card> cardList)
        {

            List<Card> typeSortList = new List<Card>();

            //type으로 정렬
            typeSortList = cardList.OrderBy(x => x.cardType).ToList();


            int searchStartIndex = 0;
            int searchEndIndex = 0;

            if (typeSortList.Count > 5)
            {// 카드가 5장 이상 인것 확인할때.

                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    searchStartIndex = 0;
                    searchEndIndex = 4;
                }
                else if (typeSortList[1].cardType == typeSortList[5].cardType)
                {
                    searchStartIndex = 1;
                    searchEndIndex = 5;
                }
                else if (typeSortList[2].cardType == typeSortList[6].cardType)
                {
                    searchStartIndex = 2;
                    searchEndIndex = 6;
                }
                else
                {
                    return false;
                }
            }
            else
            { // 카드가 5장인것 확인할때.
                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    searchStartIndex = 0;
                    searchEndIndex = 4;
                }
                else
                {
                    return false;
                }
            }

            List<int> searchList = new List<int>();
            for(int i = searchStartIndex; i<=searchEndIndex; i++)
            {
                searchList.Add(typeSortList[i].cardNumber);
            }

            searchList.Sort();

            if (searchList[4] - searchList[0] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsFourCard(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();
            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();
            int sameCount = 0;

            // 중복 수 체크!!!
            if(numberSortList.Count == numberSortList.Distinct().Count())
            { // 중복이 있으면,
                //숫자만 뽑아서 담아둘 리스트 생성.
                List<int> searchList = new List<int>();

                for (int i = 0; i < numberSortList.Count; i++)
                {
                    searchList.Add(numberSortList[i].cardNumber); //하나씩 숫자만 add
                }
                int temNum = searchList[0];
                for (int i = 1; i< searchList.Count-1; i++)
                {
                    
                    if (temNum == searchList[i])
                    {
                        ++sameCount;
                        if(sameCount == 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        temNum = searchList[i];
                        sameCount = 0;
                    }
                }
               
                return false;
            }
            else
            {// 중복이 아에 없으면,
                return false;
            }
         

        } //IsFourCard()

        public static bool IsFullHouse(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();
            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();
            int sameCount = 0;

            // 중복 수 체크!!!
            if (numberSortList.Count == numberSortList.Distinct().Count())
            { // 중복이 있으면,
                //숫자만 뽑아서 담아둘 리스트 생성.
                List<int> searchList = new List<int>();

                for (int i = 0; i < numberSortList.Count; i++)
                {
                    searchList.Add(numberSortList[i].cardNumber); //하나씩 숫자만 add
                }
                int temNum = searchList[0];
                //3개 찾고 남은거 담아둘 리스트
                List<int> remainList = new List<int>();
                for (int i = 1; i < searchList.Count; i++)
                {
                    if (temNum == searchList[i])
                    {
                        ++sameCount;
                        if (sameCount == 2)
                        { // 3개 숫자 맞음!

                            for (int j = i - 3; j >= 0; j--)
                            {
                                remainList.Add(searchList[j]); // 트리플 판정 나기 전 3번 앞 인덱스 부터 0번째까지 나머지에 넣고,
                            }
                            for (int k = i + 1; k < searchList.Count; k++)
                            {
                                remainList.Add(searchList[k]); // 트리플 판정 다음 인덱스 부터 끝까지 나머지에 넣어.
                            }
                            // 나머지 리스트에서 pair 가 있나 체크.

                            int remainTempNum = remainList[0];
                            for (int index = 1; index < remainList.Count - 1; index++)
                            {
                                if (remainTempNum == remainList[index])
                                {
                                    return true;
                                }
                                else
                                {
                                    remainTempNum = remainList[index];
                                }
                            }
                            return false; //나머지에서 원페어를 못찾았으니, false 반환.

                        }
                        else {  /*nothing */}
                    }
                    else
                    {
                        temNum = searchList[i]; // 비교 대상에 현재값 넣기.
                        sameCount = 0;
                    }
                }
                return false;
            }
            else
            {// 중복이 아에 없으면,
                return false;
            }

        }

        public static bool IsFlush(List<Card> cardList)
        {
            List<Card> typeSortList = new List<Card>();

            //type으로 정렬
            typeSortList = cardList.OrderBy(x => x.cardType).ToList();

        
            if (typeSortList.Count > 5)
            {// 카드가 5장 이상 인것 확인할때.
                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    return true;
                }
                else if (typeSortList[1].cardType == typeSortList[5].cardType)
                {
                    return true;
                }
                else if (typeSortList[2].cardType == typeSortList[6].cardType)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { // 카드가 5장인것 확인할때.
                if (typeSortList[0].cardType == typeSortList[4].cardType)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }//IsFlush()


        public static bool IsMountain(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();

            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();

            int[] mountain = { 1, 10, 11, 12, 13 };

            // 중복 제거해서 담아둘 리스트 생성.
            List<int> searchList = new List<int>();
            
            for(int i =0; i< numberSortList.Count; i++)
            {
                if (!searchList.Contains(numberSortList[i].cardNumber)){ //동일한게 searchList 에 없으면,
                    searchList.Add(numberSortList[i].cardNumber); //추가
                }
            }


            int listSize = searchList.Count;

            int checkLastIndex = listSize - 1;

            if (listSize < 5) // 중복 수 없이 정리한 리스트가 총 5개 안되면 false 반환.
            {
                return false; 
            }
            else
            {  //5개 이상이면, 마운틴이랑 숫자가 같은지 체크
                int sameCount = 0;
                for (int i = 0; i < mountain.Length; i++)
                {
                    for (int j = 0; j < listSize; j++)
                    {
                        if (searchList[j] == mountain[i])
                        {
                            ++sameCount;
                            if (sameCount == 5)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            /*nothing*/
                        }
                    }
                }
                return false;
            }
        }//IsMountain()

        public static bool IsBackStraight(List<Card> cardList)
        {

            List<Card> numberSortList = new List<Card>();

            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();


            int[] backStraight = { 1, 2, 3, 4, 5 };

            int searchStartIndex = 0;
            int searchEndIndex = 0;


            if (numberSortList.Count > 5)
            {// 카드가 5장 이상 인것 확인할때.

                if (numberSortList[0].cardNumber == 1)
                {
                    searchStartIndex = 0;
                    searchEndIndex = numberSortList.Count() - 1;
                }
                else if (numberSortList[1].cardNumber == 1)
                {
                    searchStartIndex = 1;
                    searchEndIndex = numberSortList.Count() - 1;
                }
                else if (numberSortList[2].cardNumber == 1)
                {
                    searchStartIndex = 2;
                    searchEndIndex = numberSortList.Count() -1;
                }
                else
                {
                    return false;
                }
            }
            else
            { // 카드가 5장인것 확인할때.
                if (numberSortList[0].cardNumber == 1)
                {
                    searchStartIndex = 0;
                    searchEndIndex = 4;
                }
                else
                {
                    return false;
                }
            }

            int count = 0;
            for (int i = 0; i < backStraight.Length; i++)
            {
                for (int j = searchStartIndex; j <= searchEndIndex; j++)
                {
                    if (cardList[j].cardNumber == backStraight[i])
                    {
                        ++count;
                        if (count == 5)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        /*nothing*/
                    }
                }
            }
            return false;
        } //IsBackStraight()

        public static bool IsStraight(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();

            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();

            // 중복 제거해서 담아둘 리스트 생성.
            List<int> searchList = new List<int>();

            for (int i = 0; i < numberSortList.Count; i++)
            {
                if (!searchList.Contains(numberSortList[i].cardNumber))
                { //동일한게 searchList 에 없으면,
                    searchList.Add(numberSortList[i].cardNumber); //추가
                }
            }

            int listSize = searchList.Count;
            int checkLastIndex = listSize - 1;

            if (listSize < 5)
            {
                return false;
            }
            else
            {
                for (int i = checkLastIndex; 0 <= i-4; i--)
                {
                    if (searchList[i] - searchList[i-4] == 4)
                    {
                        return true;
                    }
                    else
                    {
                        /*nothing*/
                    }
                }
                return false;
            }
        } //IsStraight()


        public static bool IsTriple(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();
            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();
            int sameCount = 0;

            // 중복 수 체크!!!
            if (numberSortList.Count == numberSortList.Distinct().Count())
            { // 중복이 있으면,
                //숫자만 뽑아서 담아둘 리스트 생성.
                List<int> searchList = new List<int>();

                for (int i = 0; i < numberSortList.Count; i++)
                {
                    searchList.Add(numberSortList[i].cardNumber); //하나씩 숫자만 add
                }
                int temNum = searchList[0];
                for (int i = 1; i < searchList.Count; i++)
                {
                    if (temNum == searchList[i])
                    {
                        ++sameCount;
                        if (sameCount == 2)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        temNum = searchList[i];
                        sameCount = 0;
                    }
                }

                return false;
            }
            else
            {// 중복이 아에 없으면,
                return false;
            }
            
        }//IsTriple()

        public static bool IsTwoPair(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();
            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();

            // 중복 수 체크!!!
            if (numberSortList.Count == numberSortList.Distinct().Count())
            { // 중복이 있으면,
                //숫자만 뽑아서 담아둘 리스트 생성.
                List<int> searchList = new List<int>();

                for (int i = 0; i < numberSortList.Count; i++)
                {
                    searchList.Add(numberSortList[i].cardNumber); //하나씩 숫자만 add
                }
              
                int pairCount = 0;
                for (int i = 0; i < searchList.Count; i++)
                {
                    for (int j = i + 1; j < searchList.Count - 1; j++)
                    {
                        if (searchList[j] == searchList[i])
                        {

                            ++pairCount;
                            if (pairCount == 2)
                            {
                                return true;
                            }
                            i++;
                        }
                    }
                }
                return false;
            }
            else
            {// 중복이 아에 없으면,
                return false;
            }

        }//IsTwoPair()


        public static bool IsOnePair(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();
            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();
            int sameCount = 0;

            // 중복 수 체크!!!
            if (numberSortList.Count == numberSortList.Distinct().Count())
            { // 중복이 있으면,
                //숫자만 뽑아서 담아둘 리스트 생성.
                List<int> searchList = new List<int>();

                for (int i = 0; i < numberSortList.Count; i++)
                {
                    searchList.Add(numberSortList[i].cardNumber); //하나씩 숫자만 add
                }
                int temNum = searchList[0];
                for (int i = 1; i < searchList.Count - 1; i++)
                {

                    if (temNum == searchList[i])
                    {
                        ++sameCount;
                        if (sameCount == 1)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        temNum = searchList[i];
                        sameCount = 0;
                    }
                }
                return false;
            }
            else
            {// 중복이 아에 없으면,
                return false;
            }
        }//IsOnePair()

        public static int TopNumber(List<Card> cardList)
        {
            List<Card> numberSortList = new List<Card>();

            //number 로 정렬
            numberSortList = cardList.OrderBy(x => x.cardNumber).ToList();

            // 중복 제거해서 담아둘 리스트 생성.
            List<int> searchList = new List<int>();

            for (int i = 0; i < numberSortList.Count; i++)
            {
                if (!searchList.Contains(numberSortList[i].cardNumber))
                { //동일한게 searchList 에 없으면,
                    searchList.Add(numberSortList[i].cardNumber); //추가
                }
            }

            //number 로 정렬
            searchList.Reverse();

            //가장 마지막 인덱스의 넘버 반환
            return searchList[0];

        }//TopNumber()

       
    }
}
