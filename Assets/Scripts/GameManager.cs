using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject player;
    public bool gamrOver;

    public GameObject Player {
        get { return player; }
    }
    
    public bool GameOver {
        get { return gamrOver; }
    }


    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(this!= instance){
            Destroy(gameObject);
        }
    }


   
    // Update is called once per frame
    void Update()
    {
        
    }
}
