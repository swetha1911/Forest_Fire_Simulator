namespace Project_Forest_Fire_Simulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Forest Fire Simulation - Man Made\n");
            Console.WriteLine("Enter position of x and y axis of the tree in the grid to set fire (Grid Size: 21)");
            int xPosition = Convert.ToInt32(Console.ReadLine()) - 1;
            int yPosition = Convert.ToInt32(Console.ReadLine()) - 1;
            if (xPosition < 0 || xPosition > 20 || yPosition < 0 || yPosition > 20)
            {
                showInvalidInputError();
                return;
            }
            ManMadeFireSimulation manMadeFireSimulation = new ManMadeFireSimulation(new int[] { xPosition, yPosition });
            ForestFire forestFire = new ForestFire(manMadeFireSimulation);
            forestFire.startForestFire();

        }

        public static void showInvalidInputError()
        {
            Console.WriteLine("Invalid Input");
        }
    }
}