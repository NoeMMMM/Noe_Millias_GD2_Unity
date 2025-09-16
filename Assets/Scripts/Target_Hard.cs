
using UnityEngine;

public class Target_Hard : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null) 
        {
            other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_targetValue);
            Destroy(gameObject);
        }
    }
}