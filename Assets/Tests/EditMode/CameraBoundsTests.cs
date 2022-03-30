using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraBoundsTests
{

    // A Test behaves as an ordinary method
    [Test]
    public void CheckForPlayerIntersectingCameraMaxX_PlayerMaxXEqualsCameraMaxX_True()
    {
        Bounds cameraBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 9, 0));

        Vector3 playerSize = new Vector3(0.5605184f, 0.4763622f, 0);

        float playerCenter_X = cameraBounds.max.x - playerSize.x/2; //position player's max x to equal camera's max x

        Bounds playerBounds = new Bounds(new Vector3(playerCenter_X, 0, 0), playerSize);

        Assert.IsTrue(Utility.CheckPlayerIntersectingCameraMax_X(cameraBounds, playerBounds));
        // Use the Assert class to test conditions
    }

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
}
