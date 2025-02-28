using UnityEngine;
using UnityEngine.UI;


public class Dont_delete : MonoBehaviour
{
    public Button button;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        button.onClick.AddListener(delete_menu);
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    void delete_menu(){
        Transform child = transform.Find("main menu");
        if (child != null)
        {
            Destroy(child.gameObject);
        }
        
    }
}
