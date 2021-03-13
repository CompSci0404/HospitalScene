using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public  List<GameObject> possibleSpawns;
    private List<GameObject> medicalSupplies;
    private List<GameObject> allItems;
    private int numberTimesToShuffle = 50; 
    /*for now I think I can get by without storing each spawned item into its own ADT*/
   
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
            GameObject spawnedMedicalItem = Instantiate(this.medicalSupplies[y], this.possibleSpawns[y].transform.position, Quaternion.identity);

            spawnedMedicalItem.name = this.medicalSupplies[y].name;     /*removes cloned from name.*/


            this.allItems.Add(spawnedMedicalItem); 

        }


    }


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
