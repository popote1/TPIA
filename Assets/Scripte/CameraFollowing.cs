using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
 public Offet OffetAxis;
 public float Offset = -10;
 public Transform Player;
 [Range(0,1)]public float Smothingfactor=0.5f;


 public enum Offet
 {
  OffSetX,OffSetY,OffSetZ
 }
 private void Update()
 {
  if (Player != null)
  {
   switch (OffetAxis)
   {
    case Offet.OffSetX:
     transform.position = Vector3.Lerp(transform.position, new Vector3(Offset,Player.position.y, Player.position.z ), Smothingfactor);
     break;
    case Offet.OffSetY:
     transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x,Offset, Player.position.z ), Smothingfactor);
     break;
    case Offet.OffSetZ:
     transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x, Player.position.y, Offset), Smothingfactor);
     break;
    default:
     throw new ArgumentOutOfRangeException();
   }
   
  }
 }
}
