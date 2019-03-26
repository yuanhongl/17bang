using System;

namespace dichotomy
{
    class Program
    {
        static void Main(string[] args)
        {
            //游戏次数
            int gameTime = 1;
            Console.Write($"欢迎第{gameTime}次来玩猜数字游戏，我要玩请输入Y，自动玩输入A，不玩输入任意键：");
            string key = Console.ReadLine();
            Console.WriteLine("请输入一个最大值，用于生成随机数：");
            //设立最大值
            int max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入尝试次数：");
            //允许猜次数
            int times = Convert.ToInt32(Console.ReadLine());
            while (key.ToUpper().Substring(0, 1) == "A"||key.ToUpper().Substring(0, 1) == "Y")
            {
                if(key.ToUpper().Substring(0, 1) == "A")
                    AutoGame(max, times);
                else
                    RandomGame(max, times);
                Console.WriteLine();
                gameTime++;
                Console.Write($"欢迎第{gameTime}次来玩猜数字游戏，我要玩请输入Y，自动玩输入A，不玩输入任意键：");
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
                Console.WriteLine($"请输入您认为的数(不大于{max})：");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == random)
                {
                    Console.WriteLine($"恭喜，您猜对了，次数为{i+1}！");
                    guess = true;
                    break;
                }
                else if (input > random)
                {
                    Console.WriteLine($"您猜的数字大了，还剩{times-1-i}次。");
                }
                else
                {
                    Console.WriteLine($"您猜的数字小了，还剩{times - 1 - i}次。");
                }
            }
            if (!guess)
            {
                Console.WriteLine($"欢迎您下次再玩，数字为{random}");
            }
        }

        static private void AutoGame(int max, int times)
        {
            //生成一个随机数
            int random = new Random().Next(max);
            Console.WriteLine("随机数已生成。");
            //被猜中
            bool guess = false;
            int minNum = 0, midNum, maxNum = max;
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine($"请输入您认为的数(不大于{max})：");
                midNum = (maxNum + minNum) / 2;
                Console.WriteLine($"{midNum}");
                if (midNum == random)
                {
                    Console.WriteLine($"恭喜，您猜对了，次数为{i + 1}！");
                    guess = true;
                    break;
                }
                else if (midNum > random)
                {
                    Console.WriteLine($"您猜的数字大了，还剩{times - 1 - i}次。");
                    maxNum = midNum;
                }
                else
                {
                    Console.WriteLine($"您猜的数字小了，还剩{times - 1 - i}次。");
                    minNum = midNum;
                }
            }
            if (!guess)
            {
                Console.WriteLine($"欢迎您下次再玩，数字为{random}");
            }
        }
    }
}
