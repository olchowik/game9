using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Updates GUI, displays time and health
/// </summary>
public class GameUI : MonoBehaviour {
    [SerializeField]
    private Text timeLabel;
    [SerializeField]
    private Text msgLabel;
    [SerializeField]
    private Slider healthSliser;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update ()
    {
        //Update time
        if (GameController.instance.timer!=null)
            timeLabel.text = "Time: " +GameController.instance.timer.TimerValue.ToString();
        //update health
        healthSliser.value = GameController.instance.player.Health;
    }
    public void sayGameOver()
    {
        msgLabel.text = "GAME OVER";
    }
}
