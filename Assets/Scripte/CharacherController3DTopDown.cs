using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacherController3DTopDown : MonoBehaviour
{
    
        public float ActualMouvementSpeed;
        public Vector3 MouventDirection;
        public float MoveSpeed;
        public Rigidbody Rigidbody;
        public Camera Camera;
        [Header("Gun")] 
        public bool IsUsingGun;
        public Transform FirePoint;
        public GameObject Bullet;
        public float BulletSpeed;
        public GameObject GunParticule;
        public UnityEvent OnGunFire;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            MouventDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            MoveSpeed = Mathf.Clamp(MouventDirection.magnitude, 0, 1);
            MouventDirection.Normalize();

            Rigidbody.velocity = MouventDirection * MoveSpeed * ActualMouvementSpeed;


            transform.forward =  Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.transform.position.y-transform.position.y))-transform.position ;

            if (Input.GetButtonDown("Fire1")&&IsUsingGun)
            {
                GameObject bullet =Instantiate(Bullet, FirePoint.position, Quaternion.identity);
                bullet.transform.forward = FirePoint.position - transform.position;
                bullet.GetComponent<Rigidbody>().AddForce((FirePoint.position - transform.position).normalized*BulletSpeed,ForceMode.Impulse);
                if (GunParticule!=null)Instantiate(GunParticule, FirePoint.position, transform.rotation);
                OnGunFire.Invoke();
            }
        }
    
}
