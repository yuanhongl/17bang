using System;

namespace dichotomy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个最大值，用于生成随机数：");
            //设立最大值
            int max = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("请输入尝试次数：");
            //允许猜次数
            int times = Convert.ToInt16(Console.ReadLine());
            //第一次玩
            RandomGame(max, times);
            Console.WriteLine();
            //游戏次数
            int gameTime = 2;
            Console.Write("欢迎第{0}次来玩猜数字游戏，我要玩请输入Y，不玩输入N:", gameTime);
            string key = Console.ReadLine();
            //继续玩就执行
            while (key.ToUpper().Substring(0, 1) == "Y")
            {
                RandomGame(max, times);
                Console.WriteLine();
                gameTime++;
                Console.Write("欢迎第{0}次来玩猜数字游戏，我要玩请输入Y，不玩输入N:", gameTime);
                key = Console.ReadLine();
            }
        }

        static private void RandomGame(int max, int times)
        {
            //生成一个随机数
            int random = new Random().Next(max);
            Console.WriteLine("随机数已生成。");
            //被猜中
            bool guess = false;
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("请输入您认为的数：");
                int input = Convert.ToInt16(Console.ReadLine());
                if (input == random)
                {
                    Console.WriteLine("恭喜，您猜对了，次数为{0}！", i + 1);
                    guess = true;
                    break;
                }
                else if (input > random)
                {
                    Console.WriteLine("您猜的数字大了，已经第{0}次。", i + 1);
                }
                else
                {
                    Console.WriteLine("您猜的数字小了，已经第{0}次。", i + 1);
                }
            }
            if (!guess)
            {
                Console.WriteLine("欢迎您下次再玩，数字为{0}", random);
            }
        }
    }
}
