using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    private GameObject[,] GridArray;
    [SerializeField]private int Height;
    [SerializeField]private int Lenght;
    [SerializeField]private GameObject RoomSpace;
    [SerializeField] private GameObject popUpScreen;
    private RoomController roomController;


	void Start () {
        roomController = GetComponent<RoomController>();
        GameObject parent = new GameObject();
        parent.name = "Rooms";
        GridArray = new GameObject[Lenght, Height];
        int k = 0;
        for (int i = 0; i < Lenght; i += 2)
        {
            for( int j = 0 ; j < Height; j += 1)
            {
                k++;
                GridArray[i, j] = (GameObject)Instantiate(RoomSpace, new Vector3(i-(Lenght/2), j-(Height/2), 0), Quaternion.identity);
                GridArray[i, j].GetComponent<Rooms>().SetPopUp(popUpScreen);
                GridArray[i, j].GetComponent<Rooms>().SetRoomController(roomController);
                GridArray[i, j].GetComponent<Rooms>().SetID(k);
                GridArray[i, j].transform.SetParent(parent.transform);
                GridArray[i, j].name = "Room " + k;
                GridArray[i, j].tag = "Room";
                roomController.GiveArray(GridArray[i, j]);
            }
        }
        
        //roomController.GiveArray(GridArray);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
