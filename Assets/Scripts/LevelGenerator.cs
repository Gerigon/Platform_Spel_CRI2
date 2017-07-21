using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static LevelGenerator instance;
    public List<GameObject> startRooms = new List<GameObject>();
    public List<GameObject> roomList = new List<GameObject>();
    public List<List<GameObject>> biomeList = new List<List<GameObject>>();
    public List<Room> Rooms = new List<Room>();
    public List<DoorPositions> doorPositions = new List<DoorPositions>();

    public void Awake()
    {
        instance = this;
        CreateBiomeList();
    }
    public void CreateBiomeList()
    {
        biomeList.Add(new List<GameObject>());
        for (int i = 0; i < roomList.Count; i++)
        {
            if (i >= 0 && i < 4)
            {
                biomeList[0].Add(roomList[i]);
            }
        }
    }

    public void GenerateLevel(int biome, int numberOfRooms)
    {
        switch (biome)
        {
            case 0:
                Rooms.Add(CreateRoom(Vector3.zero));
                for (int i = 0; i < numberOfRooms; i++)
                {

                }

                break;
        }
    }

    public static Room CreateRoom(Vector3 _position)
    {
        Room _room = Instantiate(instance.biomeList[0][0], _position, Quaternion.identity).GetComponent<Room>();
        Debug.Log("trying to createdoors");
        _room.Initialize();
        return _room;
    }
    public static Room CreateRoom(Vector3 _position, string directionFrom)
    {
        Room _room = Instantiate(instance.biomeList[0][0], _position, Quaternion.identity).GetComponent<Room>();
        Debug.Log("trying to createdoors");
        _room.Initialize(directionFrom);
        return _room;
    }

    public void RegisterDoor(Vector3 _position, string _fromDirection)
    {
        doorPositions.Add(new DoorPositions(_position, _fromDirection));
    }

    [System.Serializable]
    public class DoorPositions
    {
        public Vector3 position;
        public string directions;

        public DoorPositions(Vector3 __position, string __fromDirection)
        {
            position = __position;
            directions = __fromDirection;
        }
    }
}
