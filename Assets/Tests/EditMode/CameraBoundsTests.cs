using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraBoundsTests
{

    // A Test behaves as an ordinary method
    [Test]
    public void CheckForPlayerIntersectingRHEdgeOfCamera_BoundsIntersects_True()
    {
        Bounds cameraBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 9, 0));
        Bounds playerBounds = new Bounds(new Vector3(9, 0, 0), new Vector3(5, 4, 0));

        Assert.IsTrue(Utility.CheckForPlayerIntersectingRHEdgeOfCamera(cameraBounds, playerBounds));
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
