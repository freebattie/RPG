using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace a_player
{
    public static class Helpers
    {
        public static IEnumerator LoadMovementTestsScene()
        {
            var operation = SceneManager.LoadSceneAsync("MovementTests");
            while (operation.isDone == false)
                yield return null;

           
        }
        public static IEnumerator LoadItemsTestsScene()
        {
            var operation = SceneManager.LoadSceneAsync("ItemTests");
            while (operation.isDone == false)
                yield return null;

            operation = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            while (operation.isDone == false)
                yield return null;


        }
        public static Player GetPlayer()
        {
           
            Player  player = GameObject.FindObjectOfType<Player>();
            
            var testPlayerInput = Substitute.For<IPlayerInput>();
            player.PlayerInput = testPlayerInput;
            return player;
        }

        internal static float calculateTurn(Quaternion originalRotation, Quaternion rotation)
        {
            
            var cross = Vector3.Cross(originalRotation * Vector3.right, rotation * Vector3.right);
            Debug.Log("what the fuck are you?" + originalRotation * Vector3.right);
            Debug.Log("what the fuck are you then?" + rotation * Vector3.right);
            Debug.Log("confusu?" + rotation );
            Debug.Log("Cross" + cross);
            var dot = Vector3.Dot(cross, Vector3.up);
            return dot;
         
        }
    }
    public class with_positive_vertical_input
    {
        [UnityTest]
        public IEnumerator moves_forward()
        {
            //ARRANGE

           yield return Helpers.LoadMovementTestsScene();
            var player = Helpers.GetPlayer();
            player.PlayerInput.Vertical.Returns(1f);

            //ACT
            float startingZPosision = player.transform.position.z;
            yield return new WaitForSeconds(5f);
            float endZPosision = player.transform.position.z;

            //ASSERT
            Assert.Greater(endZPosision, startingZPosision);


        }

       

    }
    public class with_negative_vertical_input
    {
        [UnityTest]
        public IEnumerator moves_back()
        {
            //ARRANGE

            yield return Helpers.LoadMovementTestsScene();
            var player = Helpers.GetPlayer();
            player.PlayerInput.Vertical.Returns(-1f);

            //ACT
            float startingZPosision = player.transform.position.z;
            yield return new WaitForSeconds(5f);
            float endZPosision = player.transform.position.z;

            //ASSERT
            Assert.Less(endZPosision, startingZPosision);


        }



    }
    public class with_negative_mouse_X
    {

        [UnityTest]
        public IEnumerator turn_left()
        {
            yield return Helpers.LoadMovementTestsScene();
            var player = Helpers.GetPlayer();
            player.PlayerInput.MouseX.Returns(-1f);

            var originalRotation = player.transform.rotation;
            yield return new WaitForSeconds(0.5f);
            float turnAmount = Helpers.calculateTurn(originalRotation, player.transform.rotation);
            Debug.Log("turn amount" + turnAmount);
            Assert.Less(turnAmount, 0);
            
        }

    }
    public class with_postive_mouse_X
    {

        [UnityTest]
        public IEnumerator turn_right()
        {
            yield return Helpers.LoadMovementTestsScene();
            var player = Helpers.GetPlayer();
            player.PlayerInput.MouseX.Returns(1f);

            var originalRotation = player.transform.rotation;
            yield return new WaitForSeconds(0.5f);
            float turnAmount = Helpers.calculateTurn(originalRotation, player.transform.rotation);
            Debug.Log("turn amount" + turnAmount);
            Assert.Greater(turnAmount, 0);

        }

    }
    
}
