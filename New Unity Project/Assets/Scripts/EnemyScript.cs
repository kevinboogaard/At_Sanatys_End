using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    private Vector3 gotoPos;
    private GameObject Array;
    private float AttackTimer = 2;
    private bool timeractive = false;
    // Use this for initialization
    void Start() {

        Array = GameObject.FindGameObjectWithTag("Array");
        Array.GetComponent<AllTheCharacters>().CharacterList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(AttackTimer);
        if (timeractive == true)
        {
            AttackTimer -= 1 * Time.deltaTime;
        }

        if (transform.position != gotoPos)
        {
            timeractive = false;
            if (transform.position.y == gotoPos.y)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, gotoPos, 1 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.transform.position.x, gotoPos.y, 0), 1 * Time.deltaTime);
            }
        }
        else if (transform.position == gotoPos)
        {
            timeractive = true;
            if (AttackTimer <= 0 && timeractive == true)
            {
                Array.GetComponent<AllTheCharacters>().CharacterList[1].GetComponent<CharacterStats>().Life -= Random.Range(1, 5);
                AttackTimer = 2;
            }
        }
    }

    void SetGoToPos()
    {
        GameObject[] CloseRoomsarray = GameObject.FindGameObjectsWithTag("Room");
        GameObject ClosestRoom = gameObject;
        
        for(int i = 0;i < CloseRoomsarray.Length;i++)
        {
            if (CloseRoomsarray[i] != ClosestRoom)
            {
                ClosestRoom = CloseRoomsarray[i];
            }

            if (Vector3.Distance(transform.position, CloseRoomsarray[i].transform.position) <= Vector3.Distance(transform.position, ClosestRoom.transform.position))
            {
                ClosestRoom = CloseRoomsarray[i];
            }
        }

        gotoPos = ClosestRoom.transform.position;
    }
}
