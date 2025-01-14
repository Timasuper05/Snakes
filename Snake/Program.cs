namespace Snake
{
    internal class Program
    {
        // Что первое я буду делать
        // какие структуры данных я буду использовать
        // какие блоки я буду использовать


        #region Переменные взаимодействия с игрой

        //Состояния движения
        enum State
        {
            Top,
            Down,
            Left,
            Right,
            None,
        }

        //Размер поля
        const byte polSize = 10;
        
        //Время ожидания между обновлениями поля
        static short delay = 700;

        //Рандомная позиция
        static Random randPosition =new Random();
        
        //Количество еды скушанной змейкой
        static int count = 0;

        //Позиция игрока
        static (byte y, byte x) player_position = (0, 0);

        //Позиция еды с заданием значения по умолчанию а то есть рандомной позицией
        static (byte y, byte x) eat_Position = new ((byte)(new Random().Next(polSize)), (byte)(new Random().Next(polSize)));
        
        //Состояние по умолчанию
        static State state = State.None;
        #endregion

        #region Символы отображения игрового поля

        //Символ еды
        static char Eat = 'o';
        
        //Символ поля
        static char Poleygon = '*';
        
        //Символ игрока
        static char Player = '@';
        #endregion

        //Считывание пользовательского ввода
        static void UserInput()
        {
            if (state == State.None)
            {
                RightForward();
            }

            if (Console.KeyAvailable)
            {
                state = new State();

                ConsoleKey userKey = Console.ReadKey(true).Key;

                switch (userKey)
                {
                    case ConsoleKey.W:
                        TopForward();
                        break;
                    case ConsoleKey.S:
                        DownForward();
                        break;
                    case ConsoleKey.A:
                        LeftForward();
                        break;
                    case ConsoleKey.D:
                        RightForward();
                        break;
                }
            }
        }

        //Обновление состояния игры
        static void UpdateState()
        {
            Thread.Sleep(delay);
            Console.Clear();
            CheckEat();
            OutputGame();
            UserInput();
        }

        //Движение вниз
        static void DownForward()
        {
            state = State.Down;
            for (int y = 0; y != polSize || state == State.Down; y++)
            {
                player_position.y++;
                if (player_position.y >= polSize)
                    player_position.y = 0;
                
                UpdateState();
            }
        }

        //Движение вверх
        static void TopForward()
        {
            state = State.Top;
            for (byte y = 0; y != polSize || state == State.Top; y++)
            {
                if (player_position.y <= 0)
                    player_position.y = polSize;
                
                player_position.y--;
                UpdateState();
            }
        }

        //Движение в лево
        static void LeftForward()
        {
            state = State.Left;
            for (int y = 0; y != polSize || state == State.Left; y++)
            {
                if (player_position.x <= 0)
                    player_position.x = polSize;
                player_position.x--;

                UpdateState();
            }
        }

        //Движение в право
        static void RightForward()
        {
            state = State.Right;
            for (int y = 0; y != polSize || state == State.Right; y++)
            {
                player_position.x++;
                if (player_position.x == polSize)
                    player_position.x = 0;
                
                UpdateState();
            }
        }

        //Проверка не съел ли еду
        static void CheckEat()
        {
            if (eat_Position.x == player_position.x &&
                eat_Position.y == player_position.y)
            {
                count+=1;
                EatNewPosition();
            }
        }

        //Новая позиция еды
        static void EatNewPosition()=>
                                eat_Position = 
                                ((byte)(randPosition.Next(polSize)), 
                                (byte)(randPosition.Next(polSize)));
        
        //Вывод игры 
        static void OutputGame()
        {
            for (byte y = 0; y != polSize; y++)
            {
                for (byte x = 0; x != polSize; x++)
                {
                    if (player_position.x == x && player_position.y == y)
                    {
                        Console.Write(Player);
                    }
                    else if(eat_Position.x == x && eat_Position.y == y)
                    {
                        Console.Write(Eat);
                    }
                    else
                    {
                        Console.Write(Poleygon);
                    }
                }
                Console.Write("\n");
            }
            Console.Write($"\nEat: {count} \n");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                UserInput();
                UpdateState();
            }
        }

       
    }
    
}
