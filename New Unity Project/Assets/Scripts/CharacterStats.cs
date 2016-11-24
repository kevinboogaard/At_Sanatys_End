using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {
    
    [SerializeField]public int Life = 100;
    private float foodTimer = 60;
    private GameObject resourceObject;
    private ResourceManager resource;
    public GameObject Array;
    // Use this for initialization
    void Start () {
        resourceObject = GameObject.FindGameObjectWithTag("Manager");
        resource = resourceObject.GetComponent<ResourceManager>();
        Array = GameObject.FindGameObjectWithTag("Array");
        Array.GetComponent<AllTheCharacters>().CharacterList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(Array);
        /*for (int i = 0; i < Array.GetComponent<AllTheCharacters>().CharacterList.Count; i++)
        {
            if (Array.GetComponent<AllTheCharacters>().CharacterList[i].GetComponent<CharacterStats>().Life <= 0)
            {
                Debug.Log("Death");
            }
        }*/
        //Debug.Log(foodTimer);
        if (foodTimer > 0)
        {
            foodTimer -= 1f * Time.deltaTime;
        }
        else
        {
            if (resource.GetComponent<ResourceManager>().Food >= 1)
            {
                resource.GetComponent<ResourceManager>().Food -= 1;
                foodTimer = 60;
            }
            else if (resource.GetComponent<ResourceManager>().Food <= 0)
            {
                Life -= 1;
                foodTimer = 60;
            }

        }

       
	}
}
