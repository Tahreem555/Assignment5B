using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit_game : MonoBehaviour
{
   

    public void quit_game_on()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    
}
