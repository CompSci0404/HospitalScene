using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenuHandler : MonoBehaviour
{

    public int UIChildPositionNumber;           /*which child is the UI located at. We cannot save Gameobjects references when a prop is a prefab.*/
    private GameObject PopUpUi; 



    public void hideUI()
    {

        PopUpUi.SetActive(false); 

    }


    public void showUI()
    {

        PopUpUi.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()
    {

        this.PopUpUi = this.gameObject.transform.GetChild(this.UIChildPositionNumber).gameObject;

        this.hideUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
