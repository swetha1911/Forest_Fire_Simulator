namespace Project_Forest_Fire_Simulator
{
    /**
     * ManMadeFireSimulation class - Represents Forest Fire caused by Man made activity.
     */
    public class ManMadeFireSimulation
    {
        int[] position;
        int probability;
        Random random = new Random();

        /**
         * Constructor: Used to create object of ManMadeFireSimulation
         */
        public ManMadeFireSimulation(int[] position)
        {
            this.position = position;
        }

        /**
         * Method is used to get probability of fire spread due to man made activity.
         */
        public int getProbability()
        {
            this.probability = random.Next(30, 80);
            return this.probability;
        }

        /**
         * Method is used to get position of the forest where fire started.
         */
        public int[] getPosition()
        {
            return this.position;
        }
    }
}