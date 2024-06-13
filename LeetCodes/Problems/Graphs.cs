
using System.Net.WebSockets;

namespace LeetCodes.Problems;

public static class Graphs
{
    //public static int NumIslands(char[][] grid)
    //{
    //    var rows = grid.GetLength(0);
    //    var cols = grid.GetLength(1);

    //    var visited = new int[rows, cols];
    //    var islands = 0;

    //    for (int r = 0; r < rows ; r++)
    //    {
    //        for (int c = 0; c < cols; c++)
    //        {
    //            var notVisited = visited
    //                if (grid[r][c] == '1' && notVisited) {
    //                BFS(r,c, visited, grid);
    //                islands++;
    //            }
    //        }

    //    }
    //    return 0;
    //}

    private static void BFS(int r, int c, string[,] visited, char[][] grid)
    {
        var q = new Queue<int>();
        visited[r, c].Append(grid[r][c]);
        q.Append(grid[r][c]);

        while (q.Count > 0)
        {
            var t = q.Dequeue();
            
        }

        
    }

}
