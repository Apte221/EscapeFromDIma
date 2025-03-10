
using UnityEngine;
using UnityEngine.UI;


public class play_button : pause_menu
{
  



    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Resume);
    }



       

    
  void Resume(){
        Escape_menu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked; 
        gamepaused = false;

        
    }

}
        
    