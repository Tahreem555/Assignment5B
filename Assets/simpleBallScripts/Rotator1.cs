using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator1 : MonoBehaviour
{

    void Start()
    {
        Transform childTransform = transform.Find("Sphere");
        Debug.Log(childTransform.eulerAngles);
        Debug.Log(childTransform.eulerAngles);
        childTransform.eulerAngles = new Vector3(-15, -30, -45);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

       
    }
}
