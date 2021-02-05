using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2DTopDown : MonoBehaviour
{
    public float ActualMouvementSpeed;
    public Vector2 MouventDirection;
    public float MoveSpeed;
    public Rigidbody2D Rigidbody2D;
    public Camera Camera;
    public Transform FirePoint;
    public GameObject Bullet;
    public float BulletSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouventDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        MoveSpeed = Mathf.Clamp(MouventDirection.magnitude, 0, 1);
        MouventDirection.Normalize();

        Rigidbody2D.velocity = MouventDirection * MoveSpeed * ActualMouvementSpeed;


        transform.up =  Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10))-transform.position ;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet =Instantiate(Bullet, FirePoint.position, Quaternion.identity);
            bullet.transform.up = FirePoint.position - transform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce((FirePoint.position - transform.position).normalized*BulletSpeed,ForceMode2D.Impulse);
        }
    }
}
    