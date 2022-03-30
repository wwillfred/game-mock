using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ScreenBoundsTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    /*
    [UnityTest]
    public IEnumerator IsPlayerIntersectingRHEdgeOfScene_PlayerIntersectsRHEdgeOfScreen_True()
    {
        //Instantiate the required GameObjects
        GameObject playerObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
        GameObject cameraObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));

        //get the Bounds of the box colliders for player and camera
        Bounds playerBounds = playerObject.GetComponent<BoxCollider2D>().bounds;
        Bounds sceneBounds = cameraObject.GetComponent<BoxCollider2D>().bounds;

        //move the Player so that it's at least touching the Main Camera's BoxCollider's RH edge
        playerObject.transform.position = sceneBounds.max;

        Assert.IsTrue(cameraObject.IsPlayerIntersectingRHEdgeOfScene);
        yield return null;
    }
    */

    [UnityTest]
    public IEnumerator IsPlayerIntersectingRHEdgeOfScene_PlayerIntersectsRHEdgeOfScreen_True()
    {
        yield return new MonoBehaviourTest<MonoBehaviour_IsPlayerIntersectingRHEdgeOfScene_PlayerIntersectsRHEdgeOfScreen_True>();
    }

    public class MonoBehaviour_IsPlayerIntersectingRHEdgeOfScene_PlayerIntersectsRHEdgeOfScreen_True : MonoBehaviour, IMonoBehaviourTest
    {
        public bool IsTestFinished
        {
            get; private set;
        }

        void Start()
        {
            IsTestFinished = false;
            //Instantiate the required GameObjects
            GameObject playerObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player")); Debug.Log("playerObject is: " + playerObject.ToString());
            GameObject cameraObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));

            //get the Bounds of the box colliders for player and camera
            Bounds playerBounds = playerObject.GetComponent<BoxCollider2D>().bounds; Debug.Log("playerBounds is: " + playerBounds.ToString());
            Bounds sceneBounds = cameraObject.GetComponent<BoxCollider2D>().bounds;

            //SceneBounds sceneBoundsScript = cameraObject.GetComponent<SceneBounds>();

            //move the Player so that it's at least touching the Main Camera's BoxCollider's RH edge
            //playerObject.transform.position = sceneBounds.max; Debug.Log("playerObject position is: " + playerObject.transform.position);

            //Assert.IsTrue(sceneBoundsScript.IsPlayerIntersectingRHEdgeOfScene(playerBounds));

        }
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
