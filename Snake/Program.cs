namespace Snake
{
    internal class Program
    {
        // Что первое я буду делать
        // какие структуры данных я буду использовать
        // какие блоки я буду использовать

        // Стены убрать и добавление в произвольном месте
        // голова змеи 
        // умирает если касается себя
        #region Переменные взаимодействия с игрой

        //Состояния движения
        enum State
        {
            Top,
            Down,
            Left,
            Right,
            None,
            GameOver,
        }

        //Размер поля
        const byte polSize = 9;
        
        //Время ожидания между обновлениями поля
        static short delay = 200;

        //Рандомная позиция
        static Random randPosition =new Random();
        
        //Количество еды скушанной змейкой
        static int count = 0;

        //Позиция игрока
        static Queue<(byte y, byte x)> head = new();
        static (byte y,byte x) last_Position =(0,0);

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
                for (byte y = head.Peek().y; state == State.Down; y++)
                {

                if (head.Count > 0)
                {
                    var old_lock = head.Dequeue();
                    last_Position = old_lock;
                }
                head.Enqueue((y, head.Peek().x));
                   
                    UpdateState();
                }
            
        }

        //Движение вверх
        static void TopForward()
        {
            state = State.Top;
            for (byte y = head.First().y; state == State.Top; y--)
            {
                if (head.Count > 0)
                {
                    var old_lock = head.Dequeue();
                    last_Position = old_lock;
                }
                head.Enqueue((y, head.Peek().x));
                UpdateState();
            }
        }

        //Движение в лево
        static void LeftForward()
        {
            state = State.Left;

            for (byte x = head.First().x;  state == State.Left; x--)
            {
                if (head.Count > 0)
                {
                    var old_lock = head.Dequeue();
                    last_Position = old_lock;
                }
                head.Enqueue((head.Peek().y, x));
                UpdateState();
            }
        }

        //Движение в право
        static void RightForward()
        {
            state = State.Right;
            for (byte x = head.First().x;state == State.Right; x++)
            {
                    if(head.Count > 0)
                    {
                    var old_lock = head.Dequeue();
                    last_Position = old_lock;
                    }
                    head.Enqueue((head.Peek().y, x));
                    UpdateState();
            }
        }

        //Проверка не съел ли еду
        static void CheckEat()
        {
            if (head.Count > 0)
            {
                if (eat_Position.x == head.Peek().x &&
                    eat_Position.y == head.Peek().y)
                {
                    count += 1;
                    EatNewPosition();

                    head.Enqueue(last_Position);

                }
            }
        }

        //Новая позиция еды
        static void EatNewPosition()=>
                                eat_Position = 
                                ((byte)(randPosition.Next(polSize)), 
                                (byte)(randPosition.Next(polSize)));

        ////Вывод игры 
        static void OutputGame()
        {
            for (byte y = 0; y != 20; y++)
            {
                for (byte x = 0; x != 20; x++)
                {
                    foreach (var item in head)
                    {
                        if (item.x == x && item.y == y)
                        {
                            Console.Write(Player);
                        }
                    }

                    if (eat_Position.x == x && eat_Position.y == y)
                    {
                        Console.Write(Eat);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
            Console.Write($"\nEat: {count} \n");
        }

        static void Main(string[] args)
        {
            head.Enqueue((0, 0));
            head.Enqueue((0, 1));
            while (true)
            {
                UserInput();
                UpdateState();
            }
        }

       
    }
    
}
