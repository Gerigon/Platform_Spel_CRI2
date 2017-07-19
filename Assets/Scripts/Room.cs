using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Room roomScript;
    public List<GameObject> northDoor;
    public List<GameObject> westDoor;
    public List<GameObject> southDoor;
    public List<GameObject> eastDoor;

    GameObject _room;

    public Room(GameObject room, Vector3 position)
    {
        _room = Instantiate(room, position, Quaternion.identity) as GameObject;
        _room.AddComponent<Room>();
    }
    public Room(GameObject room, Vector3 position, string directionFrom)
    {
        _room = Instantiate(room, position, Quaternion.identity) as GameObject;
        _room.AddComponent<Room>();
        CreateDoors(directionFrom);
    }
    private void Start()
    {
        northDoor = new List<GameObject>();
        westDoor = new List<GameObject>();
        southDoor = new List<GameObject>();
        eastDoor = new List<GameObject>();
        _room = transform.gameObject;
        roomScript = _room.GetComponent<Room>();
        for (int i = 0; i < _room.transform.GetChild(0).GetChild(1).childCount; i++)
        {
            if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("N"))
            {
                roomScript.northDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("S"))
            {
                roomScript.southDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("E"))
            {
                roomScript.eastDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("W"))
            {
                roomScript.westDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
        }
        CreateDoors();
    }

    private void CreateDoors()
    {
        int[] randomDoors = new int[2];
        randomDoors[0] = Random.Range(0, 5);
        randomDoors[1] = Random.Range(0, 5);
        while (randomDoors[0] == randomDoors[1])
            randomDoors[1] = Random.Range(0, 5);
        if (Random.Range(0, 9) > 4)
        {
            transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject.SetActive(true);
            transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject.SetActive(true);
        }
    }
    private void CreateDoors(string directionFrom)
    {
        switch (directionFrom)
        {
            case "North":
                southDoor[Random.Range(0, southDoor.Count - 1)].SetActive(true);
                break;
        }
    }
    public string GetDoor()
    {
        Debug.Log(transform);
        return "Hallo";
        for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++)
        {
            if (northDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
            {
                return "North";
            }
            else if (southDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
            {
                return "South";
            }
            else if (westDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
            {
                return "West";
            }
            else if (eastDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
            {
                return "East";
            }
        }
        return null;
    }
}
