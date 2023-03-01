using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private bool isPlayer;
    [SerializeField] private int scoreIncrease;
    private ScoreKeeper scoreKeeper;
    private AudioPlayer audioPlayer;
    private CameraShaker cameraShaker;
    private float initialHealth;

    private void Awake()
    {
        cameraShaker = Camera.main.GetComponent<CameraShaker>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        initialHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitVFX();
            audioPlayer.PlayDamageSfx();
            // damageDealer.Hit();
            if (isPlayer)
            {
                cameraShaker.Play();
            }
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            scoreKeeper.IncreaseScore(scoreIncrease);
            if(isPlayer)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void PlayHitVFX()
    {
        if (hitVFX != null)
        {
            ParticleSystem instance = Instantiate(hitVFX, transform.position, Quaternion.identity);
        }
    }

    private void ShakeCamera()
    {
        if(cameraShaker)
        {
            if (isPlayer)
            {
                cameraShaker.Play();
            }
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetInitialHealth()
    {
        return initialHealth;
    }
}
