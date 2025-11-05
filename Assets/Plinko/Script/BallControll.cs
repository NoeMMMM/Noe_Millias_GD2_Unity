using UnityEngine;

public class BallControll : MonoBehaviour
{
    public float moveSpeed = 5;
    public float limiteRight = 8.25f;
    public float limiteLeft = -8.25f;
    public float resetHeight = 6f;
    public GameLogic gameLogic;
    
    bool canMove = true;
    bool ballDropped = false;

    void Update()
    {
        if (canMove == true)
        {
            Vector3 moveOFFset = Vector3.zero;
            moveOFFset.x = Input.GetAxis("Horizontal");
            moveOFFset.x = moveOFFset.x * moveSpeed * Time.deltaTime;
            Vector3 newposition = transform.position += moveOFFset;
            
            if (newposition.x > limiteRight)
            {
                newposition.x = limiteRight;
            }

            if (newposition.x < limiteLeft)
            {
                newposition.x = limiteLeft;
            }    
            transform.position = newposition;
            
            if (Input.GetButtonDown("Jump") && !ballDropped)
            {
                DropBall();
            }
        }
    }

    void DropBall()
    {
        canMove = false;
        ballDropped = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(Random.Range(-1f, 1f), 0, 0, ForceMode.Impulse);
        
        if (gameLogic != null)
        {
            gameLogic.UseBall();
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
            ResetToStart();
        }
    }

    public void ResetToStart()
    {
        canMove = true;
        ballDropped = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = new Vector3(0, resetHeight, 0);
        transform.rotation = Quaternion.identity;
    }
}
