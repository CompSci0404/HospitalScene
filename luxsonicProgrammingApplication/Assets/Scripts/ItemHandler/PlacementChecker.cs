using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// <c>placementChecker</c>
/// 
/// determines if a item has been placed in  trigger. Then sends a message to the 
/// scenario manager informing a item has been placed within a trigger.
/// </summary>
public class PlacementChecker : MonoBehaviour
{
    public string nameOfItemPlacedHere;        /*name of prop that is supposed to placed within this trigger.*/

    private ScenarioManager SManager;         /*the ScenarioManager system! */ 

    private bool itemPlaced;                  /*boolean check to see if placed item correctly!*/


    /// <summary>
    /// <c>onTriggerEnter</c>
    /// 
    /// pre: attach this script to the object that is looking for a prop to trigger it.
    /// 
    /// post: checks to see if the object trigging a collision is supposed to be here or not.
    ///       sends a message to the scenario Manager. 
    ///       
    /// </summary>
    /// <param name="other">collider, the object trigging this collision.</param>
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals(nameOfItemPlacedHere))
        {
            itemPlaced = true;

            SManager.updateScenarioManager(itemPlaced, nameOfItemPlacedHere);

           // other.gameObject.GetComponent<Rigidbody>().isKinematic = false;


        }
    }

    private void Start()
    {
        this.itemPlaced = false;
        this.SManager = GameObject.FindGameObjectWithTag("SManager").GetComponent<ScenarioManager>();

    }
}
