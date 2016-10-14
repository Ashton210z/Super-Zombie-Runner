using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {

    [Header("Header 1")]
    public bool actionButton;
    public float absVelX = 0f;
    public float absVelY = 0f;
    [Header("Header 2")]
    public bool standing;
    public float standingThreshold = 1;
   
    
    

    private Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        actionButton = Input.anyKeyDown;
    }

    void FixedUpdate()
    {
        absVelX = System.Math.Abs(body2d.velocity.x);
        absVelY = System.Math.Abs(body2d.velocity.y);

        standing = absVelY <= standingThreshold; // Not moving on the Y axis, standing on something (Would rather use colliders in the future)
    }
}
