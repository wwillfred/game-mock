using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraBoundsTests
{
    Bounds cameraBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 9, 0));

    //Vector3 playerSize = new Vector3(0.5605184f, 0.4763622f, 0);

    Bounds playerBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(0.5605184f, 0.4763622f, 0));

    float playerCenter_X;

    readonly float margin = 0.000001f; // an arbitrarily small value for testing values less than/greater than other values

    /******************************** 
     * Tests for Utility.CheckPlayerIntersectingCameraMax_X()
     ********************************/

    [Test]
    public void CheckPlayerIntersectingCameraMaxX_PlayerMaxXEqualsCameraMaxX_True()
    {
        playerCenter_X = cameraBounds.max.x - playerBounds.extents.x; //position player's max x to equal camera's max x

        SetPlayerBoundsCenter();

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMax_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMaxX_PlayerMaxXGreaterThanCameraMaxX_True()
    {
        playerCenter_X = (cameraBounds.max.x - playerBounds.extents.x) + margin; //position player's max x to be slightly greater than camera's

        SetPlayerBoundsCenter();

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMax_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMaxX_PlayerMaxXLessThanCameraMaxX_False()
    {
        playerCenter_X = (cameraBounds.max.x - playerBounds.extents.x) - margin; //position player's max x to be slightly less than camera's

        SetPlayerBoundsCenter();

        Assert.IsFalse(Utility.CheckPlayerIntersectingCameraMax_X(cameraBounds, playerBounds));
    }

    /********************************
    * Tests for Utility.CheckPlayerIntersectingCameraMin_X()
    *********************************/

    [Test]
    public void CheckPlayerIntersectingCameraMinX_PlayerMinXEqualsCameraMinX_True()
    {
        playerCenter_X = cameraBounds.min.x + playerBounds.extents.x; //position player's min x to equal camera's min x

        SetPlayerBoundsCenter();

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMin_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMinX_PlayerMinXLessThanCameraMinX_True()
    {
        playerCenter_X = (cameraBounds.min.x + playerBounds.extents.x) - margin; //position player's min x to be slightly less than camera's

        SetPlayerBoundsCenter();

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMin_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMinX_PlayerMinXGreaterThanCameraMinX_False()
    {
        playerCenter_X = (cameraBounds.min.x + playerBounds.extents.x) + margin; //position player's max x to be slightly greater than camera's

        SetPlayerBoundsCenter();

        Assert.IsFalse(Utility.CheckPlayerIntersectingCameraMin_X(cameraBounds, playerBounds));
    }

    private void SetPlayerBoundsCenter()
    {
        playerBounds.center = new Vector3(playerCenter_X, 0, 0);
    }

    /*
    [Test]
    public void CameraBoundsTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CameraBoundsTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    */
}
