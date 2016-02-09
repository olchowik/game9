using UnityEngine;
/// <summary>
/// This is how player moves around and dies
/// </summary>
public class PlayerCreature : Creature
{
    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    [SerializeField]
    private Vector2 jumpForce = new Vector2(0, 150);
    // Update is called once per frame
    public override void die()
    {
        Instantiate(dieParticle, transform.position, transform.rotation);
        GameController.instance.gameOver();
    }
    public void moveUp()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(jumpForce);
    }
    public void fallDown()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    void Update()
    {

    }
    /*
    FixedUpdate should be used instead of Update when dealing with Rigidbody. For example when adding a force to a rigidbody, you have to apply the force every fixed frame inside FixedUpdate instead of every frame inside Update.
    */
    void FixedUpdate() {
        
    }

}