using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector :MonoBehaviour
{
    public string TagTarget;
    public List<GameObject> DetectedGameObjects = new List<GameObject>();
    public LayerMask DetectLayerMask;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagTarget))
        {
            DetectedGameObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (DetectedGameObjects.Contains(other.gameObject))
        {
            DetectedGameObjects.Remove(other.gameObject);
        }
    }

    public GameObject GetFirstInTheList()
    {
        DetectedGameObjects.RemoveAll(o => o == null);
            GameObject player = DetectedGameObjects.Find(o => o.CompareTag(TagTarget));
         if (player != null)
         {
             RaycastHit hit;
             
             if (Physics.Linecast(transform.position, player.transform.position,out hit,DetectLayerMask))
             {
                 Debug.DrawLine(transform.position, hit.point);
                 if (hit.collider.CompareTag(TagTarget))
                 {
                     return player;
                 }
             }
             return null;
         }
         else
         {
             return null;
         }
    }

    public bool IsInView(GameObject target)
    {
        if (DetectedGameObjects.Contains(target))
        {
            RaycastHit hit;

            if (Physics.Linecast(transform.position, target.transform.position, out hit, DetectLayerMask))
            {
                Debug.DrawLine(transform.position, hit.point);
                if (hit.collider.gameObject == target)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
}
