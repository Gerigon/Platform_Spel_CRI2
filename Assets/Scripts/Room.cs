using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<GameObject> northDoor;
    public List<GameObject> westDoor;
    public List<GameObject> southDoor;
    public List<GameObject> eastDoor;
    public Vector3 enterPosition;

    private Room roomScript;



    public void Initialize()
    {
        northDoor = new List<GameObject>();
        westDoor = new List<GameObject>();
        southDoor = new List<GameObject>();
        eastDoor = new List<GameObject>();
        roomScript = GetComponent<Room>();
        for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++)
        {
            Debug.Log(transform.GetChild(0).GetChild(1).GetChild(i).name);
            if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("N"))
            {
                northDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("S"))
            {
                southDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("E"))
            {
                eastDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("W"))
            {
                westDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
        }
        CreateDoors();
    }
    public void Initialize(string directionFrom)
    {
        northDoor = new List<GameObject>();
        westDoor = new List<GameObject>();
        southDoor = new List<GameObject>();
        eastDoor = new List<GameObject>();
        roomScript = GetComponent<Room>();
        for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++)
        {
            Debug.Log(transform.GetChild(0).GetChild(1).GetChild(i).name);
            if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("N"))
            {
                northDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("S"))
            {
                southDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("E"))
            {
                eastDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("W"))
            {
                westDoor.Add(transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
        }
        CreateDoors(directionFrom);
    }

    public void CreateDoors()
    {
        int[] randomDoors = new int[2];
        randomDoors[0] = Random.Range(0, 5);
        randomDoors[1] = Random.Range(0, 5);
        while (transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject.activeSelf || randomDoors[0] == randomDoors[1])
        {
            randomDoors[0] = Random.Range(0, 5);
        }
        while (transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).gameObject.activeSelf || randomDoors[0] == randomDoors[1])
        {
            randomDoors[1] = Random.Range(0, 5);
        }

        if (Random.Range(0, 9) > 4)
        {
            transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject.SetActive(true);

            if (northDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "North");
            }
            else if (southDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "South");
            }
            else if (westDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "West");
            }
            else if (eastDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "East");
            }

            transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).gameObject.SetActive(true);
            if (northDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).transform.position, "North");
            }
            else if (southDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).transform.position, "South");
            }
            else if (westDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).transform.position, "West");
            }
            else if (eastDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[1]).transform.position, "East");
            }
        }
        else
        {
            transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject.SetActive(true);
            if (northDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "North");
            }
            else if (southDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "South");
            }
            else if (westDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "West");
            }
            else if (eastDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).gameObject))
            {
                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(randomDoors[0]).transform.position, "East");
            }
        }

        Debug.Log("Deuren zijn geactiveerd");
    }
    public void CreateDoors(string directionFrom)
    {
        int randomNum;
        switch (directionFrom)
        {
            case "North":
                randomNum = Random.Range(0, southDoor.Count - 1);
                southDoor[randomNum].SetActive(true);
                enterPosition = southDoor[randomNum].transform.position;
                break;
            case "West":
                randomNum = Random.Range(0, eastDoor.Count - 1);
                eastDoor[randomNum].SetActive(true);
                enterPosition = eastDoor[randomNum].transform.position;
                break;
            case "East":
                randomNum = Random.Range(0, westDoor.Count - 1);
                westDoor[randomNum].SetActive(true);
                enterPosition = westDoor[randomNum].transform.position;
                break;
            case "South":
                randomNum = Random.Range(0, northDoor.Count - 1);
                northDoor[randomNum].SetActive(true);
                enterPosition = northDoor[randomNum].transform.position;
                break;
        }
        CreateDoors();
    }
    //public string GetDoor()
    //{
    //    Debug.Log("deuren worden gecontroleerd");
    //    for (int i = 0; i < transform.GetChild(0).GetChild(1).childCount; i++)
    //    {
    //        Debug.Log("is active: " + transform.GetChild(0).GetChild(1).GetChild(i).gameObject.activeSelf);
    //        if (transform.GetChild(0).GetChild(1).GetChild(i).gameObject.activeSelf)
    //        {
    //            if (northDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
    //            {
    //                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(i).transform.position, "North");
    //                return "North";
    //            }
    //            else if (southDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
    //            {
    //                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(i).transform.position, "South");
    //                return "South";
    //            }
    //            else if (westDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
    //            {
    //                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(i).transform.position, "West");
    //                return "West";
    //            }
    //            else if (eastDoor.Contains(transform.GetChild(0).GetChild(1).GetChild(i).gameObject))
    //            {
    //                LevelGenerator.instance.RegisterDoor(transform.GetChild(0).GetChild(1).GetChild(i).transform.position, "East");
    //                return "East";
    //            }
    //        }
    //    }
    //    return null;
    //}
}
