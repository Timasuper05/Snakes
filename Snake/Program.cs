namespace Snake
{
    internal class Program
    {
        // Что первое я буду делать
        // какие структуры данных я буду использовать
        // какие блоки я буду использовать
        
      
        private const byte polSize = 10;
        public static byte[,] polygon = new byte[polSize,polSize];
        public static (byte y, byte x) startPos = (0, 0);

        static void Main(string[] args)
        {
            PolOutput(polygon);
            while (true)
            {
                var s = Console.ReadKey();


                if (s.Key == ConsoleKey.D)
                {
                    startPos.x++;
                    if (startPos.x == polSize)
                    {
                        startPos.x = 0;
                    }
                    Console.Clear();

                }
                if (s.Key == ConsoleKey.S)
                {
                    startPos.y++;
                    if (startPos.y == polSize)
                    {
                        startPos.y = 0;
                    }
                    Console.Clear();
                }
                if (s.Key == ConsoleKey.W)
                {

                    if (startPos.y == 0)
                    {
                        startPos.y = polSize;
                    }
                    startPos.y--;
                    Console.Clear();
                }
                if (s.Key == ConsoleKey.A)
                {

                    if (startPos.x == 0)
                    {
                        startPos.x = polSize;
                    }
                    startPos.x--;
                    Console.Clear();
                }

                PolOutput(polygon);

            }

        }
        
        public static void PolOutput(byte[,] pol)
        {

            for(byte y= 0; y != polSize; y++) 
            {
                for (byte x= 0;x != polSize; x++)
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
