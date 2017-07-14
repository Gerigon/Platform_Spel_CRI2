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
                GenerateRoom(startRooms[biome]);

                for (int i = 0; i < numberOfRooms; i++)
                {
                    GenerateRoom(biomeList[0][i]);
                }
                break;
        }
    }

	public void GenerateRoom(GameObject room)
    {
        Instantiate(room, Vector3.zero, Quaternion.identity);
    }
}
