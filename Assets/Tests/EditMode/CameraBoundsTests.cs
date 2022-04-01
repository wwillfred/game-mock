using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraBoundsTests
{
    Bounds cameraBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 9, 0));

    Bounds playerBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(0.5605184f, 0.4763622f, 0));

    //Vector3 playerCenter;

    readonly float margin = 0.000001f; // an arbitrarily small value for testing values less than/greater than other values

    /******************************** 
     * Tests for Utility.CheckPlayerIntersectingCameraMax_X()
     ********************************/

    [Test]
    public void CheckPlayerIntersectingCameraMaxX_PlayerMaxXEqualsCameraMaxX_True()
    {
        Vector3 playerCenter = new Vector3(cameraBounds.max.x - playerBounds.extents.x, 0, 0); //position player's max x to equal camera's max x

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMax_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMaxX_PlayerMaxXGreaterThanCameraMaxX_True()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.max.x - playerBounds.extents.x) + margin, 0, 0); //position player's max x to be slightly greater than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMax_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMaxX_PlayerMaxXLessThanCameraMaxX_False()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.max.x - playerBounds.extents.x) - margin, 0, 0); //position player's max x to be slightly less than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsFalse(Utility.CheckPlayerIntersectingCameraMax_X(cameraBounds, playerBounds));
    }

    /********************************
    * Tests for Utility.CheckPlayerIntersectingCameraMin_X()
    *********************************/

    [Test]
    public void CheckPlayerIntersectingCameraMinX_PlayerMinXEqualsCameraMinX_True()
    {
        Vector3 playerCenter = new Vector3(cameraBounds.min.x + playerBounds.extents.x, 0, 0); //position player's min x to equal camera's min x

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMin_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMinX_PlayerMinXLessThanCameraMinX_True()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.min.x + playerBounds.extents.x) - margin, 0, 0); //position player's min x to be slightly less than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMin_X(cameraBounds, playerBounds));
    }

    [Test]
    public void CheckPlayerIntersectingCameraMinX_PlayerMinXGreaterThanCameraMinX_False()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.min.x + playerBounds.extents.x) + margin, 0, 0); //position player's min x to be slightly greater than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsFalse(Utility.CheckPlayerIntersectingCameraMin_X(cameraBounds, playerBounds));
    }

    /********************************
   * Tests for Utility.CheckPlayerIntersectingCameraMax_Y()
   *********************************/

    [Test]
    public void CheckPlayerIntersectingCameraMaxY_PlayerMaxYEqualsCameraMaxY_True()
    {
        Vector3 playerCenter = new Vector3(0, cameraBounds.max.y + playerBounds.extents.y, 0); //position player's max y to equal camera's max y

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMax_Y(cameraBounds, playerBounds));
    }

    private void SetPlayerBoundsCenter(Vector3 playerCenter)
    {
        playerBounds.center = playerCenter;
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
