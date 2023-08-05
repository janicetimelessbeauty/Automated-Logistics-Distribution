using System;
using System.Collections.Generic;
namespace TradeSystemAPI.Repository
{   
    public class OrderDistribute : GraphInterface
    {
        public List<string> paths(int distance)
        {
            Graph gp = new Graph();
            gp.AddVertex("Warehouse");
            gp.AddVertex("AuPost Mel");
            gp.AddVertex("Uber Bris");
            gp.AddVertex("Uber NewCastle");
            gp.AddVertex("AuPost Syd");
            gp.AddVertex("address");
            if (distance >= 20 && distance < 30)
            {
                gp.AddEdge("AuPost Mel", "address", 4);
                gp.AddEdge("Uber Bris", "address", 2);
            }
            else if (distance >= 30 && distance < 40)
            {
                gp.AddEdge("Uber NewCastle", "address", 6);
                gp.AddEdge("AuPost Syd", "address", 3);
            }
            else
            {
                gp.AddEdge("AuPost Syd", "address", 3);
                gp.AddEdge("Uber NewCastle", "address", 4);
            }
            gp.AddEdge("Warehouse", "Uber Bris", 4);
            gp.AddEdge("Warehouse", "AuPost Mel", 6);
            gp.AddEdge("AuPost Mel", "Uber Bris", 3);
            gp.AddEdge("AuPost Mel", "AuPost Syd", 5);
            gp.AddEdge("Uber NewCastle", "AuPost Mel", 2);
            gp.AddEdge("Uber Bris", "AuPost Syd", 4);
            gp.AddEdge("AuPost Syd", "Uber NewCastle", 5);
            return gp.shortestPath("Warehouse", "address");
        }
    }
}
