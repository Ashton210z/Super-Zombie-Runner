using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    public float jumpSpeed = 240f;
    public float forwardSpeed = 20;
    private Rigidbody2D body2d;
    private InputState inputState;
    private EnemyCollision enemyCollision;
	// Use this for initialization

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        inputState = GetComponent<InputState>();
        enemyCollision = GetComponent<EnemyCollision>();
    }

    void Update () {
        float velx = body2d.velocity.x;
        
        //Check if user is standing (Which is defined by not moving up and down on Y Axis)
        if (inputState.standing) 
        {
            //Check if actionButton (Anykey) is pressed. If player is less than center of screen, jump forward. if not, jump up.
            if (inputState.actionButton)
            {
                body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed);  //? and : statement; After ?, true, after :, false. 
            }

        }

        //Check if user is travelling negative velocity. If not pressed against an enemy, set the velocity to 0. (Lets obstacles pass underneath the player)
        if (velx < 0)
        {
            if (enemyCollision.enemyCollided == false)
            {
                body2d.velocity = new Vector2(forwardSpeed, body2d.velocity.y);
            }
        }
    }
}
