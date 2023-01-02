using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsInterface
{
    public class PokerGame
    {



        public static void Main()
        {
            TrumpCard trumpCard = new TrumpCard();
            trumpCard.SetupTrumpCards();
            
            //컴퓨터 카드 5개 뽑아오고,
            List<Card> comCards = new List<Card>();
            comCards = trumpCard.RandomCards(5);

            foreach(Card card in comCards)
            {
                Console.WriteLine("mark :{0}, num :{1}",card.cardMark, card.cardNumber);
            }
            //유저 카드 5개 뽑아오고,
            List<Card> userCards = new List<Card>();
            userCards = trumpCard.RandomCards(5);

            foreach (Card card in userCards)
            {
                Console.WriteLine("mark :{0}, num :{1}", card.cardMark, card.cardNumber);
            }

        }
    }



        //public static void Cards()
        //{
        //    Dictionary<int, string> originCard = new Dictionary<int, string>();
        //    originCard.Add(1, "101/♣  1");
        //    originCard.Add(2, "102/♣  2");
        //    originCard.Add(3, "103/♣  3");
        //    originCard.Add(4, "104/♣  4");
        //    originCard.Add(5, "105/♣  5");
        //    originCard.Add(6, "106/♣  6");
        //    originCard.Add(7, "107/♣  7");
        //    originCard.Add(8, "108/♣  8");
        //    originCard.Add(9, "109/♣  9");
        //    originCard.Add(10, "110/♣ 10");
        //    originCard.Add(11, "111/♣  J");
        //    originCard.Add(12, "112/♣  Q");
        //    originCard.Add(13, "113/♣  K");
        //    originCard.Add(14, "201/♥  1");
        //    originCard.Add(15, "202/♥  2");
        //    originCard.Add(16, "203/♥  3");
        //    originCard.Add(17, "204/♥  4");
        //    originCard.Add(18, "205/♥  5");
        //    originCard.Add(19, "206/♥  6");
        //    originCard.Add(20, "207/♥  7");
        //    originCard.Add(21, "208/♥  8");
        //    originCard.Add(22, "209/♥  9");
        //    originCard.Add(23, "210/♥ 10");
        //    originCard.Add(24, "211/♥  J");
        //    originCard.Add(25, "212/♥  Q");
        //    originCard.Add(26, "213/♥  K");
        //    originCard.Add(27, "301/◆  1");
        //    originCard.Add(28, "302/◆  2");
        //    originCard.Add(29, "303/◆  3");
        //    originCard.Add(30, "304/◆  4");
        //    originCard.Add(31, "305/◆  5");
        //    originCard.Add(32, "306/◆  6");
        //    originCard.Add(33, "307/◆  7");
        //    originCard.Add(34, "308/◆  8");
        //    originCard.Add(35, "309/◆  9");
        //    originCard.Add(36, "310/◆ 10");
        //    originCard.Add(37, "311/◆  J");
        //    originCard.Add(38, "312/◆  Q");
        //    originCard.Add(39, "313/◆  K");
        //    originCard.Add(40, "401/♠  1");
        //    originCard.Add(41, "402/♠  2");
        //    originCard.Add(42, "403/♠  3");
        //    originCard.Add(43, "404/♠  4");
        //    originCard.Add(44, "405/♠  5");
        //    originCard.Add(45, "406/♠  6");
        //    originCard.Add(46, "407/♠  7");
        //    originCard.Add(47, "408/♠  8");
        //    originCard.Add(48, "409/♠  9");
        //    originCard.Add(49, "410/♠ 10");
        //    originCard.Add(50, "411/♠  J");
        //    originCard.Add(51, "412/♠  Q");
        //    originCard.Add(52, "413/♠  K");

        //    List<string> inItComCards = new List<string>();
        //    List<string> inItUserCards = new List<string>();
        //    inItComCards = RandomCard(originCard);
        //    inItUserCards = RandomCard(originCard);
        //}


}





