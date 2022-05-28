using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    //public Transform lampSpawn;
    public GameObject lampPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        //lampSpawn = GameObject.Find("Lamp_spawner").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Instantiate(lampPrefab, transform.position, Quaternion.identity);
            lampPrefab.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            //Destroy(lampPrefab);
            lampPrefab.SetActive(false);
        }
                
        
    }
}
