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

    //popUpBox.SetActive(false);
    //public Animator animator;
    // public TMPro.TextMeshProUGUI popUpText;

    void OnTriggerEnter2D(Collider2D other)
    {
        //print("TRIGGERERE");
        //SceneManager.LoadScene(sceneID);
        popUpBox.SetActive(true);
        Notification.Play();
    }

    void OnTriggerExit2D(Collider2D other)
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
    }

    // public void PopUp(string text)
    // {
    //     popUpBox.SetActive(true);
    //     // popUpText.text = text;
    //     //animator.SetTrigger("pop");
    // }

}
