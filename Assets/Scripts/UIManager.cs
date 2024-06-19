using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _LivesImage;
    // private int CurrentPlayerLives = 3;  

    [SerializeField]
    private Sprite[] _liveSprites;
    // Start is called before the first frame update
    void Start()
    {
        // _liveSprites[CurrentPlayerLives = 3]
        _scoreText.text = "Score:" + 0;
    }
    public void UpdateScore(int playerScore)
    {        
        _scoreText.text = "Score: " + playerScore.ToString();
    }
    public void UpdateLives(int currentLives)
    {
        _LivesImage.sprite = _liveSprites[currentLives];
        // if (currentLives == 0)
        // {
        //     GameOverSequence();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
