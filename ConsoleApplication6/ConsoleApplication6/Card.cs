using System;
using System.Collections.Generic;

namespace ConsoleApplication6
{
    static public class Lib
    {
        static public Random rand = new Random();

        public static Dictionary<int, string> SuitDictionary = new Dictionary<int, string>
        {
            // Задаём масти
            { 0, "Чирва"  },
            { 1, "Пика"   },
            { 2, "Буба"   },
            { 3, "Крести" }
        };

        public static Dictionary<int, string> RankDictionary = new Dictionary<int, string>
        {
            // Задаём ранги
            { 0, "6"      },
            { 1, "7"      },
            { 2, "8"      },
            { 3, "9"      },
            { 4, "10"     },
            { 5, "Валет"  },
            { 6, "Дама"   },
            { 7, "Король" },
            { 8, "Туз"    }
        };

        static public Hand getHand(bool[,] deck) // Получаем данные о комбинации карт в руке
        {
            var hand = new Hand();

            int _suit = 0, _rank = 0;

            for (int i = 0; i != 6; i++)
            {
                do
                {
                    _suit = rand.Next(4);
                    _rank = rand.Next(9);
                } while (deck[_suit, _rank]);

                deck[_suit, _rank] = true;
                hand.cards.Add(new Card(_suit, _rank));
            }

            return hand;
        }
    }

    public class Card // Класс карты
    {
        public int suit;
        public int rank;

        public Card(int _suit, int _rank)
        {
            suit = _suit;
            rank = _rank;
        }
    }

    public class Hand // Класс руки
    {
        public List<Card> cards = new List<Card>(); // Создаём карты
        public int weight = 0;

        public void calculateWeight(int trump) // Расчитываем вес карты
        {
            weight = -1;

            foreach (var item in cards)
            {
                if (item.suit == trump)
                {
                    if (weight < item.rank)
                    {
                        weight = item.rank;
                    }
                }
            }

            if (weight == -1)
            {
                foreach (var item in cards)
                {
                    if (weight < item.rank)
                    {
                        weight = item.rank;
                    }

                    if (weight == 8)
                    {
                        break;
                    }                    
                }
            }
            else
            {
                weight += 10;
            }
        }
    }
}