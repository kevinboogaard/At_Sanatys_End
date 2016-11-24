using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckRoom : MonoBehaviour {
    [SerializeField]public List<GameObject> InsideRoom;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("a");
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            InsideRoom.Add(coll.gameObject);
            Debug.Log("playerr");
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(InsideRoom != null)
        if (coll.gameObject.tag == "Player")
        {
            InsideRoom.Remove(coll.gameObject);
            Debug.Log("playerr");
        }
    }

}
