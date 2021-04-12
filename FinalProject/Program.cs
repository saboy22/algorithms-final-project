using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var matrix = new int[][]
            {
                new int[] { 0, 20, 15, 0, 0, 10,0 }, //0
                new int[] { 20, 0, 40, 0, 0, 30, 0 }, //1
                new int[] { 15, 40, 0, 10, 0, 0, 0 }, //2
                new int[] { 0, 0, 10, 0, 15, 0, 0 }, //3
                new int[] { 0, 0, 0, 15, 0, 0, 0 }, //4
                new int[] { 10, 30, 0, 0, 0, 0, 20 }, //5
                new int[] { 0, 0, 0, 0, 0, 20, 0 }, //6
            };
            var graph = new Graph(matrix);
            Console.WriteLine("Scenario 1:");
            graph.Transvere(0);
            Console.WriteLine("Scenario 2:");
            graph.Transvere(6);
            Console.WriteLine("Scenario 3:");
            graph.GetTotalCost(0);
            Console.WriteLine("Scenario 4:");
            graph.GetNeighborsAndWeights(0);

            Console.ReadLine();
        }
        //To add another value to the graph add new row and column to the matrix then adjust
        //the array sizes located in the Vertex class to what sees fitting for the new size of the graph
        //adjust the array sizes loacated under the Graph class under the methods Traveling Alogorithm & TotalCost
        //my algorith prioritizes the lowest vertex or node value to travel through the graph
    }
}
