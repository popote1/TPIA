using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackManager : MonoBehaviour
{
    public ParticleSystem Moveparticule;
    public Rigidbody Rigidbody;
    public CameraFollowing CameraFollowing;

    public ShakeComponent ShakeComponent;
    public float ShakeIntancity=0.5f;
    public float ShakeFrenquency=0.05f;
    public float ShakeTime =0.4f;
    public AudioClip FireClip;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Rigidbody.velocity.magnitude < 0.5f)
        {
            Moveparticule.Pause();
            Debug.Log("stop Particules");
            CameraFollowing.Offset = 40;
        }
        else
        {
            Moveparticule.Play();
            Debug.Log(" play particules");
            CameraFollowing.Offset = 37;
        }
    }

    public void OnFireWeapon()
    {
        ShakeComponent.Frequency = ShakeFrenquency;
        ShakeComponent.Intencity = ShakeIntancity;
        ShakeComponent.ShakeTime = ShakeTime;
        ShakeComponent.StartShake();
       // CameraFollowing.gameObject.transform.position =
         //   CameraFollowing.gameObject.transform.position + new Vector3(0, 0.5f, 0); 

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = FireClip;
        audioSource.Play();
        Destroy(audioSource, FireClip.length);
    }

}
