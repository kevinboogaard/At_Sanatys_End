using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomController : MonoBehaviour {

    public int selectedRoomID;
    [SerializeField] private List<GameObject> roomList = new List<GameObject>();
    [SerializeField] private GameObject FoodPrefab;
    [SerializeField]private GameObject BaracksPrefab;
    private GameObject ResourceManager;
    private int Buildmaterial;
    public GameObject SetRoom;



    void Start()
    {
        ResourceManager = GameObject.FindGameObjectWithTag("Manager");
    }
    void Update()
    {
        if(roomList[selectedRoomID].tag == "FoodRoom")
        {
            roomList[selectedRoomID].GetComponent<Rooms>().SetClickAble = false;
        }

        //Buildmaterial = ResourceManager.GetComponent<ResourceManager>().Buildmaterial;

    }
    public int Selected
    {
        set
        {
            selectedRoomID = value - 1;
        }
    }


    public void GiveArray(GameObject objct)
    {
        roomList.Add(objct);
    }

    public void setRoom()
    {
        SetRoom = roomList[selectedRoomID];
    }

    public void FoodRoomOptions(GameObject screen)
    {
        screen.SetActive(false);
        ToggleRooms();
        if (Buildmaterial >= 2)
        {
            GameObject prefab;
            prefab = GameObject.Instantiate(FoodPrefab);
            prefab.transform.SetParent(roomList[selectedRoomID].transform);
            prefab.transform.localPosition = new Vector3(0, 0, 0);
            prefab.transform.localScale = new Vector3(1, 1, 1);
            ResourceManager.GetComponent<ResourceManager>().Buildmaterial -= 2;
            roomList[selectedRoomID].GetComponent<Rooms>().RoomID = 1;
        }
    }

    public void BaracORoomptions(GameObject screen)
    {
        screen.SetActive(false);
        ToggleRooms();
        if (Buildmaterial >= 3)
        {
            GameObject prefab;
            prefab = GameObject.Instantiate(BaracksPrefab);
            prefab.transform.SetParent(roomList[selectedRoomID].transform);
            prefab.transform.localPosition = new Vector3(0, 0, 0);
            prefab.transform.localScale = new Vector3(1, 1, 1);
            ResourceManager.GetComponent<ResourceManager>().Buildmaterial -= 3;
            roomList[selectedRoomID].GetComponent<Rooms>().RoomID = 2;
            ResourceManager.GetComponent<ResourceManager>().MaxManPower += 5;
        }
    }

    public void ToggleRooms()
    {
        bool boolToSet = roomList[0].GetComponent<Rooms>().SetClickAble;
        boolToSet = (boolToSet == true ? false : true);
        //Debug.Log(boolToSet);
        foreach (GameObject objct in roomList)
        {
            objct.GetComponent<Rooms>().SetClickAble = boolToSet;
        }
    }

   
}
