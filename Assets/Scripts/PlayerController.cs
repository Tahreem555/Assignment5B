using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    public Text winText;

    public Text countText;

    private int count;

    public float speed;

    private GameObject childobject;
    private GameObject particleobject;
    int allcollisions = 0;

    string temp;

    findObjectChild objstring = new findObjectChild();
    
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


            char[] temp1 = temp.ToCharArray();
            if (check_balan_brack.areParenthesisBalanced(temp1))
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
        if (allcollisions>= 30)
        {
            winText.text = "The Number of Valid strings is: " + count;
        }

    }
}

public class check_balan_brack
{
    public class stack
    {
        public int top = -1;
        public char[] items = new char[100];

        public void push(char x)
        {
            if (top == 99)
            {

                Console.WriteLine();
                
            }
            else
            {
                items[++top] = x;
            }
        }

        char pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Underflow error");
                return '\0';
            }
            else
            {
                char element = items[top];
                top--;
                return element;
            }
        }

        bool isEmpty()
        {
            return (top == -1) ? true : false;
        }
    }

    /* Returns true if character1 and character2 
    are matching left and right Parenthesis */
    static bool isMatchingPair(char character1, char character2)
    {
        if (character1 == '(' && character2 == ')')
            return true;
        else if (character1 == '{' && character2 == '}')
            return true;
        else if (character1 == '[' && character2 == ']')
            return true;
        else
            return false;
    }

    /* Return true if expression has balanced  
    Parenthesis */
    public static bool areParenthesisBalanced(char[] exp)
    {
        /* Declare an empty character stack */
        Stack<char> st = new Stack<char>();

        /* Traverse the given expression to  
            check matching parenthesis */
        for (int i = 0; i < exp.Length; i++)
        {

            /*If the exp[i] is a starting  
                parenthesis then push it*/
            if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
                st.Push(exp[i]);

            /* If exp[i] is an ending parenthesis  
                then pop from stack and check if the  
                popped parenthesis is a matching pair*/
            if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
            {

                /* If we see an ending parenthesis without  
                    a pair then return false*/
                if (st.Count == 0)
                {
                    return false;
                }

                /* Pop the top element from stack, if  
                    it is not a pair parenthesis of character  
                    then there is a mismatch. This happens for  
                    expressions like {(}) */
                else if (!isMatchingPair(st.Pop(), exp[i]))
                {
                    return false;
                }
            }
        }

        /* If there is something left in expression  
            then there is a starting parenthesis without  
            a closing parenthesis */

        if (st.Count == 0)
            return true; /*balanced*/
        else
        { /*not balanced*/
            return false;
        }
    }


}