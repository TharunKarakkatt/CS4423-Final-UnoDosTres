using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popup_InfoControl : MonoBehaviour
{
    public GameObject popUpBox_Info;
    public AudioSource Notification;
    BoxCollider2D coll;

    //popUpBox_Info.SetActive(false);
    //public Animator animator;
    // public TMPro.TextMeshProUGUI popUpText;

    void OnTriggerEnter2D(Collider2D coll)
    {
        //print("TRIGGERERE");
        //SceneManager.LoadScene(sceneID);
        if(coll.gameObject.tag == "Player"){
            popUpBox_Info.SetActive(true);
            Notification.Play();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        //print("TRIGGERERE");
        //SceneManager.LoadScene(sceneID);
        
        popUpBox_Info.SetActive(false);
        Destroy(gameObject);

    }

    void Start()
    {
        popUpBox_Info.SetActive(false);
    }

    private void Awake(){

        coll = GetComponent<BoxCollider2D>();
    }

    // public void PopUp(string text)
    // {
    //     popUpBox_Info.SetActive(true);
    //     // popUpText.text = text;
    //     //animator.SetTrigger("pop");
    // }

}
