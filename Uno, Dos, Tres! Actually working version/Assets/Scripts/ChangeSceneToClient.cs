using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneToClient : MonoBehaviour
{
    [SerializeField] int sceneID;

    public GameObject popUpBox;
    public Button startMissionButton;
    public GameObject spawnEnemy;
    public AudioSource Notification;
    BoxCollider2D coll;

    //popUpBox.SetActive(false);
    //public Animator animator;
    // public TMPro.TextMeshProUGUI popUpText;

    void OnTriggerEnter2D(Collider2D coll)
    {
        //print("TRIGGERERE");
        //SceneManager.LoadScene(sceneID);
        if(coll.gameObject.tag == "Player"){
            popUpBox.SetActive(true);
            Notification.Play();
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        //print("TRIGGERERE");
        //SceneManager.LoadScene(sceneID);
        
        popUpBox.SetActive(false);
    }

    void Start()
    {
        popUpBox.SetActive(false);
        spawnEnemy.SetActive(false);
        startMissionButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        spawnEnemy.SetActive(true);
        popUpBox.SetActive(false);
        Destroy(gameObject);
    }

    private void Awake(){

        coll = GetComponent<BoxCollider2D>();


    }

    // public void PopUp(string text)
    // {
    //     popUpBox.SetActive(true);
    //     // popUpText.text = text;
    //     //animator.SetTrigger("pop");
    // }

}
