using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class PlayerController1 : MonoBehaviour
{
    

    public Text winText;

    public Text countText;

    private int count;

    public float speed;

    private GameObject childobject;
    private GameObject particleobject;
    int allcollisions = 0;

    string temp;

    findObjectChild1 objstring = new findObjectChild1();


    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

        count = 0;

        // we will update our UI text based on count value
        SetCountText();
        winText.text = "";

    }
    private void FixedUpdate()
    {
        // This grabs the input from our player through keyboard
        float moveHorizontal = Input.GetAxis("Horizontal"); // Record input from horizontal axis
        float moveVertical = Input.GetAxis("Vertical"); // Record Input from vertical axis 

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed );

      
    }



    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Pick Up") //Change tag
        {
            Destroy(coll.gameObject);

            childobject = coll.gameObject.transform.Find("Sphere").gameObject;
            temp = childobject.GetComponent<TextMesh>().text.ToString();
            Debug.Log(temp + "is child");

            

            Regex r = new Regex(@"\A(?:(.)(?=.*?((?(2)\1\2|\1))\z))*?.?\2\z");

            


            if (r.IsMatch(temp))
            {
                Destroy(coll.gameObject);
                count = count + 1;
               
                Debug.Log("is palindrome");

                
            }
            else
            {
               
                Debug.Log("not palindrome");
            }    

            SetCountText();
            allcollisions++;
        }

        setPalindromeNo();
    }






    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
      
    }

    void setPalindromeNo()
    {
        if (allcollisions>= 11)
        {
            winText.text = "The Number of Palindromes is: " + count;
        }

    }
}
