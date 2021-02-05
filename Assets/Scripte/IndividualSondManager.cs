using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualSondManager : MonoBehaviour
{
    public List<AudioClip> sound;
    public float maxdistance=50;
    private Transform player;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int index)
    {
        if (index >= sound.Count) return;
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound[index];
        
        audioSource.volume = (1f - Mathf.Clamp( Vector3.Distance(player.position, transform.position), 0, maxdistance) /
            maxdistance);
        audioSource.Play();
        Destroy(audioSource, sound[index].length);
    }
    public void PlaySound(int index,GameObject obj)
    {
        if (index >= sound.Count) return;
        AudioSource audioSource = obj.AddComponent<AudioSource>();
        audioSource.clip = sound[index];
       audioSource.volume = (1f - Mathf.Clamp( Vector3.Distance(player.position, transform.position), 0, maxdistance) /
            maxdistance);
        audioSource.Play();
        Destroy(audioSource, sound[index].length);
    }
}
