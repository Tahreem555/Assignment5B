using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{

    string  catchvalue;
    private GameObject particle;
    public  GameObject pickCube;

    public GameObject childobject;

    findObjectChild objchild = new findObjectChild();


    //public Vector3 center;
    //public Vector3 size;
    //public LayerMask mask;
    //public bool checkCubefun = false;

   // public GameObject CubePrefab;
    private GameObject txt_box_parent;
    public Text txt_box;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cubespawn());
    }

    IEnumerator cubespawn()
    {
        for (int i = 1; i <= 25; i += 1)
        {
            
            Instantiate(pickCube, new Vector3(Random.Range(5f, 48f), 1f, Random.Range(50f, 70f)), Quaternion.identity);
            yield return new WaitForSeconds(0.006f);
            if(i < 25)
            {
                childobject.GetComponent<TextMesh>().text = objchild.MatchingParanthesis();
            }
            else
            {
                childobject.GetComponent<TextMesh>().text = objchild.changeString();
               
                particle = childobject.gameObject.transform.Find("Particle System").gameObject;
                particle.SetActive(false);
            }
            
           
          
        }
        
        for (int i = 26; i <= 55; i += 1)
        {
            Instantiate(pickCube, new Vector3(Random.Range(28f, 61f), 1f, Random.Range(30f, 90f)), Quaternion.identity);
            yield return new WaitForSeconds(0.005f);
            
        }

        for (int i = 56; i <= 65; i += 1)
        {
            Instantiate(pickCube, new Vector3(Random.Range(71f, 77f), 1f, Random.Range(19f, 40f)), Quaternion.identity);
            yield return new WaitForSeconds(0.005f);

        }

        for (int i = 66; i <= 83; i += 1)
        {
            Instantiate(pickCube, new Vector3(Random.Range(4f, 70f), 1f, Random.Range(1f, 20f)), Quaternion.identity);
            yield return new WaitForSeconds(0.005f);

        }
        
    }

    public void setText()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        txt_box.transform.position = namePos;
    }


}
