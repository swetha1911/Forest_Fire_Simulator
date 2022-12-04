using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Forest_Fire_Simulator
{
    public class GridDisplay
    {
        public enum GridStatus
        {
            EMPTY,
            TREE,
            BURNING,
            FIRE
        }

        int[,] grid;
        const string BURNING = "x";
        const string TREE = "&";
        const string EMPTY = ".";
        const string BORDER_CHAR = "+";

        public GridDisplay(int gridSize)
        {
            this.grid = new int[gridSize, gridSize];
            initializeGridWithTree(gridSize);
        }

        void initializeGridWithTree(int gridSize)
        {
            int i = 0, j = 0;
            while (i < gridSize)
            {
                j = 0;
                while (j < gridSize)
                {
                    this.grid[i, j] = (int)GridStatus.TREE;
                    j++;
                }
                i++;
            }
        }

        public int[,] getGrid()
        {
            return this.grid;
        }

        public void displayGrid()
        {
            Console.WriteLine("+ + + + + + + + + + + + + + + + + + + + + + +");
            int size = this.grid.GetLength(0);
            for (int x = 0; x < size; x++)
            {
                Console.Write(BORDER_CHAR + " ");
                for (int y = 0; y < size; y++)
                {
                    Console.Write(getGridData(this.grid[x, y]) + ' ');
                }
                Console.WriteLine(BORDER_CHAR + " ");
            }
            Console.WriteLine("+ + + + + + + + + + + + + + + + + + + + + + +");
        }

        public string getGridData(int gridStatus)
        {
            if (gridStatus == ((int)GridStatus.EMPTY))
            {
                return EMPTY;
            }
            if (gridStatus == ((int)GridStatus.TREE))
            {
                return TREE;
            }
            if ((gridStatus == (int)GridStatus.BURNING) || (gridStatus == (int)GridStatus.FIRE))
            {
                return BURNING;
            }
            return " ";
        }

        public void emptyBurningTreesInGrid()
        {
            int i = 0, j = 0, gridSize = this.grid.GetLength(0);
            while (i < gridSize)
            {
                j = 0;
                while (j < gridSize)
                {
                    if (this.grid[i, j] == (int)GridStatus.BURNING)
                    {
                        this.grid[i, j] = (int)GridStatus.EMPTY;
                    }
                    j++;
                }
                i++;
            }

        }

        public void setFireInGrid(int i, int j)
        {
            int gridSize = this.grid.GetLength(0);
            if (grid[i, j] == (int)GridDisplay.GridStatus.TREE)
            {
                if (i - 1 > 0 && (grid[i - 1, j] == (int)GridDisplay.GridStatus.BURNING || grid[i - 1, j] == (int)GridDisplay.GridStatus.FIRE))
                {
                    grid[i, j] = (int)GridDisplay.GridStatus.FIRE;
                }
                if (j - 1 > 0 && (grid[i, j - 1] == (int)GridDisplay.GridStatus.BURNING || grid[i, j - 1] == (int)GridDisplay.GridStatus.FIRE))
                {
                    grid[i, j] = (int)GridDisplay.GridStatus.FIRE;
                }
                if (i + 1 < gridSize && (grid[i + 1, j] == (int)GridDisplay.GridStatus.BURNING || grid[i + 1, j] == (int)GridDisplay.GridStatus.FIRE))
                {
                    grid[i, j] = (int)GridDisplay.GridStatus.FIRE;
                }
                if (j + 1 < gridSize && (grid[i, j + 1] == (int)GridDisplay.GridStatus.BURNING || grid[i, j +1] == (int)GridDisplay.GridStatus.FIRE))
                {
                    grid[i, j] = (int)GridDisplay.GridStatus.FIRE;
                }
            }
        }
    }
}
