using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraEdgeInteractionTests
{
    Bounds cameraBounds = new Bounds(Vector3.zero, new Vector3(10, 9, 0));

    Bounds playerBounds = new Bounds(Vector3.zero, new Vector3(0.5605184f, 0.4763622f, 0));

    readonly float delta = 0.000001f; // an arbitrarily small value for testing values less than/greater than other values

    /******************************** 
     * Tests for Utility.HasPlayerReachedRightEdgeOfCamera()
     ********************************/

    [Test]
    public void HasPlayerReachedRightEdgeOfCamera_PlayerMaxXEqualsCameraMaxX_True()
    {
        Vector3 playerCenter = new Vector3(cameraBounds.max.x - playerBounds.extents.x, 0, 0); //position player's max x to equal camera's max x

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedRightEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedRightEdgeOfCamera_PlayerMaxXGreaterThanCameraMaxX_True()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.max.x - playerBounds.extents.x) + delta, 0, 0); //position player's max x to be slightly greater than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedRightEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedRightEdgeOfCamera_PlayerMaxXLessThanCameraMaxX_False()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.max.x - playerBounds.extents.x) - delta, 0, 0); //position player's max x to be slightly less than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsFalse(Utility.HasPlayerReachedRightEdgeOfCamera(cameraBounds, playerBounds));
    }

    /********************************
    * Tests for Utility.HasPlayerReachedLeftEdgeOfCamera()
    *********************************/

    [Test]
    public void HasPlayerReachedLeftEdgeOfCamera_PlayerMinXEqualsCameraMinX_True()
    {
        Vector3 playerCenter = new Vector3(cameraBounds.min.x + playerBounds.extents.x, 0, 0); //position player's min x to equal camera's min x

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedLeftEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedLeftEdgeOfCamera_PlayerMinXLessThanCameraMinX_True()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.min.x + playerBounds.extents.x) - delta, 0, 0); //position player's min x to be slightly less than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedLeftEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedLeftEdgeOfCamera_PlayerMinXGreaterThanCameraMinX_False()
    {
        Vector3 playerCenter = new Vector3((cameraBounds.min.x + playerBounds.extents.x) + delta, 0, 0); //position player's min x to be slightly greater than camera's

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsFalse(Utility.HasPlayerReachedLeftEdgeOfCamera(cameraBounds, playerBounds));
    }

    /********************************
   * Tests for Utility.HasPlayerReachedTopEdgeOfCamera()
   *********************************/

    [Test]
    public void HasPlayerReachedTopEdgeOfCamera_PlayerMaxYEqualsCameraMaxY_True()
    {
        Vector3 playerCenter = new Vector3(0, cameraBounds.max.y - playerBounds.extents.y, 0); //position player's max y to equal camera's max y

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedTopEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedTopEdgeOfCamera_PlayerMaxYGreaterThanCameraMaxY_True()
    {
        Vector3 playerCenter = new Vector3(0, cameraBounds.max.y - playerBounds.extents.y + delta, 0); //position player's max y to be greater than camera's max y

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedTopEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedTopEdgeOfCamera_PlayerMaxYLessThanCameraMaxY_False()
    {
        Vector3 playerCenter = new Vector3(0, cameraBounds.max.y - playerBounds.extents.y - delta, 0); //position player's max y to be less than camera's max y

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsFalse(Utility.HasPlayerReachedTopEdgeOfCamera(cameraBounds, playerBounds));
    }

    /********************************
    * Tests for Utility.HasPlayerReachedBottomEdgeOfCamera()
    *********************************/

    [Test]
    public void HasPlayerReachedBottomEdgeOfCamera_PlayerMinYEqualsCameraMinY_True()
    {
        Vector3 playerCenter = new Vector3(0, cameraBounds.min.y + playerBounds.extents.y, 0); //position player's min y to equal camera's min y

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedBottomEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedBottomEdgeOfCamera_PlayerMinYLessThanCameraMinY_True()
    {
        Vector3 playerCenter = new Vector3(0, cameraBounds.min.y + playerBounds.extents.y - delta, 0); //position player's min y to be less than camera's min y

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsTrue(Utility.HasPlayerReachedBottomEdgeOfCamera(cameraBounds, playerBounds));
    }

    [Test]
    public void HasPlayerReachedBottomEdgeOfCamera_PlayerMinYGreaterThanCameraMinY_False()
    {
        Vector3 playerCenter = new Vector3(0, cameraBounds.min.y + playerBounds.extents.y + delta, 0); //position player's min y to be greater than camera's min y

        SetPlayerBoundsCenter(playerCenter);

        Assert.IsFalse(Utility.HasPlayerReachedBottomEdgeOfCamera(cameraBounds, playerBounds));
    }


    /********************************
    * Helper method
    *********************************/
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
