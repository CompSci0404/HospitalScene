using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public int numberOfItemsInPlay; 
    
    private Dictionary<string, bool> bottomShelfItems; 

   

    public void updateScenarioManager(bool itemPlaced, string nameOfItem)
    {

        if (this.bottomShelfItems.ContainsKey(nameOfItem))
        {

            this.bottomShelfItems[nameOfItem] = itemPlaced;

        }
        else
        {
            this.bottomShelfItems.Add(nameOfItem, itemPlaced);

        }

    }

    public void endGame()
    {

        Debug.Log("we have won the game!");

    }

    // Start is called before the first frame update
    void Start()
    {
        this.bottomShelfItems = new Dictionary<string, bool>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.numberOfItemsInPlay == this.bottomShelfItems.Count)
        {
            endGame();

        }


    }
}
