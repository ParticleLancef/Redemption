using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private float defaultPosY, downPosY;
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        //lampObj = FindObjectOfType<Lamp>(true);
        defaultPosY = transform.position.y;
        downPosY = defaultPosY - 2f;

    }

    //private Coroutine lampRoutine;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            StopAllCoroutines();
            //StartCoroutine("MoveLamp(downPos)");
            //StartCoroutine(MoveLamp(downPosY));
            MoveLampUp();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            StopAllCoroutines();
            //StartCoroutine("MoveLamp(downPos)");
            //StartCoroutine(MoveLamp(defaultPosY));
            MoveLampDown();
        }
    }

    void MoveLampUp()
    {
        float nspeed = speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, (transform.position.y - nspeed), transform.position.z);

        if (transform.position.y <= downPosY)
        {
            transform.position = new Vector3(transform.position.x, downPosY, transform.position.z);
        }
    }

    void MoveLampDown()
    {
        float nspeed = speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, (transform.position.y + nspeed), transform.position.z);

        if (transform.position.y >= defaultPosY)
        {
            transform.position = new Vector3(transform.position.x, defaultPosY, transform.position.z);
        }
    }

}

   

