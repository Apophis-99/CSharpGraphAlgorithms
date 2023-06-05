using GraphAlgorithms;
using GraphAlgorithms.Algorithms;

var graph = new Graph();
graph.AddEdge(1, 2, 5);
graph.AddEdge(1, 3, 3);
graph.AddEdge(1, 4, 1);
graph.AddEdge(2, 4, 9);

var mst = GraphAlgorithm.Prims(graph, 1);
