namespace Snake
{
    internal class Program
    {
        // Что первое я буду делать
        // какие структуры данных я буду использовать
        // какие блоки я буду использовать


        private const byte polSize = 10;
        public static byte[,] polygon = new byte[polSize, polSize];
        public static (byte y, byte x) startPos = (0, 0);
        public static bool downRun = false;
        public static bool topRun = false;
        public static bool leftRun = false;
        public static bool rightRun = false;
        public static int defa = 1;
        static void UserInput()
        {
            if (defa == 1)
            {
                defa = 0;
                rightRun = true;
                RightForward();
            }
            if (Console.KeyAvailable)
                {
                ConsoleKey userKey = Console.ReadKey(true).Key;
                if (userKey == ConsoleKey.W)
                    {
                        //UpForward();
                       downRun = false;
                    topRun = true;
                    leftRun = false;
                    rightRun = false;
                        TopForward();
                        startPos.y--;
                    }
                    if (userKey == ConsoleKey.S)
                    {
                    topRun = false;
                       downRun = true;
                    leftRun= false;
                    rightRun= false;
                       DownForward();
                    startPos.y++;
                }
                    if (userKey == ConsoleKey.A)
                    {
                        topRun= false;
                    downRun = false;
                    rightRun = false;
                    leftRun = true;
                        LeftForward();
                    startPos.x++;
                }
                    if (userKey == ConsoleKey.D)
                    {
                    topRun = false;
                    downRun = false;
                    rightRun = true;
                    leftRun = false;
                    RightForward();
                    startPos.x--;
                }
                    //PolOutput(polygon);
                
            }
        }
        static void DownForward()
        {
                    for (int y = 0; y != polSize || downRun; y++)
                    {
                          UserInput();
                            startPos.y++;
                        if (startPos.y >= polSize)
                        {
                            startPos.y = 0;
                        }
                        Thread.Sleep(1000);
                        Console.Clear();
                        PolOutput(polygon);
                        
                    }

        }
        static void TopForward()
        {
            for (int y = 0; y != polSize || topRun; y++)
            {
                UserInput();
                if (startPos.y <= 0)
                {
                    startPos.y = polSize;
                }
                startPos.y--;
                Thread.Sleep(1000);
                Console.Clear();
                PolOutput(polygon);
            }

        }
        static void RightForward()
        {
            for (int y = 0; y != polSize || rightRun; y++)
            {
                startPos.x++;
                if (startPos.x == polSize)
                {
                    startPos.x = 0;
                }
                Thread.Sleep(1000);
                Console.Clear();
                PolOutput(polygon);
                UserInput();
            }

        }
        static void LeftForward()
        {
            for (int y = 0; y != polSize || leftRun; y++)
            {
                if (startPos.x <= 0)
                {
                    startPos.x = polSize;
                }
                startPos.x--;
                Thread.Sleep(1000);
                Console.Clear();
                PolOutput(polygon);
                UserInput();
            }

        }
        static void Main(string[] args)
        {
            PolOutput(polygon);
            while (true)
            {
                
                UserInput();
                Thread.Sleep(1000);
                Console.Clear();
                PolOutput(polygon);
                //var s = Console.ReadKey();


                //if (s.Key == ConsoleKey.D)
                //{
                //    startPos.x++;
                //    if (startPos.x == polSize)
                //    {
                //        startPos.x = 0;
                //    }
                //    Console.Clear();

                //}
                //if (s.Key == ConsoleKey.S)
                //{
                //    startPos.y++;
                //    if (startPos.y == polSize)
                //    {
                //        startPos.y = 0;
                //    }
                //    Console.Clear();
                //}
                //if (s.Key == ConsoleKey.W)
                //{

                //    if (startPos.y == 0)
                //    {
                //        startPos.y = polSize;
                //    }
                //    startPos.y--;

                //}
                //if (s.Key == ConsoleKey.A)
                //{

                //    if (startPos.x == 0)
                //    {
                //        startPos.x = polSize;
                //    }
                //    startPos.x--;

                //}

            }
        }

        public static void PolOutput(byte[,] pol)
        {

            for (byte y = 0; y != polSize; y++)
            {
                for (byte x = 0; x != polSize; x++)
                {
                    if (startPos.x == x && startPos.y == y)
                    {
                        Console.Write('a');

                    }
                    else
                    {
                        Console.Write($"*");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
