using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controltext1 : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i += 1)
        {
            Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
            text.transform.position = namePos;
        }
    }
}
