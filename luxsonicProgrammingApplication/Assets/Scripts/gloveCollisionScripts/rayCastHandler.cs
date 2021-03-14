using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class rayCastHandler : XRRayInteractor
{
   
    public override bool CanSelect(XRBaseInteractable interactable)
    {
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


}
