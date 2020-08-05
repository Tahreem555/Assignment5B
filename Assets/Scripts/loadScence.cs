using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadScence : MonoBehaviour
{
    public void sceneLoader(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
