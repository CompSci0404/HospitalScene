using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// <c>rayCastHandler</c>
/// 
/// over rides the XR ray Interactor class so we can further define what happens 
/// when we the VR joy sticks use objects found within the scene. 
/// 
/// </summary>
public class rayCastHandler : XRRayInteractor
{
    private GameObject prop;    /*The prop that is currently has a ray cast hovering over it.*/

    /// <summary>
    /// <c>CanSelect</c>
    /// 
    /// pre: ensure XR settings are correctly setup within Scene to conduct VR game play. 
    /// 
    /// 
    /// post: When selecting a object, if the object is a Glove, ensure that we cannot put the glove on the current hand
    ///       grabbing it.
    /// 
    /// </summary>
    /// <param name="interactable"> the object that we are currently interacting within scene</param>
    /// <returns>true if we can interact with a object, false otherwise.</returns>
    public override bool CanSelect(XRBaseInteractable interactable)
    {
      

        if (interactable.gameObject.tag.Equals("Glove"))
        {

            Debug.Log("test?");
            interactable.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;


            GameObject hand = this.gameObject.transform.GetChild(0).gameObject;

           

            Physics.IgnoreLayerCollision(hand.layer, interactable.gameObject.layer, true);  /* turn off collision for this hand, so glove does not automatically drop on hand holding it.*/


        }
        else if (interactable.gameObject.tag.Equals("gloveBox"))
        {
            Debug.Log("test?2");
            interactable.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;


        }

        return base.CanSelect(interactable);
    }


    /// <summary>
    /// <c>CanHover</c>
    /// 
    /// pre: ensure XR settings are correctly setup within Scene to conduct VR game play.
    /// 
    /// post: handels when a the player points a joystick ray cast at a prop, activates the description UI window
    /// 
    /// </summary>
    /// <param name="interactable">the object that we are currently interacting within scene</param>
    /// <returns>True if we can hover over a object. False if not.</returns>
    public override bool CanHover(XRBaseInteractable interactable)
    {
        


        if (interactable.gameObject.tag.Equals("Prop") || interactable.gameObject.tag.Equals("gloveBox"))
        {
            interactable.GetComponent<PopUpMenuHandler>().showUI();

            prop = interactable.gameObject;

            interactable.lastHoverExited.AddListener(onLastHoverExited);

        }



        return base.CanHover(interactable);
    }

    /// <summary>
    /// <c>onLastHoverExited</c>
    /// 
    /// pre: hook up this current event to a listener. 
    /// 
    /// post: event is attached to a listener, when the player stops pointing ray cast beam 
    ///      at a prop game object, then hide the description UI. 
    ///      
    /// </summary>
    /// <param name="args">HoverExitEventArgs, handeled by main class, what is being passed to the delegate function</param>
    protected virtual void onLastHoverExited(HoverExitEventArgs args)
    {
        prop.GetComponent<PopUpMenuHandler>().hideUI();

    }

     

}
