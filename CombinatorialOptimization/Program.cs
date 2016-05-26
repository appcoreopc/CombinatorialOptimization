using System;

namespace CombinatorialOptimization
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteHillClimbing();
            ExecuteTabuSearch();
            Console.ReadLine();
        }

        private static void ExecuteHillClimbing()
        {
            TSPEnvironment tspEnvironment = new TSPEnvironment();
            tspEnvironment.distances = //Distance matrix, 5x5, used to represent distances
                    new int[,]{
                            {0, 1, 3, 4, 5},
                            {1, 0, 1, 4, 8},
                            {3, 1, 0, 5, 1},
                            {4, 4, 5, 0, 2},
                            {5, 8, 1, 2, 0}};

            //Between cities. 0,1 represents distance between cities 0 and 1, and so on.

            int[] currSolution = new int[] { 0, 1, 2, 3, 4, 0 };   //initial solution
                                                                   //city numbers start from 0
                                                                   // the first and last cities' positions do not change

            int numberOfIterations = 100;
            int tabuLength = 5;
            TspList tabuList = new TspList(tabuLength);

            int[] bestSol = new int[currSolution.Length]; //this is the best Solution So Far
            Array.Copy(currSolution, 0, bestSol, 0, bestSol.Length);
            int bestCost = tspEnvironment.GetObjectiveFunctionValue(bestSol);

            for (int i = 0; i < numberOfIterations; i++)
            { // perform iterations here

                currSolution = HillClimbingSearch.GetBestNeighbour(tspEnvironment, currSolution);
                //printSolution(currSolution);
                int currCost = tspEnvironment.GetObjectiveFunctionValue(currSolution);

                //System.out.println("Current best cost = " + tspEnvironment.getObjectiveFunctionValue(currSolution));

                if (currCost < bestCost)
                {
                    Array.Copy(currSolution, 0, bestSol, 0, bestSol.Length);
                    bestCost = currCost;
                }
            }

            Console.WriteLine("Search done! \nBest Solution cost found = " + bestCost + "\nBest Solution :");

            PrintSolution(bestSol);


        }

        private static void ExecuteTabuSearch()
        {
            TSPEnvironment tspEnvironment = new TSPEnvironment();
            tspEnvironment.distances = //Distance matrix, 5x5, used to represent distances
                    new int[,]{
                            {0, 1, 3, 4, 5},
                            {1, 0, 1, 4, 8},
                            {3, 1, 0, 5, 1},
                            {4, 4, 5, 0, 2},
                            {5, 8, 1, 2, 0}};

            //Between cities. 0,1 represents distance between cities 0 and 1, and so on.

            int[] currSolution = new int[] { 0, 1, 2, 3, 4, 0 };   //initial solution
                                                                   //city numbers start from 0
                                                                   // the first and last cities' positions do not change

            int numberOfIterations = 100;
            int tabuLength = 5; 
            TspList tabuList = new TspList(tabuLength);

            int[] bestSol = new int[currSolution.Length]; //this is the best Solution So Far
            Array.Copy(currSolution, 0, bestSol, 0, bestSol.Length);
            int bestCost = tspEnvironment.GetObjectiveFunctionValue(bestSol);

            for (int i = 0; i < numberOfIterations; i++)
            { // perform iterations here

                currSolution = TabuSearch.GetBestNeighbour(tabuList, tspEnvironment, currSolution);
                //printSolution(currSolution);
                int currCost = tspEnvironment.GetObjectiveFunctionValue(currSolution);

                //System.out.println("Current best cost = " + tspEnvironment.getObjectiveFunctionValue(currSolution));

                if (currCost < bestCost)
                {
                    Array.Copy(currSolution, 0, bestSol, 0, bestSol.Length);
                    bestCost = currCost;
                }
            }

            Console.WriteLine("Search done! \nBest Solution cost found = " + bestCost + "\nBest Solution :");

            PrintSolution(bestSol);

        }

        public static void PrintSolution(int[] solution)
        {
            for (int i = 0; i < solution.Length; i++)
            {
                Console.Write(solution[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

