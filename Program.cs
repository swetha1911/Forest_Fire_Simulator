namespace Project_Forest_Fire_Simulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter position to set fire in forest: (Grid Size: 21)");
            int xPosition = Convert.ToInt32(Console.ReadLine());
            int yPosition = Convert.ToInt32(Console.ReadLine());
            ForestFire forestFire = new ForestFire(xPosition, yPosition);
            forestFire.startForestFire();

        }
    }
}