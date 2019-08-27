using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour
{

    public GameObject note;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            //send raycast to detect collision
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if collision by raycast and object
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.transform.gameObject.note);
                {
                    Debug.Log("hit link 1");
                    panel.SetActive(true);
                }

            }
        }
    }
}
