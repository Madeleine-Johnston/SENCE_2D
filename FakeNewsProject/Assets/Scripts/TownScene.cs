using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownScene : MonoBehaviour
{

    public Collider break1;
    public Collider break2;
    public Collider break3;
    public Collider break4;
    public Collider break5;
    public Collider break6;

    public GameObject broken1;
    public GameObject broken2;
    public GameObject broken3;
    public GameObject broken4;
    public GameObject broken5;
    public GameObject broken6;
    public GameObject fire;
    public GameObject speechBubble;
    public GameObject speechBubble2;

    public AudioSource sfx;
    public AudioSource sfx2;
    public AudioClip fireEngine;
    public AudioClip glass;

    public int brokenCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(speech());
        StartCoroutine(speech2());
    }


    IEnumerator speech()
    {
        yield return new WaitForSeconds(1);
        speechBubble.SetActive(true);
    }

    IEnumerator speech2()
    {
        yield return new WaitForSeconds(2);
        speechBubble2.SetActive(true);
    }

    IEnumerator changeScene()
    {
        sfx2.PlayOneShot(fireEngine, 1.0f);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Level9");
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
            if (break1.Raycast(ray, out hit, 1000.0f))
            {
                sfx.PlayOneShot(glass, 1.0f);
                Debug.Log("collision");
                broken1.SetActive(true);
                brokenCount++;
            }

            if (break2.Raycast(ray, out hit, 1000.0f))
            {
                sfx.PlayOneShot(glass, 1.0f);
                broken2.SetActive(true);
                brokenCount++;
            }

            if (break3.Raycast(ray, out hit, 1000.0f))
            {
                sfx.PlayOneShot(glass, 1.0f);
                broken3.SetActive(true);
                brokenCount++;
            }

            if (break4.Raycast(ray, out hit, 1000.0f))
            {
                sfx.PlayOneShot(glass, 1.0f);
                broken4.SetActive(true);
                brokenCount++;
            }

            if (break5.Raycast(ray, out hit, 1000.0f))
            {
                sfx.PlayOneShot(glass, 1.0f);
                broken5.SetActive(true);
                brokenCount++;
            }

            if (break6.Raycast(ray, out hit, 1000.0f))
            {
                sfx.PlayOneShot(glass, 1.0f);
                broken6.SetActive(true);
                brokenCount++;
            }

            if (brokenCount == 6)
            {
                fire.SetActive(true);
                StartCoroutine(changeScene());
            }
        }
    }
}
