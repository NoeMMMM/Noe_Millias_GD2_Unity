using UnityEngine;

public class Target_Soft : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_targetValue);
            Destroy(gameObject);
        }

    }
}