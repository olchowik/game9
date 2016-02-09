using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Game Controller is a SINGLETON that allows component to communicate
/// Trying to keep all inter-component communication via GameController.instance
/// Other way to do game architecture would be to use c#vents or Unity Events/Messaging system.  
/// </summary>

public class GameController : MonoBehaviour
{ 
    //Static instance of GameController which allows it to be accessed by any other script.
    public static GameController instance = null;
    public PlayerCreature player;
    [HideInInspector]
    public Timer timer;//This is how we can acces scripts
    public Canvas gameCanvas; 

   
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

        timer= gameObject.GetComponent<Timer>();
    }
   
    public void gameOver()
    {
        Destroy(player);
        Destroy(timer);
        gameCanvas.GetComponent<GameUI>().sayGameOver();
        Debug.Log(" You died ");
    }
}
