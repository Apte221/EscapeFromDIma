using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_button : MonoBehaviour , IItem_to_use 
{
    public GameObject Key;
    public void Interact(GameObject holdetItem)
    {
        if (holdetItem == Key) { GetComponent<Renderer>().material.color = Color.red; }
        

    }

}
