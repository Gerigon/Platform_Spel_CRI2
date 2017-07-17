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
        Vector3 lastRoomPos;
        switch (biome)
        {
            case 0:
                lastRoomPos = GenerateRoom(startRooms[biome],Vector3.zero,2);

                for (int i = 0; i < numberOfRooms; i++)
                {
                    Debug.Log(lastRoomPos);
                    lastRoomPos = GenerateRoom(biomeList[0][i], lastRoomPos + new Vector3(21, 0, 0),2,3);
                }
                break;
        }
    }
    public Vector3 GenerateRoom(GameObject room, Vector3 position)
    {
        GameObject createdRoom = Instantiate(room, position, Quaternion.identity);
        return position;
    }
    public Vector3 GenerateRoom(GameObject room, Vector3 position, int Door)
    {
        GameObject createdRoom = Instantiate(room, position, Quaternion.identity);
        createdRoom.transform.GetChild(0).GetChild(1).GetChild(Door).gameObject.SetActive(true);
        return position;
    }
    public Vector3 GenerateRoom(GameObject room, Vector3 position, int Door, int Door2)
    {
        GameObject createdRoom = Instantiate(room, position, Quaternion.identity);
        createdRoom.transform.GetChild(0).GetChild(1).GetChild(Door).gameObject.SetActive(true);
        createdRoom.transform.GetChild(0).GetChild(1).GetChild(Door2).gameObject.SetActive(true);
        return position;
    }
    public Vector3 GenerateRoom(GameObject room, Vector3 position, int Door, int Door2, int Door3)
    {
        GameObject createdRoom = Instantiate(room, position, Quaternion.identity);

        return position;
    }
}
