using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>itemSpawner</c>
/// 
/// handels the spawning of objects within the current unity scene. 
/// to the assignment description.
/// </summary>
/// 
public class itemSpawner : MonoBehaviour
{
    public  List<GameObject> possibleSpawns;             /*all spawns that we have, to spawn a object.*/
    private List<GameObject> medicalSupplies;            /*each medical prop used, gained from the resource folder.*/
    private List<GameObject> allItems;                   /*all items spawned, stored within this list.*/
    private int numberTimesToShuffle = 50;               /*number of times to randomly shuffle the spawn locations.*/


    public GameObject gloveBox; 
   
    /// <summary>
    /// <c>buildMedicalSupplies</c>
    /// 
    /// pre: ensure that the folder being pulled from contains prefab content. If not exceptions will be thrown.
    /// 
    /// post: finds the medical props and stores them within the medical supplies. We have not spawned them yet though.
    /// </summary>
    public void buildMedicalSupplies()
    {
        this.medicalSupplies = new List<GameObject>();
        this.allItems = new List<GameObject>();

        UnityEngine.Object[] prefabs = Resources.LoadAll("requiredMedicalProps", typeof(GameObject)); 

        if(prefabs.Length != 0)
        {
            for (int x = 0; x < prefabs.Length; x ++)
            {
                GameObject meds = (GameObject)prefabs[x];

                medicalSupplies.Add(meds);                  /*think of it like constructing a medical bag! All prefabs will be put into the bag.*/
            }

        }
        else
        {
            throw new ResourceFolderError("nothing was found within the resources folder under the following path: resources/requiredMedicalProps");
        }
    }

    /// <summary>
    /// <c>spawnItemsOnShelf</c>
    /// 
    /// pre: ensure that medical supply list has been generated.
    /// 
    /// post: spawns each medical prop to a random spawn location. Add the spawned item to 
    /// a list to keep track of them within scene.
    /// </summary>
    public void spawnItemsOnShelf()
    {

        GameObject spawnHolder1 = null;
        GameObject spawnHolder2 = null;
        int randomNumber1 = -1;
        int randomNumber2 = -1; 

        
        for(int x = 0; x < this.numberTimesToShuffle; x++)
        {
            randomNumber1 = UnityEngine.Random.Range(0, this.possibleSpawns.Count);
            randomNumber2 = UnityEngine.Random.Range(0, this.possibleSpawns.Count);

            spawnHolder1 = this.possibleSpawns[randomNumber1];
            spawnHolder2 = this.possibleSpawns[randomNumber2];

            this.possibleSpawns[randomNumber1] = spawnHolder2;
            this.possibleSpawns[randomNumber2] = spawnHolder1;
        }

        for (int y = 0 ; y < this.medicalSupplies.Count; y++)
        {

            if (!this.medicalSupplies[y].name.Equals("GloveBox"))
            {


                GameObject spawnedMedicalItem = Instantiate(this.medicalSupplies[y], this.possibleSpawns[y].transform.position, Quaternion.identity);

                spawnedMedicalItem.name = this.medicalSupplies[y].name;     /*removes cloned from name.*/


                this.allItems.Add(spawnedMedicalItem);
            }
            else
            {
                Vector3 pos = this.possibleSpawns[y].transform.position;

                this.gloveBox.transform.position = pos;

                StartCoroutine(FreezeProps()); 


            }
        }


    }

    IEnumerator FreezeProps ()
    {

        yield return new WaitForSeconds(0.1f);
        this.gloveBox.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        this.gloveBox.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;


        
    }

    /// <summary>
    /// <c>cleanUpItems</c>
    /// 
    /// pre: system has been built.
    /// 
    /// post: cleans up props used within the simulation.
    /// </summary>
    public void cleanUpItems()
    {

        int totalPropsSpawned = this.allItems.Count;

        for (int x = 0; x < totalPropsSpawned; x ++)
        {

            GameObject p = this.allItems[x];

            Destroy(p); 
        }

        this.allItems.Clear();

    }

    // Start is called before the first frame update
    void Start()
    {

        

        if(possibleSpawns == null)
        {
            throw new InspectorMissSetup("ensure there is spawn points inserted within the spawnpoint List!");
            
        }

        this.buildMedicalSupplies();
        this.spawnItemsOnShelf();
        
    }

  
}
