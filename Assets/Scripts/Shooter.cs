using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLifetime;
    [SerializeField] private float firingRate = .2f;
    [SerializeField] private bool useAi;
    private Coroutine firingCoroutine;
    private AudioPlayer audioPlayer;
    [HideInInspector] public bool isFiring;

    private void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start() 
    {
        if(useAi)
        {
            isFiring = true;
            projectileSpeed = projectileSpeed * -1f;
        }
    }

    private void Update() 
    {
        Fire();
    }

    private void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while(isFiring)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(projectileInstance, projectileLifetime);
            if(!useAi)
            {
              audioPlayer.PlayShootSFX();  
            }
            yield return new WaitForSeconds(firingRate);
        }
    }
}
