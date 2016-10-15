using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

    public bool enemyCollided;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemyCollided = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemyCollided = false;
        }

    }
}
