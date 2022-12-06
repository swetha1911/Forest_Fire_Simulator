using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Forest_Fire_Simulator
{
    public class ForestFire
    {
        GridDisplay gridDisplay;
        ManMadeFireSimulation manMadeFireSimulation;

        public ForestFire(ManMadeFireSimulation manMadeFireSimulation)
        {
            this.manMadeFireSimulation = manMadeFireSimulation;
            gridDisplay = new GridDisplay(21);
        }

        public void startForestFire()
        {
            int[,] grid = this.gridDisplay.getGrid();
            int[] position = this.manMadeFireSimulation.getPosition();
            grid[position[0], position[1]] = (int)GridDisplay.GridStatus.BURNING;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Forest Fire Simulation - Man Made\n");
                Console.WriteLine("Forest Fire started at position: " + position[0] + "," + position[1]);
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
                        if (this.setFireInGrid(getProbabilityForForestFire()))
                        {
                            this.gridDisplay.setFireInGrid(i, j);
                        }
                        j++;
                    }
                    i++;
                }
                this.gridDisplay.emptyBurningTreesInGrid();
            }

        }

        public int getProbabilityForForestFire()
        {
            Random random = new Random();
            return random.Next(30, 70);
        }

        public Boolean setFireInGrid(int probability)
        {
            Random randomNumberGen = new Random();
            int randomNumber = randomNumberGen.Next(0, 100);
            if (randomNumber < probability)
            {
                return true;
            }
            return false;
        }
    }
}
