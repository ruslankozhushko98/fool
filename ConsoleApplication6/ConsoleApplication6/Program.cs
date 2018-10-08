using System;
using System.Collections.Generic;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] deck = new bool[4,9]; // Создаём колоду

            for (int i = 0; i<=3; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    deck[i, j] = false;
                }
            }

            Console.WriteLine("Макс. кол-во игроков: 6");
            Console.WriteLine("Введите кол-во игроков: ");

            int amountPlayers = Convert.ToInt32(Console.ReadLine()); // Указываем кол-во игроков

            if (amountPlayers > 6)
            {
                // Ограничение на 6 игроков
                Console.WriteLine("Недопустимое кол-во игроков!");
                Console.ReadKey();

                return;
            }

            int trump;
            
            List<Hand> hands = new List<Hand>(); // Создаём игроков

            trump = Lib.rand.Next(4); // Выбираем козырь

            Console.WriteLine("Козырь: " + Lib.SuitDictionary[trump]);

            for (int i = 0; i != amountPlayers; i++)
            {
                var hand = Lib.getHand(deck);

                hand.calculateWeight(trump);
                hands.Add(hand);
            }

            int maxWeight = -1;
            int maxInd    = -1;

            for (int ind = 0; ind != hands.Count; ind++)
            {
                var _hand = hands[ind];

                Console.WriteLine("Игрок № " + ind);

                string str = "";

                foreach (var item in _hand.cards)
                {
                    str += " " + Lib.SuitDictionary[item.suit] + " " + Lib.RankDictionary[item.rank] + ", ";
                }

                Console.WriteLine(str);

                if (maxWeight < _hand.weight)
                {
                    maxInd    = ind;
                    maxWeight = _hand.weight;
                } 
            }

            Console.WriteLine("Самый сильный игрок: " + maxInd);
            Console.ReadKey();
        }
    }
}
