using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace FinalProject
{
    class Graph
    {
        List<Vertex> vertices = new List<Vertex>();
        int[][] adjacencyMatrix;
        Vertex currentNode;

        public Graph(int[][] adjacencyMatrix)
        {
            this.adjacencyMatrix = adjacencyMatrix;
            int vertexCount = adjacencyMatrix.GetLength(0);

            // convert adjacency matrix into a list of Vertices.            
            for (int i = 0; i < vertexCount; i++)
            {

                var vertex = new Vertex
                {
                    // Set default values on each vertex.
                    Key = int.MaxValue, //infinity,
                    Parent = -1, // "nil"
                    Data = i

                };

                this.vertices.Add(vertex);
            }
            for (int i = 0; i < vertexCount; i++)
            {
                int k = 0;
                for (int j = 0; j < vertexCount; j++)
                {
                    if (adjacencyMatrix[i][j] != 0)
                    {
                        vertices[i].neighbor[k] = j;
                        vertices[i].weight[k] = adjacencyMatrix[i][j];
                        vertices[i].neighborVer[k] = vertices[j];

                        k++;
                    }
                }
            }
            currentNode = vertices[0];
        }
        public void Transvere(int inputNode)//O(n^2)
        {

            if (inputNode < 0 || inputNode > 6)
            {
                Console.WriteLine("please input a valid node");
                return;
            }

            var node = vertices[inputNode];
            int cost = 0;
            node.visits++;
          

            if (node == currentNode)
            {
                if (node.visits > 1)
                {
                    Console.WriteLine("you are currently at this node");
                    node.visits--;
                }
                else
                {
                    Console.WriteLine("you are at " + node.Data + " cost is " + cost);
                }
                return;

            }
            if (node != currentNode)
            {
                TravelAlgorithm(currentNode, node);//O(n^2)
                
                for (int i = 0; i < vertices.Count; i++)
                {
                    vertices[i].IsProcessed = false;
                }
                currentNode = node;
                return;
            }

            else
            {
                Console.WriteLine("Some unkown error occured");
                return;
            }


        }

        public void TravelAlgorithm(Vertex curNode, Vertex travelNode)//O(n^2)
        {
            Vertex startingNode = curNode;
            int[] visited = new int[6]; //change this value to the number or nodes/vertices
            Vertex[] visitedVer = new Vertex[6]; //change this value to the number or nodes/vertices
            string output = "";
            int j = 0;
            int cost = 0;
            int k = 0;
            while (true)
            {

                for (int i = 0; i < curNode.neighbor.Length; i++)
                {
                    if (travelNode == curNode.neighborVer[i])
                    {
                        for (int l = 0; l < visitedVer.Length; l++)
                        {
                            if (visitedVer[l] != null)
                            {
                                output += " ";
                                output += visited[l];
                            }
                        }
                        cost += curNode.weight[i];
                        Console.WriteLine("you were at:" + startingNode.Data + " you are at: " + travelNode.Data + " cost to get there was: " + cost
                            + " verticies visited to get to " + travelNode.Data + ":" + output);
                        return;
                    }
                }
                if (curNode.neighborVer[j] != null)
                {
                    if (curNode.neighborVer[j].IsProcessed == false)
                    {
                        curNode.IsProcessed = true;
                        cost += curNode.weight[j];
                        curNode = curNode.neighborVer[j];
                        visited[k] = curNode.Data;
                        visitedVer[k] = curNode;
                        k++;
                        j = 0;
                    }

                }
                if (curNode.neighborVer[j] != null)
                {
                    if (curNode.neighborVer[j].IsProcessed == true)
                    {
                        j++;
                    }
                    
                }
                else
                {
                    cost = 0;
                    j = 0;
                    k = 0;
                    curNode = startingNode;
                    Array.Clear(visited, 0, 6);
                    Array.Clear(visitedVer, 0, 6);


                }

            }


        }
        public void GetNeighborsAndWeights(int value) //O(N)
        {
            var node = vertices[value];
            var dictionary = new Dictionary<string, int>();

            for (int index = 0; index < node.weight.Length; index++)
            {
                dictionary.Add(node.neighbor[index].ToString(), node.weight[index]);
            }
            Console.WriteLine("neighbors for " + value);
            foreach (KeyValuePair<string, int> author in dictionary.OrderByDescending(key => key.Value))
            {

                Console.WriteLine("Node: {0}, Weight: {1}", author.Key, author.Value);
            }

        }

        public void GetTotalCost(int value) //O(n^2) :( 
        {
            var node = vertices[value];
            int totalCost = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (node != vertices[i])
                {
                    totalCost += TotalCost(node, vertices[i]);
                }
                for (int j = 0; j < vertices.Count; j++)
                {
                    vertices[j].IsProcessed = false;
                }

            }
            Console.WriteLine("The total cost to visit every node from " + node.Data + " is " + totalCost);
        }

        public int TotalCost(Vertex curNode, Vertex travelNode)
        {
            Vertex startingNode = curNode;
            int j = 0;
            int cost = 0;
            int k = 0;
            while (true)
            {

                for (int i = 0; i < curNode.neighbor.Length; i++)
                {
                    if (travelNode == curNode.neighborVer[i])
                    {

                        cost += curNode.weight[i];

                        return cost;
                    }
                }
                if (curNode.neighborVer[j] != null)
                {
                    if (curNode.neighborVer[j].IsProcessed == false)
                    {
                        curNode.IsProcessed = true;
                        cost += curNode.weight[j];
                        curNode = curNode.neighborVer[j];

                        k++;
                        j = 0;
                    }

                }
                if (curNode.neighborVer[j] != null)
                {
                    if (curNode.neighborVer[j].IsProcessed == true)
                    {
                        j++;
                    }
                    
                }
                else
                {
                    cost = 0;
                    j = 0;
                    k = 0;
                    curNode = startingNode;



                }

            }

        }
    }
}
