using UnityEngine;

public class MovablPlayerCreature : Creature
{
    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    [SerializeField]
    private Vector2 jumpForce = new Vector2(0, 150);
    [SerializeField]
    private bool isColiding=false;
    // Update is called once per frame
    public override void die()
    {
        Instantiate(dieParticle, transform.position, transform.rotation);
        GameController.instance.gameOver();
    }

    void Update()
    {
        
        Debug.Log(isColiding);
        isColiding = false;
        
        keepOnScreen();
        // Jump
        if (Input.GetKey("space"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }
        if (Input.GetKeyUp("space"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
    }
    /*
    FixedUpdate should be used instead of Update when dealing with Rigidbody. For example when adding a force to a rigidbody, you have to apply the force every fixed frame inside FixedUpdate instead of every frame inside Update.
    */
    void FixedUpdate() {
        
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }*/
    
    void keepOnScreen() {
        Vector2 new_velocity = GetComponent<Rigidbody2D>().velocity;
        //if player not in the middle of the board move to the middle
        new_velocity.x = (transform.position.x < 0 && !isColiding ) ? 3f :  0f;
        new_velocity.x = (transform.position.x > 0 && !isColiding) ? -3f : 0f;
        GetComponent<Rigidbody2D>().velocity = new_velocity;
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.GetComponent<Rigidbody2D>() != null) isColiding = true;
    }
        void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.GetComponent<Rigidbody2D>() != null) isColiding = true;   
    }


}