using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    
    private void OnEnable()
    {
        PlayerCollect.OnTargetCollected += UpdateScore;
    }
    
    private void OnDisable()
    {
        PlayerCollect.OnTargetCollected -= UpdateScore;
    }

    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int newScore) 
    {
       _scoreText.text = $"Score : {newScore.ToString()}";
       Debug.Log(_scoreText.text);
       //_scoreText.text = "Score : " + newScore.ToString();
    }
}
