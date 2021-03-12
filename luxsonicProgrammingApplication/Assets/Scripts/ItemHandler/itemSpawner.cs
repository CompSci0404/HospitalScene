using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public  List<GameObject> possibleSpawns;
    private List<GameObject> medicalSupplies;
    
    /*for now I think I can get by without storing each spawned item into its own ADT*/
   
    public void buildMedicalSupplies()
    {
        this.medicalSupplies = new List<GameObject>();
      

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


        }


        for(int z = 0; z < shuffledSpawns.Count; z++)
        {
            this.possibleSpawns.Add(shuffledSpawns[z]);     /*reset the spawn points so we can re-shuffle them to repeat the sceniaro if the player deems so.*/
        }



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
