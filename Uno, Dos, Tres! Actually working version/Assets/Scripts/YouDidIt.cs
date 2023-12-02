using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDidIt : MonoBehaviour
{
    public void PressReturn(){
        SceneManager.LoadScene(0);
    }
}
