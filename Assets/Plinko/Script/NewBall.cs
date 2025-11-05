using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameLogic gameLogic;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public void DropBall()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(Random.Range(-5f, 5f), 0, 0, ForceMode.Impulse);
        }
        
        if (gameLogic != null)
        {
            gameLogic.BallDropped();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            if (gameLogic != null)
            {
                gameLogic.BallFinished();
            }
            Destroy(gameObject);
        }
    }
}