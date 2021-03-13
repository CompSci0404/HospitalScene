using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    public string nameOfItemPlacedHere;

    private ScenarioManager SManager;         /*the ScenarioManager system! */ 

    private bool itemPlaced;            /*boolean check to see if placed item correctly!*/ 

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.Equals(nameOfItemPlacedHere))
        {
            itemPlaced = true;

            SManager.updateScenarioManager(itemPlaced, nameOfItemPlacedHere);

        }

    }


    private void Start()
    {
        this.itemPlaced = false;
        this.SManager = GameObject.FindGameObjectWithTag("SManager").GetComponent<ScenarioManager>();

    }
}
