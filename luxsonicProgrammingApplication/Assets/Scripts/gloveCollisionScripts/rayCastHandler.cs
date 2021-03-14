using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class rayCastHandler : XRRayInteractor
{
   
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        Debug.Log("does this touch?");

        if (interactable.gameObject.tag.Equals("Glove"))
        {

            GameObject hand = this.gameObject.transform.GetChild(0).gameObject;

            Debug.Log(hand.name);

            Physics.IgnoreLayerCollision(hand.layer, interactable.gameObject.layer, true);  // turn off collision for this hand, so glove does not automatically drop on hand holding it.

            Debug.Log("we are picking up a glove.");

           
            // respawn a second glove here most likely. 
            // turn off collision for this hand so glove does not got onto hand. VIA layer matrix.
        }


        return base.CanSelect(interactable);
    }


    
    public override bool CanHover(XRBaseInteractable interactable)
    {
        Debug.Log("test test test");


        if (interactable.gameObject.tag.Equals("Prop"))
        {
            interactable.GetComponent<PopUpMenuHandler>().showUI();

        }


        return base.CanHover(interactable);
    }

}
