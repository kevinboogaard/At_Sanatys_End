using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rooms : MonoBehaviour
{
    private GameObject popupscreen;
    [SerializeField]public int RoomID;
    [SerializeField]private int myId;
    [SerializeField]public bool clickAble = true;
    private RoomController roomController;
    [SerializeField]private GameObject food;
    [SerializeField]private AudioSource CollectAudio;
    public bool SettingRoom;

    void Start()
    {
        RoomID = 0;
    }
    public void SetPopUp(GameObject screen)
    {
        popupscreen = screen;
    }
    public void SetRoomController(RoomController controller)
    {
        roomController = controller;
    }
    public void SetID(int id)
    {
        myId = id;
    } 

    public IEnumerator Click()
    {
       
        if (clickAble == true && SettingRoom == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (RoomID == 0)
                {
                    yield return new WaitForSeconds(0.1f);
                    //Debug.Log("menuUp");
                    roomController.ToggleRooms();
                    popupscreen.SetActive(true);
                    roomController.Selected = myId;
                }

                if (RoomID == 1)
                {
                    food = GetComponentInChildren<FoodRoom>().gameObject;
                    food.GetComponent<FoodRoom>().FoodRoomCollect();
                    CollectAudio.Play();
                }
            }
        }
    }
    

    void Update()
    {
        
    }

    public bool SetClickAble
    {
        get
        {
            return clickAble;
        }
        set
        {
            clickAble = value;
        }
    }

}

