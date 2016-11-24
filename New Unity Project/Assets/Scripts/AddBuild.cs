using UnityEngine;
using System.Collections;

public class AddBuild : MonoBehaviour {

    [SerializeField]private float timer;
    private GameObject manager;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update () {
        if (timer < 60)
        {
            timer += 1 * Time.deltaTime;
        }
        else
        { 
            //manager.GetComponent<ResourceManager>().Buildmaterial += 2;
            timer = 0;
        }

	}
}
