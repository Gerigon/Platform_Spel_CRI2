using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public List<GameObject> startRooms = new List<GameObject>();
    public List<GameObject> roomList = new List<GameObject>();
    public List<List<GameObject>> biomeList = new List<List<GameObject>>();

    public void Awake()
    {
        CreateBiomeList();
    }

    public void CreateBiomeList()
    {
        biomeList.Add(new List<GameObject>());
        for (int i = 0; i < roomList.Count; i++)
        {
            if (i >= 0 && i<4)
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
                
                List<Room> Rooms = new List<Room>();
                Rooms.Add(new Room(biomeList[0][0], Vector3.zero));
                for (int i = 0; i < numberOfRooms-1; i++)
                {
                    Debug.Log(Rooms.Count);
                    Debug.Log(Rooms[0]);
                    if (Rooms[Rooms.Count-1].GetDoor() == "North")
                    {
                        Rooms.Add(new Room(biomeList[0][0], Rooms[Rooms.Count].transform.position + new Vector3(0, 0, 5),"North"));
                    }
                }
                break;
        }
    }
}
