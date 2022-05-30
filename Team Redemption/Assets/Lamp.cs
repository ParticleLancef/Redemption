using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private float defaultPosY, downPosY;


    // Start is called before the first frame update
    void Start()
    {
        //lampObj = FindObjectOfType<Lamp>(true);
        defaultPosY = transform.position.y;
        downPosY = defaultPosY - 3.5f;

    }

    //private Coroutine lampRoutine;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StopAllCoroutines();
            //StartCoroutine("MoveLamp(downPos)");
            StartCoroutine(MoveLamp(downPosY));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StopAllCoroutines();
            //StartCoroutine("MoveLamp(downPos)");
            StartCoroutine(MoveLamp(defaultPosY));
        }
    }

    IEnumerator MoveLamp(float finalPosY)
    {
        float time = 0;
        while (transform.position.y != finalPosY)
        {
            time += 0.00001f;
            float pos = Mathf.Lerp(transform.position.y, finalPosY, time);
            transform.position = new Vector3(transform.position.x, pos, transform.position.z);
            print(transform.position); 
            yield return null;
        }

    }
}
