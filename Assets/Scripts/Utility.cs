using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static bool CheckPlayerIntersectingCameraMax_X(Bounds cameraBounds, Bounds playerBounds)
    {
        Debug.Log("Running static Max_X intersection check. playerBoundsMaxX is: " + playerBounds.max.x + ", and cameraBoundsMaxX is: " + cameraBounds.max.x);
        return (playerBounds.max.x >= cameraBounds.max.x);
    }
}
