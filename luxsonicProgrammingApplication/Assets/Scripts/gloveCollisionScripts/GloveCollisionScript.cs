using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// <c>GloveCollisionScript</c>
/// 
/// 
/// when the player grabs a glove from the glove box, this script listens
/// for when the player applies the glove to one of the cube hands in scene.
/// Then this script handels the interaction between the glove and the VR hand. 
/// 
/// </summary>
public class GloveCollisionScript : MonoBehaviour
{

    public Material gloveColor;         /*the material of the glove, just change the VR hands to this material. */

    /// <summary>
    /// <c>OnCollisionEnter</c>
    /// 
    /// pre: ensure script is attached to vr hands in scene. 
    /// 
    /// post: when a object with a tag  glove interacts with the vr hands, 
    ///       updates that hand with a new material, that being the same as the gloves.
    /// 
    /// </summary>
    /// <param name="collision">Collision, the object colliding with the object that this script is attached to.</param>
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Glove"))
        {

            this.gameObject.GetComponent<MeshRenderer>().material = gloveColor;

            

            Destroy(collision.gameObject);  /* get rid of the glove prop.*/
        }

    }

}
