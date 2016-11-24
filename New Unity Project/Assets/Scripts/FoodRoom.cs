using UnityEngine;
using System.Collections;

public class FoodRoom : MonoBehaviour {
    private GameObject ResourceManager;
    [SerializeField]private GameObject ReadyToCollect;
    private int resource;
    private bool clicked = false;
    [SerializeField]private float timer;
    [SerializeField]private float timerint;
	// Use this for initialization
	void Start ()
    {
        
        ResourceManager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timerint)
        {
            timer += 0.1f;
        }

        if (timer >= timerint)
        {
            ReadyToCollect.SetActive(true);
        }

        if ( clicked == true)
        {
            ResourceManager.GetComponent<ResourceManager>().Food += 2;
            ResourceManager.GetComponent<ResourceManager>().Water += 2;
            clicked = false;
            timer = 0;
            ReadyToCollect.SetActive(false);
        }
    }
        

    public void FoodRoomCollect()
    {
        if (ReadyToCollect.activeSelf == true)
        {
            clicked = true;
        }
        else
        {
            Debug.Log("foodcollect");
        }
    }
}
