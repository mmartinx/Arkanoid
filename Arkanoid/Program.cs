namespace Arkanoid
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Arkanoid())
            {
                game.Run();
            }
        }
    }
}
