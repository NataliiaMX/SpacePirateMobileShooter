using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider healthSlider;
    private ScoreKeeper scoreKeeper;
    private float healthBarFill;
    private float initialHealth;

    private void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        initialHealth = healthManager.GetInitialHealth();
    }

    private void Update() 
    {
        UpdateHealthBar();
        UpdateScore();
    }

    private void UpdateHealthBar()
    {
        healthBarFill = healthManager.GetHealth() / initialHealth;
        healthSlider.GetComponent<Slider>().value = healthBarFill; 
    }

    private void UpdateScore()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("0000000");
    }
}
