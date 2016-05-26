using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorialOptimization
{
    public class TabuSearch
    {
        public static int[] GetBestNeighbour(TspList tabuList,
                TSPEnvironment tspEnviromnet,
                int[] initSolution)
        {
            
            int[] bestSol = new int[initSolution.Length]; //this is the best Solution So Far
            Array.Copy(initSolution, 0, bestSol, 0, bestSol.Length);
            int bestCost = tspEnviromnet.GetObjectiveFunctionValue(initSolution);
            int city1 = 0;
            int city2 = 0;
            bool firstNeighbor = true;

            for (int i = 1; i < bestSol.Length - 1; i++)
            {
                for (int j = 2; j < bestSol.Length - 1; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    int[] newBestSol = new int[bestSol.Length]; //this is the best Solution So Far
                    Array.Copy(bestSol, 0, newBestSol, 0, newBestSol.Length);

                    newBestSol = SwapOperator(i, j, initSolution); //Try swapping cities i and j
                                                                   // , maybe we get a bettersolution
                    int newBestCost = tspEnviromnet.GetObjectiveFunctionValue(newBestSol);
                    
                    if ((newBestCost > bestCost || firstNeighbor) && tabuList.tabuList[i, j] == 0)
                    { //if better move found, store it
                        firstNeighbor = false;
                        city1 = i;
                        city2 = j;
                        Array.Copy(newBestSol, 0, bestSol, 0, newBestSol.Length);
                        bestCost = newBestCost;
                    }
                }
            }

            if (city1 != 0)
            {
                tabuList.decrementTabu();
                tabuList.tabuMove(city1, city2);
            }
            return bestSol;


        }

        //swaps two cities
        public static int[] SwapOperator(int city1, int city2, int[] solution)
        {
            int temp = solution[city1];
            solution[city1] = solution[city2];
            solution[city2] = temp;
            return solution;
        }
    }
}
