using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject previewBall;
    public float moveSpeed = 5;
    public float limiteRight = 8.25f;
    public float limiteLeft = -8.25f;
    public float resetHeight = 6f;
    public GameLogic gameLogic;
    
    Vector3 currentPosition;

    void Start()
    {
        currentPosition = new Vector3(0, resetHeight, 0);
        transform.position = currentPosition;
        
        if (previewBall != null)
        {
            previewBall.transform.position = currentPosition;
        }
    }

    void Update()
    {
        if (gameLogic != null && gameLogic.ballsRemaining > 0)
        {
            Vector3 moveOffset = Vector3.zero;
            moveOffset.x = Input.GetAxis("Horizontal");
            moveOffset.x = moveOffset.x * moveSpeed * Time.deltaTime;
            currentPosition += moveOffset;
            
            if (currentPosition.x > limiteRight)
            {
                currentPosition.x = limiteRight;
            }

            if (currentPosition.x < limiteLeft)
            {
                currentPosition.x = limiteLeft;
            }
            
            transform.position = currentPosition;
            
            if (previewBall != null)
            {
                previewBall.transform.position = currentPosition;
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                SpawnAndDropBall();
            }
        }
    }

    void SpawnAndDropBall()
    {
        if (gameLogic == null || gameLogic.ballsRemaining <= 0) return;
        
        GameObject newBall = Instantiate(ballPrefab, currentPosition, Quaternion.identity);
        Ball ballScript = newBall.GetComponent<Ball>();
        
        if (ballScript != null)
        {
            ballScript.gameLogic = gameLogic;
            ballScript.DropBall();
        }
        
        gameLogic.UseBall();
    }

    public void ResetPosition()
    {
        currentPosition = new Vector3(0, resetHeight, 0);
        transform.position = currentPosition;
        
        if (previewBall != null)
        {
            previewBall.transform.position = currentPosition;
        }
    }

    public void SetPreviewBallActive(bool active)
    {
        if (previewBall != null)
        {
            previewBall.SetActive(active);
        }
    }
}
