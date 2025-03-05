using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using Unity.VisualScripting;
using UnityEngine.UI;



public class Settings_in_game : MonoBehaviour
{

    public Canvas settings;
    public Button settings_menu;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("settings");
    }

    // Update is called once per frame
    void Update()
    {
    //    if(OnButtonClick)
    }
}
