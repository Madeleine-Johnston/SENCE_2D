using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    public Collider active;
    public GameObject glitch;
    // Start is called before the first frame update
    void Start()
    {
        active = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //send raycast to detect collision
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if collision by raycast and object
            if (active.Raycast(ray, out hit, 1000.0f))
            {
                glitch.SetActive(true);
            }
        }
    }
}
