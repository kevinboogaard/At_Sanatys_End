using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    [SerializeField]private GameObject InfoScreen;
    [SerializeField]private GameObject room;
    [SerializeField]private GameObject Ray;
    [SerializeField]private GameObject PopUpScreen;
    private Vector3 temp;
    private bool OnSide = false;
    private Vector3 gotoPos;
	// Use this for initialization
	void Start () {
        gotoPos = transform.position;
        InfoScreen = GameObject.FindGameObjectWithTag("infoScreen");
        //PopUpScreen = GameObject.FindGameObjectWithTag("popUpScreen");
        Ray = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position != gotoPos)
        {
            if (transform.position.y == gotoPos.y)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, gotoPos, 1 * Time.deltaTime);
            }
            else 
            {
                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, gotoPos.y, 0), 1 * Time.deltaTime);
            }
            /*else if (OnSide == false)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, temp,1 * Time.deltaTime);
            }*/
            /*if (transform.position.x == temp.x)
            {
                OnSide = true;
            }*/
        }
	}

    public void setScreenTrue(GameObject screen)
    {
        screen.SetActive(true);
    }
    public void setScreenFalse(GameObject screen)
    {
        screen.SetActive(false);
    }
    public void SetRoom()
    {
        Ray.GetComponent<Raycast>().setRoom = true;
        //Move(Ray.GetComponent<Raycast>().SetRoom);
        StartCoroutine("ReceiveRoom");
        setScreenFalse(PopUpScreen);
        //temp = transform.position += new Vector3(0,1,0);

    }
    private IEnumerator ReceiveRoom()
    {
        while(Ray.GetComponent<Raycast>().setRoom)
        {
            yield return new WaitForEndOfFrame();
        }
        Move(Ray.GetComponent<Raycast>().SetRoom);
        yield return new WaitForEndOfFrame();
    }
    public void Move(GameObject Room)
    {
        gotoPos = Room.transform.position;
    }
}
