using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Vertex
    {
        public int Key { get; set; } = int.MaxValue;
        public int Parent { get; set; } = -1;
        public int Data { get; set; }
        public bool IsProcessed { get; set; }
        public int visits { get; set; }
        public int[] neighbor = new int[3]; //change this value to the node with the largest number of branches or adjacent nodes
        public Vertex[] neighborVer = new Vertex[3]; //change this value to the node with the largest number of branches or adjacent nodes
        public int[] weight = new int[3]; //change this value to the node with the largest number of branches or adjacent nodes
    }
}
