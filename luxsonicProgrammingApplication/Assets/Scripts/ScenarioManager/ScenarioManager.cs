using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

/// <summary>
/// <c>scenario Manager</c>
/// 
/// handels the game play loop of the scene.  Determines if the player
/// has finished the simulation or not by placing content on the correct 
/// triggers. 
/// 
/// </summary>
public class ScenarioManager : MonoBehaviour
{
    public int numberOfItemsInPlay;                     /*How many props are currently spawned and are being used within the scene.*/

    public GameObject GameOverCanvas;                   /*Game over UI Canvas.*/

    public GameObject scrollWheelContent;               /*Content Gameobject supplied by the scroll wheel attached to the game over UI Canvas.*/

    private Dictionary<string, bool> bottomShelfItems;  /*Dictionary containing every object on the bottom shelf. True means the object is in the correct trigger location. */

    private itemSpawner IS;                             /*Item spawner, handels spawning and cleaning up items after a simulation play through.*/             

    private bool completedSimulationOnce;               /*for displaying stats after simulation, used to calculate the time taken pre each session.*/

    private float timeSinceLastRestart;                 /*time since we restarted the simulation, used to calculate time taking after multiply repeats.*/

    private bool endGamePrompt;                         /*have we reached game over? If so stop calling end game within the update loop.*/


    /// <summary>
    /// <c>updateScenarioManager</c>
    /// 
    /// pre: Ensure Dictionary is referenced, and nameOfItem, is the name of prop placed in the bottom shelf.
    ///      Ensure that the name of the prop does not have (clone) at the end.
    ///      
    /// post: updates the simulation manager  on wether or not a object is placed in a trigger.
    /// </summary>
    /// <param name="itemPlaced">boolean, a value determining if it is placed in a trigger correctly.</param>
    /// <param name="nameOfItem">string, name of the item placed.</param>
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

    /// <summary>
    /// <c>cleanUpScenarioManager</c>
    /// 
    /// pre: dictionary is referenced.
    /// 
    /// post: cleans up the encounter, enabling for re-play of simulation.
    /// </summary>
    public void cleanUpScenarioManager()
    {
        this.bottomShelfItems.Clear();
        this.endGamePrompt = false;

    }

    /// <summary>
    /// <c>endGame</c>
    /// 
    /// pre: check to see if scenario is finished first.
    /// 
    /// post: concludes simulation, updating stats and providing player with a grade for over all effort. 
    /// </summary>
    public void endGame()
    {
        this.GameOverCanvas.SetActive(true);

        string stats = ""; 

        if(this.completedSimulationOnce == false)
        {

            float timeCovertedToMinutes = Time.timeSinceLevelLoad; /* grab the current time within level. First time is easy. */ 

            Debug.Log("time for reset: " + timeCovertedToMinutes);

            stats += "Total time to complete simulation: " + timeCovertedToMinutes.ToString() + " seconds \n";

            this.completedSimulationOnce = true; 
        }
        else
        {


            float timeSinceLoad = Time.timeSinceLevelLoad;                          /* current time of completing this run of simulation.*/

            float totalTimeFromReset = (timeSinceLoad - this.timeSinceLastRestart); /* subtract by when the player clicked restart on the simulation.*/

            Debug.Log("time for reset: yeet " + totalTimeFromReset); 

            this.timeSinceLastRestart = timeSinceLoad; 

            stats += "Total time to complete simulation: " + totalTimeFromReset.ToString() + " seconds \n";
        }


        stats += "Grade: A+ \n";

        scrollWheelContent.GetComponentInChildren<Text>().text = stats;        /*provide some cool stats for the player, to validate their accomplishments!*/

        this.endGamePrompt = true;

    }
    
    
    /// <summary>
    /// <c>restartScenario</c>
    /// 
    /// pre: attach to a UI button.
    /// 
    /// post: restarts the game by cleaning up the scene, and re-randomizing each item on the top shelf.
    /// </summary>
    public void restartScenario()
    {
        /* aquire time at the start of the new simulation run time. */

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
