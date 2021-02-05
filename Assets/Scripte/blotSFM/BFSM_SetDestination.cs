using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BFSM_SetDestination : MonoBehaviour
{
    public enum BFSM_State
    {
        IsPatroling,
        IsFolowingPlayer
    }
    public Vector3 BFSM_PickTarget(List<Vector3> pos)
    {
        return pos[Random.Range(0, pos.Count)];
    }

    public void BFSM_MoveToTarget(NavMeshAgent navMeshAgent , Vector3 Destination)
    {
        navMeshAgent.SetDestination(Destination);
    }

    public List<Vector3> BFSM_FindPatrolTargets()
    {
        List<Vector3> pos = new List<Vector3>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Destination");
        foreach (GameObject obj in objects)
        {
            pos.Add(obj.transform.position);
        }
        return pos;
    }

    public bool BFSM_IsOnTarget(float contactDisctance, Vector3 curentTarget)
    {
        if (Vector3.Distance(transform.position, curentTarget) < contactDisctance) return true;
        return false;
    }

    public NavMeshAgent BFSM_GetNavMeshAgent()
    {
        return GetComponent<NavMeshAgent>();
    }

    public void DebugMessage(string stong)
    {
        Debug.Log(stong);
    }

   
}
