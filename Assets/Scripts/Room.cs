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
    private void Start()
    {
        northDoor = new List<GameObject>();
        westDoor = new List<GameObject>();
        southDoor = new List<GameObject>();
        eastDoor = new List<GameObject>();
        _room = transform.gameObject;
        roomScript = _room.GetComponent<Room>();
        Debug.Log(_room);
        for (int i = 0; i < _room.transform.GetChild(0).GetChild(1).childCount; i++)
        {
            Debug.Log(_room.transform.GetChild(0).GetChild(1).GetChild(i).name);
            if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("N"))
            {
                Debug.Log("looping");
                roomScript.northDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("S"))
            {
                Debug.Log("looping");
                Debug.Log(roomScript.southDoor);
                roomScript.southDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("E"))
            {
                Debug.Log("looping");
                roomScript.eastDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
            else if (_room.transform.GetChild(0).GetChild(1).GetChild(i).name.Contains("W"))
            {
                Debug.Log("looping");
                roomScript.westDoor.Add(_room.transform.GetChild(0).GetChild(1).GetChild(i).gameObject);
                continue;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
