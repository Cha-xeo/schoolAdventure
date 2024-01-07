using UnityEngine;
using SchoolAdventure;

namespace SchoolAdventure.Dungeon.Generation
{
    [System.Serializable]
    public class Item
    {
        public string name;
        public string description;
        public Sprite itemImage;
    }

    public class CollectionController : MonoBehaviour
    {
        public Item item;
        public float healthChange;
        public float moveSpeedChange;
        public float attackSpeedChange;
        public float bulletSizeChange;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<SpriteRenderer>().sprite = item.itemImage;
            // TODO ???
            //Destroy(GetComponent<PolygonCollider2D>());
            //gameObject.AddComponent<PolygonCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.TAG_PLAYER))
            {
                DungeonPuzzle.Player.PlayerManager.Instance.ItemPickedUp();
                //PlayerController.collectedAmount++;
                // TODO ???
                GameController.HealPlayer(healthChange);
                GameController.MoveSpeedChange(moveSpeedChange);
                GameController.FireRateChange(attackSpeedChange);
                GameController.BulletSizeChange(bulletSizeChange);
                GameController.Instance.UpdateCollectedItems(this);
                Destroy(gameObject);
            }
        }
    }
}
