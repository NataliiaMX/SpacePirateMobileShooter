using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip shootingSFX;
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] [Range(0, 1)] private float shootingVolume = 0.5f;
    [SerializeField] [Range(0, 1)] private float damageVolume = 0.5f;

    public void PlayShootSFX()
    {
        PlaySFX(shootingSFX, shootingVolume);
    }

    public void PlayDamageSfx()
    {
        PlaySFX(damageSFX, damageVolume);
    }

    private void PlaySFX(AudioClip audioClip, float volume)
    {
        if(audioClip != null)
        {
          AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);  
        }
    }
}
