using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseController : MonoBehaviour
{

    [SerializeField] public GameObject cheese;
    [SerializeField] public PlayerController _player;
    [SerializeField] public int cheeseMeterCounter;
    [SerializeField] public AudioSource Eating;

    //public TMPro.TextMeshProUGUI textfield;
    BoxCollider2D coll;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player"){
            cheese.SetActive(false);
            Eating.Play();
            cheeseMeterCounter = cheeseMeterCounter + 1;
            //textfield.text = cheeseMeterCounter.ToString();
            _player.CheeseMeter = cheeseMeterCounter;  
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake(){

        coll = GetComponent<BoxCollider2D>();
    }
}
