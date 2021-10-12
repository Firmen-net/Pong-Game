using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float xInitialForce;
    public float yInitialForce;
    private Vector2 trajectoryOrigin;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(50, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-50, -15));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();

        // Mulai game
        RestartGame();
    }
    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rb2d.velocity = Vector2.zero;
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("GoBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
