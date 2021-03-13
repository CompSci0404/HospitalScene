using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScenarioManager : MonoBehaviour
{
    public int numberOfItemsInPlay;

    public GameObject GameOverUI; 

    private Dictionary<string, bool> bottomShelfItems;
    private itemSpawner IS; 
   

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
        this.GameOverUI.SetActive(true);
        

    }

    public void restartScenario()
    {
        IS.cleanUpItems();
        IS.spawnItemsOnShelf();



    }

    // Start is called before the first frame update
    void Start()
    {
        this.GameOverUI.SetActive(false);
        this.bottomShelfItems = new Dictionary<string, bool>();
        this.IS = GameObject.FindGameObjectWithTag("itemHandler").GetComponent<itemSpawner>();

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
