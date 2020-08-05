using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class findObjectChild : MonoBehaviour
{

   private static System.Random random = new System.Random();
   
    public GameObject childobject;
    private float speed = 3f;
    private string textstring;

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
        string characters = "xt6()";

        string newcode;
        string code = "";
        int temp = 0;
        
        int rand_range = random.Next(9, 15);
        for (int i = 1; i < rand_range; i++)
        {
            temp = random.Next(0, characters.Length);

            code = code + characters[temp];
        }

        return newcode =code;
    }



    public string MatchingParanthesis()
    {
        string newcode;
        string characters = "xt6()";
        while (true)
        {
            string code = "";
            int temp = 0;
            char[] exp;
            int randm = random.Next(9, 15);
            for (int i = 1; i < randm; i++)
            {
                temp = random.Next(0, characters.Length);

                code = code + characters[temp];
            }

            //Console.WriteLine(code);
            exp = code.ToCharArray();
            
            if (BalancedParan.areParenthesisBalanced (exp))
            {
                newcode = code;
                Console.WriteLine(newcode);
                break;
            }
            Console.WriteLine(code);

        }

        return newcode;

    }

}
public class BalancedParan
{
    public class stack
    {
        public int top = -1;
        public char[] items = new char[100];

        public void push(char x)
        {
            if (top == 99)
            {
                Console.WriteLine("Stack full");
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
