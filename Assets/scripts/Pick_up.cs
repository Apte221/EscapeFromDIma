using System;
using UnityEngine;
using UnityEngine.UI;

public class Pick_up : MonoBehaviour
{

    public Transform handTr;
    public float pickupDs;
    private Camera plCamera;
    private GameObject holdet_item;
    public float power = 5;

    public Image crosshair; 
    public float normalSize = 10f; 
    public float enlargedSize = 20f;
    private bool isAimingAtPickupable = false;
    public float scaleSpeed;

    void Start()
    {
       plCamera = Camera.main;  
    }


    void Update()
    {

        isAimingAtPickupable = false;
        RaycastHit hit;
        Ray ray = plCamera.ScreenPointToRay(Input.mousePosition);
        if (holdet_item == null)
        {
            
            if (Physics.Raycast(ray, out hit, pickupDs))
            {

                if (hit.collider.CompareTag("Pickupable"))
                {
                    isAimingAtPickupable = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Pickup(hit.collider.gameObject);
                       
                    }
                    
                }


            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Drop();
            }
        }
        if (Physics.Raycast(ray, out hit, pickupDs))
            {

                if (hit.collider.CompareTag("Door"))
                {
                    isAimingAtPickupable = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    hit.collider.GetComponent<Door_open>().TryOpen(holdet_item);

                    }

                }
                else if (hit.collider.CompareTag("Interacteble")) 
                {
                isAimingAtPickupable = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<IItem_to_use>().Interact(holdet_item);


                }


            }


        }  
        
        
        

        float targetSize = isAimingAtPickupable ? enlargedSize : normalSize;
        crosshair.rectTransform.sizeDelta = Vector2.Lerp(crosshair.rectTransform.sizeDelta, new Vector2(targetSize, targetSize), Time.deltaTime * scaleSpeed);

    }

    void Pickup(GameObject objectToPickup)
    {
        holdet_item = objectToPickup;
        holdet_item.GetComponent<Rigidbody>().isKinematic = true;
        holdet_item.transform.position = handTr.position;
        holdet_item.transform.parent = handTr;

    }

    void Drop() 
    {
        holdet_item.transform.parent = null;
        holdet_item.transform.position = transform.position;
        holdet_item.GetComponent<Rigidbody>().isKinematic = false;
        Vector3 dr = plCamera.transform.forward;
        holdet_item.GetComponent<Rigidbody>().velocity = dr * power;
        holdet_item = null;
        

    }
}
