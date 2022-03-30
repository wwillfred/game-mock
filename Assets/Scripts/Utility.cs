using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static bool CheckForPlayerIntersectingRHEdgeOfCamera(Bounds sceneBounds, Bounds playerBounds)
    {
        Debug.Log("Running static RHBounds method. playerBounds.max.x is: " + playerBounds.max.x + ", and sceneBounds.max.x is: " + sceneBounds.max.x);
        return (playerBounds.max.x >= sceneBounds.max.x);
    }
}
