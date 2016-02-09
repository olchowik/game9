using UnityEngine;
using System.Collections;
//using System.Collections.Generic;       //Allows us to use Lists. 

    public class GameController : MonoBehaviour
{ 
    //Static instance of GameController which allows it to be accessed by any other script.
    public static GameController instance = null;
    public Creature player;
    [HideInInspector]
    public Timer timer;
    //[HideInInspector] public MapGenerator mapGenerator;

   
    //Awake is always called before any Start functions
    void Awake()
    {
        #region singleton
        //This enforces our singleton pattern, meaning there can only ever be one instance of a GameController.
        //Check if instance already exists if not, set instance to this
        if (instance == null) instance = this;
        //If instance already exists and it's not this: destroy this.
        else if (instance != this) Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene you can keep track of scores etc. between scenes!
        DontDestroyOnLoad(gameObject);
        #endregion
    }
    void Start() {
   //     mapGenerator = gameObject.GetComponent<MapGenerator>();
        timer= gameObject.GetComponent<Timer>();
    }
   
    public void gameOver()
    {
        Destroy(player);
        Destroy(timer);
        Debug.Log(" You died ");
    }
}
