using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteAnimator : MonoBehaviour
{
    public SOAnimationHolder AnimHolder;
    public SpriteRenderer SpriteRenderer;
    public Oriantation16 oriantation16;
    public Action ActionA;
     public float Frequense;
    public enum Oriantation16
    {
       O000,o225,o450,o675,
       o900,o1125,o1350,o1575,
       o1800,o2025,o2250,p2475,
       o2700,o2925,o3150,o3375
    }

    private List<Sprite>[,] _annimation = new List<Sprite>[12,3];
    private List<Sprite> _curentAnimation;
    private float _timer;
    private int _spriteIndex;

    public enum Action
    {
        walk, fire , wait
    }
    
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        GetAnnimations();
        SetAnimation();
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > Frequense)
        {
            _spriteIndex++;
            if (_spriteIndex >= _curentAnimation.Count) _spriteIndex = 0;
            SpriteRenderer.sprite = _curentAnimation[_spriteIndex];
            _timer = 0;
        }
    }

    public void GetAnnimations()
    {
        _annimation[0, 0] = AnimHolder.Walk000;
        _annimation[1, 0] = AnimHolder.Walk225;
        _annimation[2, 0] = AnimHolder.Walk450;
        _annimation[3, 0] = AnimHolder.Walk675;
        _annimation[4, 0] = AnimHolder.Walk900;
        _annimation[5, 0] = AnimHolder.Walk1125;
        _annimation[6, 0] = AnimHolder.Walk1350;
        _annimation[7, 0] = AnimHolder.Walk1575; 
        _annimation[8, 0] = AnimHolder.Walk1800;
        
        _annimation[0, 1] = AnimHolder.fire000;
        _annimation[1, 1] = AnimHolder.fire225;
        _annimation[2, 1] = AnimHolder.fire450;
        _annimation[3, 1] = AnimHolder.fire675;
        _annimation[4, 1] = AnimHolder.fire900;
        _annimation[5, 1] = AnimHolder.fire1125;
        _annimation[6, 1] = AnimHolder.fire1350;
        _annimation[7, 1] = AnimHolder.fire1575;
        _annimation[8, 1] = AnimHolder.fire1800;
    }
    [ContextMenu("SetAnimation")]
    public void SetAnimation()
    {
        int oriantationIndex;
        int ActionIndex;
        
        switch (oriantation16)
        {
            case Oriantation16.O000:
                oriantationIndex = 0;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o225:
                oriantationIndex = 1;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o450:
                oriantationIndex = 2;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o675:
                oriantationIndex = 3;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o900:
                oriantationIndex = 4;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o1125:
                oriantationIndex = 5;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o1350:
                oriantationIndex = 6;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o1575:
                oriantationIndex = 7;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o1800:
                oriantationIndex = 8;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o2025:
                oriantationIndex = 7;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o2250:
                oriantationIndex = 6;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.p2475:
                oriantationIndex = 5;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o2700:
                oriantationIndex = 4;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o2925:
                oriantationIndex = 3;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o3150:
                oriantationIndex = 2;
                SpriteRenderer.flipX = false;
                break;
            case Oriantation16.o3375:
                oriantationIndex = 1;
                SpriteRenderer.flipX = false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        switch (ActionA)
        {
            case Action.walk:
                ActionIndex = 0;
                break;
            case Action.fire:
                ActionIndex = 2;
                break;
            case Action.wait:
                ActionIndex = 3;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        _curentAnimation = _annimation[oriantationIndex, ActionIndex];
    }
}
