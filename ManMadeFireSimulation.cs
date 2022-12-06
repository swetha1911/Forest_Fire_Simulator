using System;

namespace Project_Forest_Fire_Simulator
{
    public class ManMadeFireSimulation
    {
        int[] position;
        int probability;

        public ManMadeFireSimulation(int[] position)
        {
            this.position = position;
        }

        public int getProbability()
        {
            Random random = new Random();
            this.probability = random.Next(30, 80);
            return this.probability;
        }

        public int[] getPosition()
        {
            return this.position;
        }
    }
}