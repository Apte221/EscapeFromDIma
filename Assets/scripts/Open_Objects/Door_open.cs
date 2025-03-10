using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{
    public GameObject Key;
    private BoxCollider cl;
    public bool isOpen = false;
    public Animator animator;
    private bool isLocekd = true;


    private void Start()
    {
        cl = GetComponent<BoxCollider>();
    }


    public void TryOpen(GameObject hlitem)
    {
        if (Key != null && isLocekd)
        {
            if (hlitem == Key)
            {
                Open();
            
            }


        }
        else { Open(); }

    }


    void Open()
    {
        isLocekd = false;
        isOpen = !isOpen;
        animator.SetBool("Isopen", isOpen);


    }
  


}
