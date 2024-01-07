using SchoolAdventure.DungeonPuzzle.Puzzle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Dungeon.Generation
{
    public class Room : MonoBehaviour
    {

        public int Width;
        public int Height;
        public int X;
        public int Y;

        private bool updatedDoors = false;

        public Room(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Door leftDoor;
        public Door rightDoor;
        public Door topDoor;
        public Door bottomDoor;

        public List<Door> doors = new List<Door>();
        // TODO slot puzzle here
        [SerializeField] GameObject _puzzlePrefab;
        GameObject _puzzleInstance;
        [HideInInspector] public PuzzleManager puzzleManager;
        public bool Completed = false;
        // Start is called before the first frame update
        void Start()
        {
            if (RoomController.Instance == null)
            {
                Debug.Log("You pressed play in the wrong scene!");
                return;
            }

            Door[] ds = GetComponentsInChildren<Door>();
            foreach (Door d in ds)
            {
                doors.Add(d);
                switch (d.doorType)
                {
                    case Door.DoorType.right:
                        rightDoor = d;
                        break;
                    case Door.DoorType.left:
                        leftDoor = d;
                        break;
                    case Door.DoorType.top:
                        topDoor = d;
                        break;
                    case Door.DoorType.bottom:
                        bottomDoor = d;
                        break;
                }
            }

            RoomController.Instance.RegisterRoom(this);
        }

        void Update()
        {
            if (name.Contains("End") && !updatedDoors)
            {
                RemoveUnconnectedDoors();
                updatedDoors = true;
            }
        }
        public void ActivatePuzzle()
        {
            _puzzleInstance = Instantiate(_puzzlePrefab, transform);
            puzzleManager = _puzzleInstance.GetComponent<PuzzleManager>();
            puzzleManager.ActivatePuzzle();
        }
        public void RemoveUnconnectedDoors()
        {
            //Debug.Log("removing doors");
            foreach (Door door in doors)
            {
                switch (door.doorType)
                {
                    case Door.DoorType.right:
                        if (GetRight() == null)
                            door.gameObject.SetActive(false);
                        break;
                    case Door.DoorType.left:
                        if (GetLeft() == null)
                            door.gameObject.SetActive(false);
                        break;
                    case Door.DoorType.top:
                        if (GetTop() == null)
                            door.gameObject.SetActive(false);
                        break;
                    case Door.DoorType.bottom:
                        if (GetBottom() == null)
                            door.gameObject.SetActive(false);
                        break;
                }
            }
        }

        public Room GetRight()
        {
            if (RoomController.Instance.DoesRoomExist(X + 1, Y))
            {
                return RoomController.Instance.FindRoom(X + 1, Y);
            }
            return null;
        }
        public Room GetLeft()
        {
            if (RoomController.Instance.DoesRoomExist(X - 1, Y))
            {
                return RoomController.Instance.FindRoom(X - 1, Y);
            }
            return null;
        }
        public Room GetTop()
        {
            if (RoomController.Instance.DoesRoomExist(X, Y + 1))
            {
                return RoomController.Instance.FindRoom(X, Y + 1);
            }
            return null;
        }
        public Room GetBottom()
        {
            if (RoomController.Instance.DoesRoomExist(X, Y - 1))
            {
                return RoomController.Instance.FindRoom(X, Y - 1);
            }
            return null;
        }


        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
        }

        public Vector3 GetRoomCentre()
        {
            return new Vector3(X * Width, Y * Height);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                RoomController.Instance.OnPlayerEnterRoom(this);
            }
        }
    }
}
