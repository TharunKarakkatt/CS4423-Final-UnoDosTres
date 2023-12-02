using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PressPlay(){
        SceneManager.LoadScene(1);
    }

    public void PressQuit(){
        Application.Quit();
    }
}
