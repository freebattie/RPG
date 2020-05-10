using NSubstitute;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace a_player
{
    public class moving_in_to_object
    {
        [UnityTest]
        public IEnumerator pick_up_item()
        {
            
            yield return Helpers.LoadItemsTestsScene();
            var player = Helpers.GetPlayer();
            
            Item item = Object.FindObjectOfType<Item>();

            Assert.AreNotSame(item, player.GetComponent<Inventory>().ActiveItem);

            item.transform.position = player.transform.position;

            yield return null;

            Assert.AreSame(item, player.GetComponent<Inventory>().ActiveItem);

           
        }
        [UnityTest]
        public IEnumerator changes_crosshair_to_item_crosshair()
        {

            yield return Helpers.LoadItemsTestsScene();
            var player = Helpers.GetPlayer();
            var crosshair = Object.FindObjectOfType<Crosshair>();

           
            Item item = Object.FindObjectOfType<Item>();
            Assert.AreNotSame(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);

            item.transform.position = player.transform.position;

            yield return null;
            Item hasItem = player.GetComponent<Inventory>().GetItem(item);

            Assert.AreEqual(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);

        }

    }
}
