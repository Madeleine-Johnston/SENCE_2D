using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAnaBoardChanges : ObjInteraction
{
    public Collider info;
    public Collider icon;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<Collider>();
        icon = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && click == false)
        {
            //send raycast to detect collision
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if collision by raycast and object
            if (info.Raycast(ray, out hit, 100.0f))
            {
                image.SetActive(true);
            }
            else  
                if (icon.Raycast(ray, out hit, 1000.0f))
                {
                image.SetActive(true);
                }

        }
    }
}
