using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stepSounds;

    [SerializeField]
    public AudioSource source;

    public float delay = .05f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            Footstep();
            timer -= delay;
        }
    }

    public void Footstep()
    {
        var clip = stepSounds[Random.Range(0, stepSounds.Length)]; //A random sound is loaded and the played.
        source.PlayOneShot(clip);
    }
}
