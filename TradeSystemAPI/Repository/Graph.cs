namespace TradeSystemAPI.Repository
{
    public class Graph
    {
        public Dictionary<string, Dictionary<string, int>> graph;
        public Graph()
        {
            graph = new Dictionary<string, Dictionary<string, int>>();
        }
        public string AddVertex(string vertex)
        {
            if (!graph.ContainsKey(vertex))
            {
                graph.Add(vertex, new Dictionary<string, int>());
                return vertex;
            }
            return vertex;
        }
        public void AddEdge(string vertex1, string vertex2, int weight)
        {
            if (!graph[vertex1].ContainsKey(vertex2))
            {
                graph[vertex1].Add(vertex2, weight);
            }
            if (!graph[vertex2].ContainsKey(vertex1))
            {
                graph[vertex2].Add(vertex1, weight);
            }
        }
        public void removeVertex(string vertex)
        {
            foreach (string key in graph.Keys)
            {
                if (!key.Equals(vertex))
                {
                    graph[key].Remove(vertex);
                }
            }
            graph.Remove(vertex);
        }
        public List<string> shortestPath(string startVertex, string endVertex)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            foreach (string key in graph.Keys)
            {
                if (key.Equals(startVertex))
                {
                    distances.Add(key, 0);
                }
                else
                {
                    distances.Add(key, int.MaxValue);
                }
            }
            Dictionary<string, string> prev = new Dictionary<string, string>();
            foreach (string key in graph.Keys)
            {
                prev.Add(key, null);
            }
            Dictionary<string, int> des = new Dictionary<string, int>() {
            {"AuPost Mel", 4},
            {"Uber Bris", 3},
            {"Uber NewCastle", 5},
            {"AuPost Syd", 6},
            {"address", 1 }
        };
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
            List<string> visited = new List<string>();
            List<string> path = new List<string>();
            pq.Enqueue(startVertex, 0);
            visited.Add(startVertex);
            while (true)
            {
                string current = pq.Dequeue();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                }
                if (current.Equals(endVertex))
                {
                    path.Add(current);
                    while (prev[current] != null)
                    {
                        current = prev[current];
                        path.Add(current);
                    }
                    return path;
                }
                foreach (string adjacent in graph[current].Keys)
                {
                    if (!visited.Contains(adjacent))
                    {
                        var distance = distances[current] + graph[current][adjacent];
                        if (distance < distances[adjacent])
                        {
                            distances[adjacent] = distance;
                            prev[adjacent] = current;
                            pq.Enqueue(adjacent, distance + des[adjacent]);
                        }
                    }
                }
            }
        }
    }
}
