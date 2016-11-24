using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrepScreen : MonoBehaviour {
    private int AllPoints;
    private int AllPoints2;
    private int Food;
    [SerializeField] private Slider food;
    private int Water;
    [SerializeField] private Slider water;
    private int Buildmaterial;
    [SerializeField] private Slider buildmaterial;
    private int Manpower;
    [SerializeField]private Slider manpower;
    private int Wapens;
    [SerializeField]private Slider wapens;

    [SerializeField]private GameObject stamp;

    [SerializeField]private GameObject FoodText;
    [SerializeField]private GameObject WaterText;
    [SerializeField]private GameObject BuildmaterialText;
    [SerializeField]private GameObject ManpowerText;
    [SerializeField]private GameObject wapensText;
    [SerializeField]private GameObject AllPointsText;
    [SerializeField]private ResourceManager manager;
    // Use this for initialization
    void Start() {
        AllPoints = 10;
        Food = 0;
        Water = 0;
        Buildmaterial = 0;
        Manpower = 0;
        Wapens = 0;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(AllPoints2);
        FoodText.GetComponent<Text>().text = Food.ToString();
        WaterText.GetComponent<Text>().text = Water.ToString();
        BuildmaterialText.GetComponent<Text>().text = Buildmaterial.ToString();
        ManpowerText.GetComponent<Text>().text = Manpower.ToString();
        wapensText.GetComponent<Text>().text = Wapens.ToString();
        AllPointsText.GetComponent<Text>().text = AllPoints.ToString();



        AllPoints = Food + Water + Buildmaterial + Manpower + Wapens;
        Food = (int)food.value;
        Water = (int)water.value;
        Buildmaterial = (int)buildmaterial.value;
        Manpower = (int)manpower.value;
        Wapens = (int)wapens.value;
    }

    IEnumerator StampScreen()
    {
        stamp.SetActive(true);
        yield return new WaitForSeconds(1f);
        manager.Food = Food;
        manager.Water = Water;
        manager.Buildmaterial = Buildmaterial;
        manager.Manpower = Manpower;
        manager.wapens = Wapens;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Finish()
    {
        if (AllPoints <= 10)
        {
            StartCoroutine(StampScreen());
        }
        else if (AllPoints > 10)
        {
            //Error
            Debug.Log("Error");
        }
    }

}
