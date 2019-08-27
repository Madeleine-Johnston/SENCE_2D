using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laptopChanges : MonoBehaviour {

    public Collider coll;
    public GameObject Laptop_off;
    public GameObject Laptop_on;
    public GameObject laptopClick;
    public bool click = false;

    // Use this for initialization
    void Start () {
        coll = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && click == false)
        {
            //send raycast to detect collision
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if collision by raycast and object
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                //displays info about model part
                Laptop_off.SetActive(false);
                Laptop_on.SetActive(true);
                laptopClick.SetActive(true);
            }
        }
    }
}
