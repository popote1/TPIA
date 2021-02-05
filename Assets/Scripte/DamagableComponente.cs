using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagableComponente : MonoBehaviour
{
    public int HP = 2;
    public GameObject Particules;
    public IndividualSondManager soundManager;
    public UnityEvent OnDeath;
    

    public void TakeDamage()
    {
        HP--;
        if (HP <= 0)
        {
            
            GameObject obj =Instantiate(Particules, transform.position, transform.rotation);
            soundManager.PlaySound(3,obj);
            Destroy(gameObject);
        }
    }
}
