using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameover : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    private void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() 
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString();
    }
}
