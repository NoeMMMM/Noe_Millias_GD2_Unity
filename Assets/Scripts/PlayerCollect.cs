using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollect : MonoBehaviour 

{
     [SerializeField] private ScoreDatas _ScoreDatas;
     [SerializeField] private UIController _uiController;

     //Définition de l'action (event dispatcher), avec l'input <> ici en int
     public static Action<int> OnTargetCollected;
     public void UpdateScore(int value)
     {
         _ScoreDatas.scoreValue = Mathf.Clamp(_ScoreDatas.scoreValue + value, 0, _ScoreDatas.scoreValue + value);
         //_uiController.UpdateScore(_ScoreDatas.scoreValue); 
         //Call event dispatcher, en c# on invoke avec l'input entre parenthese 
         OnTargetCollected?.Invoke(_ScoreDatas.scoreValue);
     }
}

