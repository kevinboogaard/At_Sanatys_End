using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIResource : MonoBehaviour {
    private GameObject manager;
    [SerializeField]private GameObject BuildText;
    [SerializeField]private GameObject WaterText;
    [SerializeField]private GameObject FoodText;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {
        BuildText.GetComponent<Text>().text = manager.GetComponent<ResourceManager>().Buildmaterial.ToString();
        WaterText.GetComponent<Text>().text = manager.GetComponent<ResourceManager>().Water.ToString();
        FoodText.GetComponent<Text>().text = manager.GetComponent<ResourceManager>().Food.ToString();
    }
}
