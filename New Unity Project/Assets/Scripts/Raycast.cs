using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

    public bool setRoom;
    public bool canclick;
    [SerializeField]private GameObject popUpScreen;
    public GameObject SetRoom;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
            if (hit.collider != null)
            {
                GameObject target = hit.collider.gameObject;
                if (setRoom == false)
                {

                    if (target.tag == "Room" && canclick == true)
                    {
                        target.GetComponent<SpriteRenderer>().enabled = target.GetComponent<SpriteRenderer>().enabled == true ? false : true;
                        target.GetComponent<Rooms>().StartCoroutine(target.GetComponent<Rooms>().Click());
                    }
                    if (target.tag == "Player")
                    {
                        target.GetComponent<CharacterScript>().setScreenTrue(popUpScreen);
                    }
                }

                if (setRoom == true)
                {
                    SetRoom = target;//.GetComponent<RoomController>().SetRoom;
                    setRoom = false;
                }
            }
        }
    }
}
