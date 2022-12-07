namespace Project_Forest_Fire_Simulator
{
    /*
     * GridDisplay Class - Used for displaying forest fire simulation in the console.
     */
    public class GridDisplay
    {
        /**
         * GridStatus enum - Maintains the status of each grid.
         * (Each grid represents a Tree in the forest)
         */
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

        /**
         * Constructor: Used to create GridDisplay object in specified size.
         * Params: Size of the forest.
         */
        public GridDisplay(int gridSize)
        {
            this.grid = new int[gridSize, gridSize];
            initializeGridWithTree(gridSize);
        }

        /**
         * Method used to initialize grid with GridState 'Tree'
         * Params: Size of the forest.
         */
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

        /**
         * Method used to get Grid (Forest).
         */
        public int[,] getGrid()
        {
            return this.grid;
        }

        /**
         * Method used to display the Forest details in the console with appropriate status. 
         */
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

        /**
         * Method used to get the ASCII character corresponding to the GridState.
         * Params: GridStatus in integer.
         */
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
            if (gridStatus == ((int)GridStatus.BURNING) || gridStatus == (int)GridStatus.FIRE)
            {
                return BURNING;
            }
            return " ";
        }

        /**
         * Method used to update GridState of burning trees to EMPTY.
         */
        public void emptyBurningTrees()
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

        /**
         * Method used to set fire in the mentioned position of the grid.
         * Params: Position of the grid in 2D array.
         */
        public void setFire(int i, int j)
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
                if (j + 1 < gridSize && (grid[i, j + 1] == (int)GridDisplay.GridStatus.BURNING || grid[i, j + 1] == (int)GridDisplay.GridStatus.FIRE))
                {
                    grid[i, j] = (int)GridDisplay.GridStatus.FIRE;
                }
            }
        }

    }
}