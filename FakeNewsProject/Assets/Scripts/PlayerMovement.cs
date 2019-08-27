using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Collider2D col;
    public Collider col3D1;
    public Collider col3D2;
    public Collider col3D3;
    public Collider col3D4;

    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    public GameObject TownFolk;
    public GameObject Dialogue;
    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public GameObject Dialogue3;
    public GameObject Next;
    public bool info = false;
    public int clickCheck;

    private int convoCount = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (convoCount == 4)
        {
            Next.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && info == false)
        {
            //send raycast to detect collision
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //if collision by raycast and object
            if (col3D1.Raycast(ray, out hit, 1000.0f))
            {
                Dialogue.SetActive(true);
                info = true;
                convoCount++;
            }

            if (col3D2.Raycast(ray, out hit, 1000.0f))
            {
                Dialogue1.SetActive(true);
                info = true;
                convoCount++;
            }

            if (col3D3.Raycast(ray, out hit, 1000.0f))
            {
                Dialogue2.SetActive(true);
                info = true;
                convoCount++;
            }

            if (col3D4.Raycast(ray, out hit, 1000.0f))
            {
                Dialogue3.SetActive(true);
                info = true;
                convoCount++;
            }
        }
        else
            if (Input.GetMouseButtonDown(0) && info == true)
            {
                //send raycast to detect collision
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                    if (col3D1.Raycast(ray, out hit, 1000.0f))
                    {
                        Dialogue.SetActive(false);
                        info = false;
                    }

                    if (col3D2.Raycast(ray, out hit, 1000.0f))
                    {
                        Dialogue1.SetActive(false);
                        info = false;
                    }
                    if (col3D3.Raycast(ray, out hit, 1000.0f))
                    {
                        Dialogue2.SetActive(false);
                        info = false;
                    }

                    if (col3D4.Raycast(ray, out hit, 1000.0f))
                    {
                        Dialogue3.SetActive(false);
                        info = false;
                    }
        }
    }

    //    if (Input.GetMouseButtonDown(0) && info == false && clickCheck == 1)
    //    {
    //        //send raycast to detect collision
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        //if collision by raycast and object
    //        if (col3D.Raycast(ray, out hit, 1000.0f))
    //        {
    //            Dialogue1.SetActive(true);
    //            info = true;
    //            clickCheck++;
    //        }
    //    }
    //    else
    //if (Input.GetMouseButtonDown(0) && info == true && clickCheck == 1)
    //    {
    //        Dialogue1.SetActive(false);
    //        info = false;
    //    }
    //}

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (col.gameObject.name == "Char1")
    //    {
    //        Debug.Log("colliding");
    //        Dialogue.SetActive(true);
    //    }
    //}

    //public void OnCollisionEnter2D(Collider2D collision)
    //{
    //    if (col.gameObject.name == "Interact")
    //    {
    //        Debug.Log("colliding");
    //        colliding = true;
    //        Dialogue.SetActive(true);
    //    }
    //}


    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

    }
}
