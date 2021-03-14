using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveCollisionScript : MonoBehaviour
{

    public Material gloveColor;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Glove"))
        {

            this.gameObject.GetComponent<MeshRenderer>().material = gloveColor;

            

            Destroy(collision.gameObject);  // get rid of the glove prop.
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
