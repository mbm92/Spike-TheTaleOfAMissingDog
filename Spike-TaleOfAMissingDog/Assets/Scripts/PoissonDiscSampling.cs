using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoissonDiscSampling
{
    // need to figure gridSize = 18x18 units
    // maybe have a object that contains all the info for these points? 

    
    public static List<Vector2> GeneratingPoints(float radius, Vector2 samplingRegionSize, Vector2 localPosition , int numSamplesBeforeRejection = 30)
    {
        // cellSize = (r / srt(n)) where n is dimensions in the n-dimensional grid. 
        // we have a 2-dimensional grid. 
        float cellSize = radius / Mathf.Sqrt(2);
        int[,] grid = new int[Mathf.CeilToInt(samplingRegionSize.x / cellSize), Mathf.CeilToInt(samplingRegionSize.y / cellSize)];

        List<Vector2> points = new List<Vector2>();
        List<Vector2> spawnPoints = new List<Vector2>();
        List<Vector2> shiftedPoints = new List<Vector2>();

        spawnPoints.Add(samplingRegionSize / 2);

        while (spawnPoints.Count > 0)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Vector2 spawnCenter = spawnPoints[spawnIndex];
            bool candidateAccepted = false;

            for (int i = 0; i < numSamplesBeforeRejection; i++)
            {
                float angle = Random.value * Mathf.PI * 2;
                Vector2 direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
                Vector2 candidate = spawnCenter + direction * Random.Range(radius, 2*radius);

                if (IsValid(candidate, samplingRegionSize, cellSize, radius, points, grid))
                {
                    points.Add(candidate);
                    spawnPoints.Add(candidate);
                    grid[(int)(candidate.x / cellSize), (int)(candidate.y / cellSize)] = points.Count;
                    candidateAccepted = true;
                    break;
                }
            }

            if (!candidateAccepted)
            {
                spawnPoints.RemoveAt(spawnIndex);
            }
        }

        //return points;
        return shiftedPoints = ShiftPoints(points, localPosition);
    }

    static bool IsValid(Vector2 candidate, Vector2 sampleRegionSize, float cellSize, float radius, List<Vector2> points, int[,] grid)
    {
        if (candidate.x >= 0 && candidate.x < sampleRegionSize.x && candidate.y >= 0 && candidate.y < sampleRegionSize.y)
        {
            int cellX = (int)(candidate.x / cellSize);
            int cellY = (int)(candidate.y / cellSize);
            int searchStartX = Mathf.Max(0, cellX - 2);
            int searchEndX = Mathf.Min(cellX + 2, grid.GetLength(0) - 1);

            int searchStartY = Mathf.Max(0, cellY - 2);
            int searchEndY = Mathf.Min(cellY + 2, grid.GetLength(1) - 1);

            for (int x = searchStartX; x <= searchEndX; x++)
            {
                for (int y = searchStartY; y <= searchEndY; y++)
                {
                    int pointIndex = grid[x, y] - 1;
                    if (pointIndex != -1)
                    {
                        float sqrDistance = (candidate - points[pointIndex]).sqrMagnitude;
                        if (sqrDistance < radius * radius)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        return false;
    }

    // method to shiftPoints so correspond with the localPosition of the lower left corner of the grid
    static List<Vector2> ShiftPoints(List<Vector2> points, Vector2 localPosition)
    {
        var shiftedPoints = new List<Vector2>();

        foreach (Vector2 point in points)
        {
            var shiftedPoint = new Vector2(point.x + localPosition.x, point.y + localPosition.y);
            shiftedPoints.Add(shiftedPoint);
        }

        return shiftedPoints;
    }
}
