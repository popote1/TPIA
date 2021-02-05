using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BroodMotherFSM : MonoBehaviour
{

    public GameObject Unite;
    public List<broodMotherTasks> Tasks;
   

    private void Start()
    {
        foreach (var task in Tasks)
        {
            Debug.Log("Set a task");
            int index = Tasks.IndexOf(task);
            task.Unites = new List<GameObject>();
            for (int i = 0; i < task.StartUnite; i++)
            {
                task.Unites.Add(new GameObject());                                        
            }
            SpawnUnit(task);
            GiveTasks(task);
            
        }
    }

    void Update()
    {
        foreach (var task in Tasks)
        {
            if (!CheckGoupNomber(task))
            {for (int i = 0; i < task.Incressbywayve; i++)
                {
                    task.Unites.Add(new GameObject());                                        
                }
                SpawnUnit(task);
                GiveTasks(task); 
            }
        }
    }

    private void SpawnUnit(broodMotherTasks task)
    {
        Debug.Log("spawnation des unites");
        for (int i = 0; i < task.Unites.Count; i++)
        {
            
               
                    int spawnIndex = UnityEngine.Random.Range(0, task.SpawnPoints.Count);
                    Vector3 spawnOffset =
                        new Vector3(UnityEngine.Random.Range(-1, 1), 0, UnityEngine.Random.Range(-1, 1));
                    GameObject newUnit = Instantiate(Unite, task.SpawnPoints[spawnIndex].position + spawnOffset,
                        Quaternion.identity);
                    task.Unites[i]= newUnit;
                
            
        }
    }

    private void GiveTasks(broodMotherTasks tasks)
    {
        foreach (var unite in tasks.Unites)
        {
            unite.GetComponent<ScripteFSM>().ComSetDestination(tasks.targets.ToArray());
        }
    }

    private bool CheckGoupNomber(broodMotherTasks tasks)
    {
        int unitesAlive = 0;
        for (int i = 0; i < tasks.Unites.Count; i++)
        {
            if (tasks.Unites[i] != null)
            {
                unitesAlive++;
            }
        }
        Debug.Log( unitesAlive+" Rest en vie");
        if (unitesAlive < ((float) tasks.StartUnite / 4))
        {
            return false;
        }
        return true;
    }


}
[Serializable]
public class broodMotherTasks
{
    public string Title;
    public int StartUnite;
    public int Incressbywayve;
    public List<GameObject> targets;
    public List<Transform> SpawnPoints;
    public List<GameObject> Unites;
}
