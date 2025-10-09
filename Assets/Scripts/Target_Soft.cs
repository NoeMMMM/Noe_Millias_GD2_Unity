using System;
using System.Collections;
using UnityEngine;

public class Target_Soft : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private float _shadowDuration = 3f;
    [SerializeField] private float _particuleffect;
    //private float _shadowTimer = 0f;
    //private bool _isInShadow = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_targetValue);
            //Destroy(gameObject);
            //TODO : hide target
            ToggleVisibility(false);
            //TODO : start timer
            //_isInShadow = true;
            //Instantiate(_particuleffect, transform.position, Quaternion.identity);
            StartCoroutine(ShadowTimerControl());
        }

    }

    private void ToggleVisibility(bool newVisibility)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }
    
    //TODO : Timer by deltatime
    /*private void Update()
    {
        if (_isInShadow)
        
        _shadowTimer += Time.deltaTime;
        if (_shadowTimer >= _shadowDuration)
        {
           //TODO : Show target
           ToggleVisibility(true);
           //TODO : Stop timer
           _shadowTimer = 0f;
           _isInShadow = false;
        }
    }*/


    //TODO : timer by coroutime
    private IEnumerator ShadowTimerControl()
    {
        //yield return new WaitForEndOfFrame()
        yield return new WaitForSeconds(_shadowDuration);
        ToggleVisibility(true);
        
    }
}