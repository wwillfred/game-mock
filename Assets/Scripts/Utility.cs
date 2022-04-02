using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
     //Checks whether player's bounds' RH edge is at least as far to the right as that of the camera
    public static bool HasPlayerReachedRightEdgeOfCamera(Bounds cameraBounds, Bounds playerBounds)
    {
        Debug.Log("Running right edge of camera check. playerBoundsMaxX is: " + playerBounds.max.x + ", and cameraBoundsMaxX is: " + cameraBounds.max.x);
        return (playerBounds.max.x >= cameraBounds.max.x);
    }

    //Checks whether player's bounds' LH edge is at least as far to the left as that of the camera
    public static bool HasPlayerReachedLeftEdgeOfCamera(Bounds cameraBounds, Bounds playerBounds)
    {
        Debug.Log("Running left edge of camera check. playerBoundsMinX is: " + playerBounds.min.x + ", and cameraBoundsMinX is: " + cameraBounds.min.x);
        return (playerBounds.min.x <= cameraBounds.min.x);
    }

    //Checks whether player's bounds' top edge is at least as high as that of the camera
    public static bool HasPlayerReachedTopEdgeOfCamera(Bounds cameraBounds, Bounds playerBounds)
    {
        Debug.Log("Running top edge of camera check. playerBoundsMaxY is: " + playerBounds.max.y + ", and cameraBoundsMaxY is: " + cameraBounds.max.y);
        return (playerBounds.max.y >= cameraBounds.max.y);
    }

    //Checks whether player's bounds' bottom edge is at least as high as that of the camera
    public static bool HasPlayerReachedBottomEdgeOfCamera(Bounds cameraBounds, Bounds playerBounds)
    {
        Debug.Log("Running bottom edge of camera check. playerBoundsMinY is: " + playerBounds.min.y + ", and cameraBoundsMinY is: " + cameraBounds.min.y);
        return (playerBounds.min.y <= cameraBounds.min.y);
    }
}
