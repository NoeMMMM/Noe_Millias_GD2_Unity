using UnityEngine;

public class PlayerCollect : MonoBehaviour 

{
     [SerializeField] private ScoreDatas _ScoreDatas;

     public void UpdateScore(int value)
     {
         _ScoreDatas.scoreValue += Mathf.Clamp(_ScoreDatas.scoreValue + value, 0, _ScoreDatas.scoreValue + value);
     }
}

