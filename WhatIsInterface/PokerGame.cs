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
                Console.WriteLine("card :[{0}], num :{1}",card.cardMark, card.cardNumber);
            }
            //유저 카드 5개 뽑아오고,
            List<Card> userCards = new List<Card>();
            userCards = trumpCard.RandomCards(5);

            foreach (Card card in userCards)
            {
                Console.WriteLine("Card :[{0}], num :{1}", card.cardMark, card.cardNumber);
            }

        }
    }



}





