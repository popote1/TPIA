using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using UnityEditor;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();
    public Sprite test;
    void Start()
    {
        
        string path ="MarineAnim.png";
        Debug.Log(path);
        Sprites = Resources.LoadAll<Sprite> (path).ToList();
        test = Resources.Load<Sprite>(path);
        //test =Resources.GetBuiltinResource<Sprite>(path);
       
    }

   
    void Update()
    {
        
    }
}
