using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {

    [Header("Inputs")]
    public bool actionButton;
    public bool swipeUp = false;
    public bool swipeDown = false;
    [Header("Position")]
    public float absVelX = 0f;
    public float absVelY = 0f;
    [Header("Standing")]
    public bool standing;
    public float standingThreshold = 1;

    private Vector2 firstPressPos;
    private Vector2 currentSwipe;
    

    private Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Define action button
        actionButton = Input.GetButtonUp("Fire1");

        //MouseSwipes code
        if (Input.GetMouseButtonDown(0))
            {
                firstPressPos = Input.mousePosition;
            }
        if (Input.GetMouseButtonUp(0))
            {
                currentSwipe = (Vector2)Input.mousePosition - firstPressPos;
                Debug.Log(currentSwipe + ", " + currentSwipe.normalized);
            }
        swipeUp = (currentSwipe.y > firstPressPos.y) ;
        swipeDown = (currentSwipe.y < firstPressPos.y);

    }
   

    void FixedUpdate()
    {
        absVelX = System.Math.Abs(body2d.velocity.x);
        absVelY = System.Math.Abs(body2d.velocity.y);

        standing = absVelY <= standingThreshold; // Not moving on the Y axis, standing on something (Would rather use colliders in the future)
    }
}
