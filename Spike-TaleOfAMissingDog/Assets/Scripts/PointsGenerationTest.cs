using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGeneration : MonoBehaviour
{
    // transform.position should be x = -7.5, y = -7.5, Z = 0
    public float radius = 4;
    public Vector2 regionSize = Vector2.one; // should be new Vector2(17,17)
    public int rejectionSamples = 30;
    public float displayRadius = 0.15f;

    [SerializeField] public List<Vector2> points;
    //[SerializeField] private List<Vector2> pointsShifted;

    void OnValidate()
    {
        points = PoissonDiscSampling.GeneratingPoints(radius, regionSize, transform.position, rejectionSamples);
        //pointsShifted = ShiftPoints(points);
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireCube(regionSize / 2, regionSize);

        Gizmos.color = Color.red;
        var centerPoint = new Vector2(transform.localPosition.x + (regionSize.x / 2), transform.localPosition.y + (regionSize.y / 2));
        Gizmos.DrawWireCube(centerPoint, regionSize);

        if (points != null)
        {
            foreach (Vector2 point in points)
            {
                Gizmos.DrawSphere(point, displayRadius);
            }
        }
    }

    //List<Vector2> ShiftPoints(List<Vector2> points)
    //{
    //    pointsShifted = new List<Vector2>();

    //    foreach (Vector2 point in points)
    //    {
    //        var shiftedPoint = new Vector2(point.x + transform.localPosition.x, point.y + transform.localPosition.y);
    //        pointsShifted.Add(shiftedPoint);
    //    }

    //    return pointsShifted;
    //}
}
