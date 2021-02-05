using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAnimationHoleder" , menuName = "SO/Animarition Holder")]
public class SOAnimationHolder : ScriptableObject{
    [Header("walk anim")]
    public List<Sprite> Walk000 = new List<Sprite>(9);
    public List<Sprite> Walk225 = new List<Sprite>(9);
    public List<Sprite> Walk450 = new List<Sprite>(9);
    public List<Sprite> Walk675 = new List<Sprite>(9);
    public List<Sprite> Walk900 = new List<Sprite>(9);
    public List<Sprite> Walk1125 = new List<Sprite>(9);
    public List<Sprite> Walk1350 = new List<Sprite>(9);
    public List<Sprite> Walk1575 = new List<Sprite>(9);
    public List<Sprite> Walk1800 = new List<Sprite>(9);
    
    [Header("fire Anim")]
    public List<Sprite> fire000 = new List<Sprite>(4);
    public List<Sprite> fire225 = new List<Sprite>(4);
    public List<Sprite> fire450 = new List<Sprite>(4);
    public List<Sprite> fire675 = new List<Sprite>(4);
    public List<Sprite> fire900 = new List<Sprite>(4);
    public List<Sprite> fire1125 = new List<Sprite>(4);
    public List<Sprite> fire1350 = new List<Sprite>(4);
    public List<Sprite> fire1575 = new List<Sprite>(4);
    public List<Sprite> fire1800 = new List<Sprite>(4);
    
    
}
