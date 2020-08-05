using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject1 : MonoBehaviour
{

    string catchvalue;
    private GameObject particle;
    public GameObject pickCube;

    public GameObject childobject;

    findObjectChild1 objchild = new findObjectChild1();


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

    // Update is called once per frame
    void Update()
    {

        


    }
   
    
    /*
    public void SpawnCube()
    {
     /*
        Vector3 pos = center + new Vector3(Random.Range(-1, 5), Random.Range(1, 1), Random.Range(-1, 5));
        //Instantiate(CubePrefab, spawnPos, Quaternion.identity);
        Instantiate(CubePrefab, pos, Quaternion.identity);
        txt_box_parent = new GameObject();
        txt_box_parent.transform.parent = GameObject.Find("Canvas").transform;
        txt_box = txt_box_parent.AddComponent<Text>();
        txt_box.transform.position = pos;
        txt_box.text = "this is my text";
        // txt_box.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

*/

    IEnumerator cubespawn()
    {
        for (int i = 0; i < 5; i += 1)
        {
            
            Instantiate(pickCube, new Vector3(Random.Range(-7f, 7f), 1, 6), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
            if(i < 4)
            {
                childobject.GetComponent<TextMesh>().text = objchild.palindromeString();
            }
            else
            {
                childobject.GetComponent<TextMesh>().text = objchild.changeString();
               
                particle = childobject.gameObject.transform.Find("Particle System").gameObject;
                particle.SetActive(false);
            }
            
           
          
        }

        for (int i = 5; i < 7; i += 1)
        {
            Instantiate(pickCube, new Vector3(Random.Range(-7f, 7f), 1, -9), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
            
        }

        for (int i = 7; i < 9; i += 1)
        {
            Instantiate(pickCube, new Vector3(Random.Range(-9f, 9f), 1, -5), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);

        }

        for (int i = 9; i < 11; i += 1)
        {
            Instantiate(pickCube, new Vector3(Random.Range(-5f, 5f), 1, -3), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);

        }

    }






    public void setText()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        txt_box.transform.position = namePos;
    }


}
