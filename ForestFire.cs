namespace Project_Forest_Fire_Simulator
{
    /**
     * Forest Fire Class
     */
    public class ForestFire
    {
        GridDisplay gridDisplay;
        ManMadeFireSimulation manMadeFireSimulation;
        NaturalFireSimulation naturalFireSimulation;
        Random random = new Random();

        /**
         * Constructor used to create entity of Forest Fire for Man Made Simulation
         * Params: ManMadeFireSimulation
         */
        public ForestFire(ManMadeFireSimulation manMadeFireSimulation)
        {
            this.manMadeFireSimulation = manMadeFireSimulation;
            gridDisplay = new GridDisplay(21);
        }

        /**
         * Constructor used to create entity of Forest Fire for Natural Simulation.
         * Params: NaturalFireSimulation
         */
        public ForestFire(NaturalFireSimulation naturalFireSimulation)
        {
            this.gridDisplay = new GridDisplay(21); ;
            this.naturalFireSimulation = naturalFireSimulation;
        }
        
        /**
         * Method that simulates forest fire based on the entity in Forest Fire object.
         */
        public void startForestFire()
        {
            if (this.manMadeFireSimulation != null)
            {
                startManMadeForestFire();
            }
            else
            {
                startNaturalForestFire();
            }

        }

        /**
         * Method that simulates forest fire caused by man made activity.
         */
        void startManMadeForestFire()
        {
            int[,] grid = this.gridDisplay.getGrid();
            int[] position = this.manMadeFireSimulation.getPosition();
            grid[position[0], position[1]] = (int)GridDisplay.GridStatus.BURNING;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tForest Fire Simulation - Man Made\n");
                this.gridDisplay.displayGrid();
                Console.ReadLine();
                int i = 0, j = 0;
                while (i < 21)
                {
                    j = 0;
                    while (j < 21)
                    {
                        if (this.gridDisplay.getGrid()[i, j] == (int)GridDisplay.GridStatus.FIRE)
                        {
                            this.gridDisplay.getGrid()[i, j] = (int)GridDisplay.GridStatus.BURNING;
                        }
                        if (this.setFire(this.manMadeFireSimulation.getProbability()))
                        {
                            this.gridDisplay.setFire(i, j);
                        }
                        j++;
                    }
                    i++;
                }
                this.gridDisplay.emptyBurningTrees();
            }
        }
        /**
         * Method that simulates forest fire caused by natural activity.
         */
        void startNaturalForestFire()
        {
            int[,] grid = this.gridDisplay.getGrid();
            int[] position = this.naturalFireSimulation.getPosition();
            grid[position[0], position[1]] = (int)GridDisplay.GridStatus.BURNING;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tForest Fire Simulation - Natural\n");
                Console.WriteLine("Probability of Lightning at each step: " + this.naturalFireSimulation.getProbability());
                this.gridDisplay.displayGrid();
                if (this.setFire(this.naturalFireSimulation.getProbability()))
                {
                    this.naturalFireSimulation.generatePosition();
                    position = this.naturalFireSimulation.getPosition();
                    if (grid[position[0], position[1]] == (int)GridDisplay.GridStatus.TREE)
                    {
                        grid[position[0], position[1]] = (int)GridDisplay.GridStatus.FIRE;
                        Console.WriteLine("Lightning occurred and striked tree at position " + position[0] + " , " + position[1]);
                    }
                }
                Console.ReadLine();
                int i = 0, j = 0;
                while (i < 21)
                {
                    j = 0;
                    while (j < 21)
                    {
                        if (this.gridDisplay.getGrid()[i, j] == (int)GridDisplay.GridStatus.FIRE)
                        {
                            this.gridDisplay.getGrid()[i, j] = (int)GridDisplay.GridStatus.BURNING;
                        }
                        if (this.setFire(this.getProbability()))
                        {
                            this.gridDisplay.setFire(i, j);
                        }
                        j++;
                    }
                    i++;
                }
                this.gridDisplay.emptyBurningTrees();
            }

        }

        /**
         * Method that is used to generate probability percentage.
         */
        public int getProbability()
        {
            return random.Next(30, 70);
        }

        /**
         * Method that is used to check if fire can be spread based on the probability.
         * Params: Probability percentage
         */
        public Boolean setFire(int probability)
        {
            int randomNumber = random.Next(0, 100);
            if (randomNumber < probability)
            {
                return true;
            }
            return false;
        }

    }
}