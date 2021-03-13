using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public  List<GameObject> possibleSpawns;
    private List<GameObject> medicalSupplies;
    private List<GameObject> allItems; 
    
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

        List<GameObject> shuffledSpawns = new List<GameObject>();

        int totalSpawns = this.possibleSpawns.Count;

        for(int x = 0; x < totalSpawns; x++)
        {
            int randomMedicalSpawn = UnityEngine.Random.Range(0, this.possibleSpawns.Count-1);

            shuffledSpawns.Add(this.possibleSpawns[randomMedicalSpawn]);

            this.possibleSpawns.RemoveAt(randomMedicalSpawn); 

        }

        for (int y = 0 ; y < this.medicalSupplies.Count; y++)
        {
            GameObject spawnedMedicalItem = Instantiate(this.medicalSupplies[y], shuffledSpawns[y].transform.position, Quaternion.identity);

            spawnedMedicalItem.name = this.medicalSupplies[y].name;     /*removes cloned from name.*/


            this.allItems.Add(spawnedMedicalItem); 

        }


        for(int z = 0; z < shuffledSpawns.Count; z++)
        {
            this.possibleSpawns.Add(shuffledSpawns[z]);     /*these will be re-shuffled anyways, so it does not matter which way then enter the list.*/
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
