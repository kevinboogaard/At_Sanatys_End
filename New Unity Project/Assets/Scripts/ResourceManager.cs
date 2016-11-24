using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {
  
    public int Food;
    public int Water;
    public int Buildmaterial;
    public int Manpower;
    public int MaxManPower = 5;
    public int wapens;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
