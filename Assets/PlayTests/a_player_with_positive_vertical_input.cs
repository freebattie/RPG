using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace a_player
{
    public class with_positive_vertical_input
    {
        [UnityTest]
        public IEnumerator moves_forward()
        {

            //ARRANGE
            var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.transform.localScale = new Vector3(50f, 1f, 50f);
            floor.transform.position = Vector3.zero;
            var playerGameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerGameObject.AddComponent<CharacterController>();
            playerGameObject.AddComponent<Player>();
            playerGameObject.transform.position = new Vector3(0, 2f, 0);
            Player player  = playerGameObject.AddComponent<Player>();

            //ACT
            var testPlayerInput = new TestPlayerInput();
            player.PlayerInput = testPlayerInput;

            testPlayerInput.Vertical = 2f;
            testPlayerInput.Horizontal=2f; 

            float startingZPosision = player.transform.position.z;

            yield return new WaitForSeconds(5f);
            float endZPosision = player.transform.position.z;

            //ASSERT
            Assert.Greater(endZPosision, startingZPosision);
            
            
        }
    }

    internal class TestPlayerInput : IPlayerInput
    {
        public float Vertical { get; set; }
        public float Horizontal { get; set; }

        
    }
}
