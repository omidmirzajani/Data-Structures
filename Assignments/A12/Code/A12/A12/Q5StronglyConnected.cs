using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q5StronglyConnected: Processor
    {
        public Q5StronglyConnected(string testDataName) : base(testDataName) {
            ExcludeTestCaseRangeInclusive(1, 3);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        List<long> tt = new List<long>();
        public long Solve(long nodeCount, long[][] edges)
        {
            bool[] visited = new bool[nodeCount];
            List<long>[] adj = new List<long>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
                adj[i] = new List<long>();

            for (int i = 0; i < edges.Length; i++)
                adj[edges[i][0] - 1].Add(edges[i][1] - 1);

            bool[] vis = new bool[nodeCount];
            long k = 0;
            List<long>[] dfss = new List<long>[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                visited = new bool[nodeCount];
                dfss[i] = dfs(i, visited, adj);
            }
            for (int i=0;i<nodeCount;i++)
            {
                if(!vis[i])
                {
                    foreach(long t in dfss[i])
                    {
                        visited = new bool[nodeCount];
                        List<long> shart = dfss[t];
                        if (shart.Contains(i))
                        {
                            vis[t] = true;
                        }
                    }
                    vis[i] = true;
                    k++;
                }
            }
            return k;
        }

        public List<long> dfs(long v, bool[] visited, List<long>[] adjListArray)
        {
            visited[v] = true;
            List<long> l = new List<long>();
            l.Add(v);
            foreach (int x in adjListArray[v])
                if (!visited[x])
                    l.AddRange(dfs(x, visited, adjListArray));
            return l;

        }


        //bool[] visited = new bool[nodeCount];
        //bool[] recuersive = new bool[nodeCount];

        //tt.Clear();
        //for(int i=0;i<nodeCount;i++)
        //{
        //    bool x = dfs(i, visited, recuersive, adj);
        //}
        //return 0;
    }
    //public bool dfs(long v, bool[] visited, bool[] recuersive, List<long>[] adj)
    //{
    //    visited[v] = true;
    //    recuersive[v] = true;
    //    foreach (long ad in adj[v])
    //    {
    //        if (!visited[ad])
    //        {
    //            if (dfs(ad, visited, recuersive, adj))
    //            {
    //                tt.Add(NumOfTrues(visited));
    //                return true;
    //            }
    //        }
    //        else if (recuersive[ad])
    //        {
    //            tt.Add(NumOfTrues(visited));
    //            return true;
    //        }

    //    }
    //    recuersive[v] = false;
    //    return false;
    //}

    //private long NumOfTrues(bool[] visited)
    //{
    //    long t = 0;
    //    for(int i=0;i<visited.Length;i++)
    //    {
    //        if (visited[i])
    //            t++;
    //    }
    //    return t;
    //}
}

