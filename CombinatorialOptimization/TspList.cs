namespace CombinatorialOptimization
{
    public class TspList
    {
        public int[,] tabuList;
        public int city; 
        public TspList(int numCities)
        {
            city = numCities;
            tabuList = new int[numCities, numCities]; //city 0 is not used here, but left for simplicity
        }

        public void tabuMove(int city1, int city2)
        { 
            //tabus the swap operation
            tabuList[city1, city2] += 5;
            tabuList[city2, city1] += 5;
        }

        public void decrementTabu()
        {
            for (int i = 0; i < city; i++)
            {
                for (int j = 0; j < city; j++)
                {
                    tabuList[i, j] -= tabuList[i, j] <= 0 ? 0 : 1;
                }
            }
        }
    }
    
    public class TSPEnvironment
    { 
        //Tabu Search Environment
        public int[,] distances;

        public TSPEnvironment()
        {
        }

        public int GetObjectiveFunctionValue(int[] solution)
        { 
            int cost = 0;
            for (int i = 0; i < solution.Length - 1; i++)
            {
                cost += distances[solution[i], solution[i + 1]];
            }
            return cost;
        }
    }
}
