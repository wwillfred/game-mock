using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraMovementTests
{
    [Test]
    public void MoveCameraRight_NoInput_True()
    {
        var gameObject = new GameObject();
        var cameraController = gameObject.AddComponent<CameraController>();

        Vector3 initialCamPosition = cameraController.transform.position;
        Debug.Log("initial cam pos is: " + initialCamPosition.ToString());

        cameraController.MoveCameraRight();
        Debug.Log("after moving right, cam pos is: " + cameraController.transform.position.ToString());

        Assert.AreEqual(new Vector3(initialCamPosition.x + 10, initialCamPosition.y, initialCamPosition.z), cameraController.transform.position);
    }
}
