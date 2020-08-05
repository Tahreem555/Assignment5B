using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public class findObjectChild1 : MonoBehaviour
{

    private static System.Random random = new System.Random();
   
    public GameObject childobject;
    private float speed = 3f;
    private string textstring;

    // Start is called before the first frame update
    void Start()
    {
      //  parent = transform.Find("pick").gameObject;
     //   childobject = transform.Find("Sphere").gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(15, 30, 45) * speed * Time.deltaTime);

        Rigidbody rb = childobject.GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;

        
    }

    public void textmeshcomp(string ttx)
    {
        childobject.GetComponent<TextMesh>().text = ttx;
    }


    public string changeString()
    {
        string characters = "xn8";

        string newcode;
        string code = "";
        int temp = 0;

        int rand = random.Next(9, 15);
        for (int i = 1; i < rand; i++)
        {
            temp = random.Next(0, characters.Length);

            code = code + characters[temp];
        }
 
        newcode = code;
        return newcode;
    }



    public string palindromeString()
    {

        string newcode;
        //string code = "";
        //int temp = 0;



        Regex r = new Regex(@"\A(?:(.)(?=.*?((?(2)\1\2|\1))\z))*?.?\2\z");

        //Random rnd = new Random();
        string characters = "xn8";
        while (true)
        {

            string code = "";
            int temp = 0;

            int randm = Random.Range(9, 15);
            for (int i = 1; i < randm; i++)
            {
                temp = Random.Range(0, characters.Length);

                code = code + characters[temp];
            }

            //Console.WriteLine(code);
            if (r.IsMatch(code))
            {
                newcode = code;
                break;
            }

        }

        return newcode;

    }

}
