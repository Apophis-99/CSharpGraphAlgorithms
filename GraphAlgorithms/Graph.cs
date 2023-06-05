namespace GraphAlgorithms;

public class Graph
{
    #region Edge

    public class Edge
    {
        public int Source;
        public int Weight;
        public int Destination;

        public Edge(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }

    #endregion
    
    private List<Edge> _edgesList;
    private Dictionary<int, List<int>> _adjacencyList;

    public Graph()
    {
        _adjacencyList = new Dictionary<int, List<int>>();
        _edgesList = new List<Edge>();
    }

    /// <summary>
    /// Adds a new edge to the graph.
    /// Puts the edge into a separate list to prevent repeating edges and then
    /// references the index of the new edge in the src and dest vertexes.
    /// </summary>
    /// <param name="src">The source vertex</param>
    /// <param name="dest">The destination vertex</param>
    /// <param name="weight">The weight of the edge</param>
    public void AddEdge(int src, int dest, int weight)
    {
        // Adds new edge using data passed through parameters and the index will then be used for reference in the adjacency list
        _edgesList.Add(new Edge(src, dest, weight));

        // If src vertex has no edges yet, initialise list and then add the index of the most recent edge
        if (!_adjacencyList.ContainsKey(src))
            _adjacencyList[src] = new List<int>();
        _adjacencyList[src].Add(_edgesList.Count - 1);
        
        // If dest vertex has no edges yet, initialise list and then add the index of the most recent edge
        if (!_adjacencyList.ContainsKey(dest))
            _adjacencyList[dest] = new List<int>();
        _adjacencyList[dest].Add(_edgesList.Count - 1);
    }

    /// <summary>
    /// Gets all the edges connected to a vertex
    /// </summary>
    /// <param name="vertex">The vertex to get the edges of</param>
    /// <returns>The edges of the vertex</returns>
    public List<Edge> GetNeighbours(int vertex)
    {
        // Gets the list of edge indexes from the vertex or returns an empty list if vertex does not exist
        var edgeIndexes = _adjacencyList.TryGetValue(vertex, out var value) ? value : new List<int>();

        // Returns the edges associated with the indexes that were gathered
        return edgeIndexes.Select(index => _edgesList[index]).ToList();
    }

    public int GetVertexCount()
    {
        return _adjacencyList.Count;
    }

    public List<int> GetVertices()
    {
        return new List<int>(_adjacencyList.Keys);
    }
}
