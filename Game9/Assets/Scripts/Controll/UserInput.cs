using UnityEngine;
using System.Collections;
/// <summary>
/// Work with this to add mobile controllers etc.
/// </summary>
public class UserInput : MonoBehaviour {

    //PlayerCreature player;
	// Use this for initialization
	void Start () {
      //  PlayerCreature player = GameController.instance.player;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump")) GameController.instance.player.moveUp();
        if (Input.GetButtonUp("Jump")) GameController.instance.player.fallDown();
    }
}
