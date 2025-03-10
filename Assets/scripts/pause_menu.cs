using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_menu : MonoBehaviour
{
    protected bool gamepaused  = false;
    public GameObject Escape_menu;
    public GameObject settings_menu;
    public GameObject settings;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)){
            if (gamepaused){
                Resume();
            }
            else{
                Pause();
            }
       } 

    }
    void Resume(){
        Escape_menu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked; 
        gamepaused = false;

        
    }
    void Pause(){
        Escape_menu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gamepaused = true;

        }

}
    
    

