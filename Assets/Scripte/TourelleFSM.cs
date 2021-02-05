using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class TourelleFSM : MonoBehaviour
{

    public State TourelleState;
    public CollisionDetector Detector;
    public Transform TourelHead;
    public Color ColorCold;
    public Color ColorHot;
    public float coolFoctor;
    public float heat=0;
    public MeshRenderer CoolingSystem;
    [Header("Gun")] public float Fireinterval;
    public GameObject Bullet;
    public Transform FirePoint;
    public float BulletSpeed;
    public GameObject GunParticules;
    public UnityEvent OnGunFire;
    public float heatparBullet;

    [Range(0, 1) ]public float rotationSmooth=0.2f;
    private Transform _currentTarget;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (TourelleState)
        {
            case State.Searching:
                Searching();
                break;
            case State.fireing:
                Fireing();
                break;
            case State.Cooling:
                Cooling();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        CoolingSystem.material.color = Color.Lerp(ColorCold, ColorHot , heat/100);

        if (_currentTarget != null)
        {
            Debug.DrawLine(TourelHead.position , _currentTarget.position, Color.yellow);
            TourelHead.forward = Vector3.Lerp(TourelHead.forward, _currentTarget.position - TourelHead.position,
                rotationSmooth);
            //TourelHead.rotation = Quaternion.Slerp(TourelHead.rotation,Quaternion.Euler(transform.position-_currentTarget.position), 0.2f );
        }
    }


    private void Searching()
    {
        heat -= Time.deltaTime * coolFoctor;
        if (heat < 0)
        {
            heat = 0;
        }
        GameObject target =Detector.GetFirstInTheList();
        if (target != null)
        {
            _currentTarget=target.transform;
            TourelleState = State.fireing;
        }
    }

    private void Fireing()
    {
        _timer += Time.deltaTime;
        if (_timer > Fireinterval)
        {
            GameObject bullet = Instantiate(Bullet, FirePoint.position, TourelHead.rotation);
            bullet.transform.forward = FirePoint.position - transform.position;
            bullet.GetComponent<Rigidbody>()
                .AddForce((FirePoint.position - transform.position).normalized * BulletSpeed, ForceMode.Impulse);
            if (GunParticules != null) Instantiate(GunParticules, FirePoint.position, TourelHead.rotation);
            OnGunFire.Invoke();
            _timer = 0;
            heat += heatparBullet;
        }

        if (_currentTarget == null)
        {
            TourelleState = State.Searching;
        }
        if (heat>=100)
        {
            TourelleState = State.Cooling;
        }
    }

    private void Cooling()
    {
        heat -= Time.deltaTime * coolFoctor;
        if (heat <= 0)
        {
            TourelleState = State.Searching;
        }
    }
    
    
    public enum State
    {
        Searching, 
        fireing, 
        Cooling
        
    }
}
