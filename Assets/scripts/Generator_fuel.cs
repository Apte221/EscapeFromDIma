using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Generator_fuel : MonoBehaviour
{
    public float cost_of_fuel;
 //   public Image bar;

    public float fuel ;
    private float max_fuel = 100f;

  //  public GameObject warning;
    // Start is called before the first frame update
    void Start()
    {
   //     warning.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        fuel -= cost_of_fuel * Time.deltaTime;
        Debug.Log(fuel);



        Warning();
    }
    public void Warning(){
        if (fuel < 20f)
        {
  //          warning.SetActive(true);
        }
    }
}
