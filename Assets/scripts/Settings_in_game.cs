using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using Unity.VisualScripting;
using UnityEngine.UI;



public class Settings_in_game : MonoBehaviour
{
    public GameObject settings;
    public Button settings_menu;
    // Start is called before the first frame update
    void Awake()
    {
         if (settings == null){
            settings = GameObject.FindGameObjectWithTag("Settings");
         }
        settings_menu.onClick.AddListener(Click);
        if (settings == GameObject.FindGameObjectWithTag("Settings")){
            settings.SetActive(true) ;

    }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Click(){
        
    }
}
