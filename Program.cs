int width = 40;
int height = 40;
int score = 0;
List<(int,int)> snake = new List<(int,int)> ();
(int, int) food=(0,0);
(int, int) dir = (0, 1);
bool start = true;
Random rng = new Random ();

Console.SetWindowSize(width, height+2);
Console.SetBufferSize(width, height+2);

snake.Add((width/2, height/2));



while(start == true)
{
    plane();
    move();
    Thread.Sleep (1000);
}
Console.SetCursorPosition(0, height + 1);
Console.WriteLine($"Score:{score}");

void plane()
{
    for (int y = 0; y<height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            if (snake.Contains((x, y)))
            {
                Console.Write("O");
            }
            else if ((x, y) == food)
            {
                Console.Write("X");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
    Console.SetCursorPosition(0, height);
    Console.Write($"Score: {score}");
}

void move()
{
    var head = snake.First();
    var newHead = (head.Item1 + dir.Item1, head.Item2 + dir.Item2);

    if (newHead.Item1 < 0 || newHead.Item1 >= width || newHead.Item2 < 0 || newHead.Item2 >= height || snake.Contains(newHead))
    {
        start = true;
        return;
    }

    snake.Insert(0, newHead);

    if (newHead == food)
    {
        score++;
    }
    else
    {
        snake.RemoveAt(snake.Count - 1);
    }
}