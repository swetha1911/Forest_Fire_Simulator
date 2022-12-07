namespace Project_Forest_Fire_Simulator
{
    /**
     * NaturalFireSimulation class - Represents Forest Fire caused by Natural calamity.
     */
    public class NaturalFireSimulation
    {
        int probability;
        int[] position;
        Random random = new Random();

        /**
         * Constructor: Used to create object of NaturalFireSimulation with probability of lightning at every step
         * Params: Probability of lightning strike
         */
        public NaturalFireSimulation(int probability)
        {
            this.probability = probability;
            this.position = new int[2];
            generatePosition();
        }

        /**
         * Method that is used to get probability of the lightning strike in the forest.
         */
        public int getProbability()
        {

            return this.probability;
        }

        /**
         * Method that is used to get the position in which lightning strikes.
         */
        public int[] getPosition()
        {
            return this.position;
        }

        /**
         * Method that is used to generate position of the lightning strike.
         */
        public void generatePosition()
        {
            this.position[0] = (int)random.NextInt64(0, 21);
            this.position[1] = (int)random.NextInt64(0, 21);
        }
    }
}