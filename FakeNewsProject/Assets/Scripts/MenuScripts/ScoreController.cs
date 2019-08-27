//https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/counting-collectables-and-displaying-score
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScoreController : MonoBehaviour
{
   // public Collider coll;
    public static int followerCount;
    public static int paraCount;

    public Text paraCountText;
    public Text followCountText;
    public Text thoughtText;

    public int randParaInt;
    public int randFollowInt;
    public int ObjInteraction = 0;

    public Button thoughts;
    public Button Accept;
    public Button Decline;

    public Slider paranoia;
    public Slider followers;

    public Text thoughtTextLaptop;
    public Text paraTextLaptop;
    public Text followTextLaptop;
    public Text thoughtTextPhone;

    public GameObject current;
    public GameObject LaptopUI;
    public GameObject PhoneUI;
    public GameObject ClipboardUI;

    public GameObject paraCount1;
    public GameObject followerCount1;


    public void Awake()
    {
        DontDestroyOnLoad(followerCount1);
        DontDestroyOnLoad(paraCount1);
        //paraCount = PlayerPrefs.GetInt("paraCount");
        //followerCount = PlayerPrefs.GetInt("followerCount");
    }

    // Start is called before the first frame update
    void Start()
    {
     //   coll = GetComponent<Collider>();

        //Initialize count to zero.
        //paraCount = 1;
        //followerCount = 30;

        //Initialze winText to a blank string since we haven't won yet at beginning.
        paraCountText.text = "Paranoia: " + paraCount;
        followCountText.text = "Followers: " + followerCount;

    }

    public void saveScore()
    {
        PlayerPrefs.SetInt("paraCount", paraCount);
        PlayerPrefs.SetInt("followCount", followerCount);
    }


    public void onClickPara() {
        randParaInt = Random.Range(1, 5);
        paraCount = paraCount + randParaInt;
        Debug.Log("clicked" + paraCount);
        paraCountText.text = "Paranoia: " + paraCount.ToString();
        ObjInteraction += 1;
        //set object false so cant interact again
        LaptopUI.SetActive(false);
        PhoneUI.SetActive(false);
        ClipboardUI.SetActive(false);
        current.SetActive(false);
        //Update the currently displayed count by calling the SetCountText function.
    }

    public void onClickFollow() {
        randFollowInt = Random.Range(1, 10);
        followerCount = followerCount + randFollowInt;
        Debug.Log("clicked" + paraCount);
        followCountText.text = "Followers: " + followerCount.ToString();
        ObjInteraction += 1;
        //set object false so cant interact again
        LaptopUI.SetActive(false);
        PhoneUI.SetActive(false);
        ClipboardUI.SetActive(false);
        current.SetActive(false);
    }

    public void changeText(string words)
    {
        //if (ObjInteraction == 3)
        //{
        //    //dim scene to show change
        //    thoughtTextLaptop.text = "blah blah blah";
        //    paraTextLaptop.text = "blah blah blah";
        //    followTextLaptop.text = "blah blah blah";
        //    thoughtTextPhone.text = "blah blah blah";
        //}

        thoughtText.text = words;
    }

    public void changeButton()
    {
        thoughts.gameObject.SetActive(false);
        Accept.gameObject.SetActive(true);
        Decline.gameObject.SetActive(true);
        paranoia.value = paraCount;
        followers.value = followerCount;
    }

    public void changeButtonBack()
    {
        thoughts.gameObject.SetActive(false);
        Decline.gameObject.SetActive(true);
    }


    //public void changeRound()
    //{
    //    ObjInteraction += 1;
    //}





    ////This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
    //void SetCountText()
    //{
    //    //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
    //    paraCountText.text = "Paranoia: " + paraCount.ToString();
    //    followCountText.text = "Followers:  " + followerCount.ToString();

    //    ////Check if we've collected all 12 pickups. If we have...
    //    //if (count >= 12)
    //    //    //... then set the text property of our winText object to "You win!"
    //    //    winText.text = "You win!";
    //}


}
