using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScenarioManager : MonoBehaviour
{
    public int numberOfItemsInPlay;

    public GameObject GameOverCanvas;

    public GameObject scrollWheelContent; 

    private Dictionary<string, bool> bottomShelfItems;

    private itemSpawner IS;

    private bool completedSimulationOnce;

    private float timeSinceLastRestart;

    private bool endGamePrompt;

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

    public void cleanUpScenarioManager()
    {
        this.bottomShelfItems.Clear();
        this.endGamePrompt = false;

    }


    public void endGame()
    {
        this.GameOverCanvas.SetActive(true);

        string stats = ""; 

        if(this.completedSimulationOnce == false)
        {

            float timeCovertedToMinutes = Time.timeSinceLevelLoad; // grab the current time within level. First time is easy. 

            Debug.Log("time for reset: " + timeCovertedToMinutes);

            stats += "Total time to complete simulation: " + timeCovertedToMinutes.ToString() + " seconds \n";

            this.completedSimulationOnce = true; 
        }
        else
        {


            float timeSinceLoad = Time.timeSinceLevelLoad;  // current time of completing this run of simulation.

            float totalTimeFromReset = (timeSinceLoad - this.timeSinceLastRestart); // subtract by when the player clicked restart on the simulation.

            Debug.Log("time for reset: yeet " + totalTimeFromReset); 

            this.timeSinceLastRestart = timeSinceLoad; 

            stats += "Total time to complete simulation: " + totalTimeFromReset.ToString() + " seconds \n";
        }


        stats += "Grade: A+ \n";

        scrollWheelContent.GetComponentInChildren<Text>().text = stats;        /*provide some cool stats for the player, to validate their accomplishments!*/

        this.endGamePrompt = true;

    }
    
    

    public void restartScenario()
    {
        // aquire time at the start of the new simulation run time. 

        this.timeSinceLastRestart = Time.timeSinceLevelLoad;

        this.GameOverCanvas.SetActive(false);

        IS.cleanUpItems();
        IS.spawnItemsOnShelf();
        this.cleanUpScenarioManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GameOverCanvas.SetActive(false);
        this.bottomShelfItems = new Dictionary<string, bool>();
        this.IS = GameObject.FindGameObjectWithTag("itemHandler").GetComponent<itemSpawner>();

        this.completedSimulationOnce = false;
        this.endGamePrompt = false; 

    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.numberOfItemsInPlay == this.bottomShelfItems.Count && this.endGamePrompt == false)
        {
            endGame();

        }


    }
}
