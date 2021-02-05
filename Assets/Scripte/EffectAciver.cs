

using UnityEngine;

public class EffectAciver: MonoBehaviour
{
    public GameObject AttackParticule;

    public void MakeAttack(GameObject target)
    {
        Instantiate(AttackParticule, target.transform.position, Quaternion.identity);
    }
}