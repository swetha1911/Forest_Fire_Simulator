namespace Project_Forest_Fire_Simulator
{
    /**
     * Program class
     */
    public class Program
    {
        /**
         * Main method of the Forest Fire Simulator application.
         */
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter mode of fire simulation:\nPress 1 for Natural (Via Lightning)\nPress 2 for Man Made");
            int mode = Convert.ToInt32(Console.ReadLine());
            ForestFire forestFire;
            if (mode == 1)
            {
                Console.WriteLine("Enter probability of lightning strike at each step (0 to 100)");
                int lightningProbability = Convert.ToInt32(Console.ReadLine());
                if (lightningProbability < 0 || lightningProbability > 100)
                {
                    showInvalidInputError();
                    return;
                }
                NaturalFireSimulation naturalFireSimulation = new NaturalFireSimulation(lightningProbability);
                forestFire = new ForestFire(naturalFireSimulation);
            }
            else if (mode == 2)
            {
                Console.WriteLine("Enter position of x and y axis of the tree in the grid to set fire (Grid Size: 21)");
                int xPosition = Convert.ToInt32(Console.ReadLine()) - 1;
                int yPosition = Convert.ToInt32(Console.ReadLine()) - 1;
                if (xPosition < 0 || xPosition > 20 || yPosition < 0 || yPosition > 20)
                {
                    showInvalidInputError();
                    return;
                }
                ManMadeFireSimulation manMadeFireSimulation = new ManMadeFireSimulation(new int[] { xPosition, yPosition });
                forestFire = new ForestFire(manMadeFireSimulation);
            }
            else
            {
                showInvalidInputError();
                return;
            }
            forestFire.startForestFire();

        }

        /**
         * Method that is used to print "Invalid Input" in console.
         */
        public static void showInvalidInputError()
        {
            Console.WriteLine("Invalid Input");
        }
    }
}