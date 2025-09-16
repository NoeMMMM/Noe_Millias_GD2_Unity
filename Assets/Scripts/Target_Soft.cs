using UnityEngine;

public class Target_Soft : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            Destroy(gameObject);
        }

    }
}