using System;
using System.Collections.Generic;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] deck = new bool[4,9];

            for (int i = 0; i<=3; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    deck[i, j] = false;
                }
            }

            Console.WriteLine("Введите кол-во игроков: ");
            int amountPlayers = Convert.ToInt32(Console.ReadLine());
            int trump;
            
            List<Hand> hands = new List<Hand>();

            trump = Lib.rand.Next(4);

            Console.WriteLine("Козырь: " + Lib.SuitDictionary[trump]);

            for (int i = 0; i != amountPlayers; i++)
            {
                var hand = Lib.getHand(deck);

                hand.calculateWeight(trump);
                hands.Add(hand);
            }

            int maxVes = -1;
            int maxInd = -1;

            for (int ind = 0; ind != hands.Count; ind++)
            {
                var _ruka = hands[ind];

                Console.WriteLine("Рука № " + ind);

                string str = "";

                foreach (var item in _ruka.cards)
                {
                    str += " " + Lib.SuitDictionary[item.suit] + " " + Lib.RankDictionary[item.rank] + ", ";
                }

                Console.WriteLine(str);

                if (maxVes < _ruka.weight)
                {
                    maxInd = ind;
                    maxVes = _ruka.weight;
                } 
            }

            Console.WriteLine("Самая сильная рука: " + maxInd);
            Console.ReadKey();
        }
    }
}
