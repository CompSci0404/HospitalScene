using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>PopUpMenuHandler</c>
/// 
/// handels turning on and off the UI description of each prop that is attached to each gameObject. 
/// </summary>
public class PopUpMenuHandler : MonoBehaviour
{

    public int UIChildPositionNumber;           /*which child is the UI located at. We cannot save Gameobjects references when a prop is a prefab.*/
    private GameObject PopUpUi;                 /*the Description UI element attached to each gameobject. Script handels giving a refrence*/


    /// <summary>
    /// <c>hideUI</c>
    /// 
    /// pre: none
    /// 
    /// post: hides the description UI
    /// </summary>
    public void hideUI()
    {

        PopUpUi.SetActive(false); 

    }

    /// <summary>
    /// <c>showUI</c>
    /// 
    /// pre: none
    /// 
    /// post: displays the description UI.
    /// </summary>
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

}
