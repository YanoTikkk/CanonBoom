using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime : MonoBehaviour
{
   public Vector3 positon = Vector3.zero;
   public Quaternion rotation ; // почитать
   
   public PointInTime(Vector3 _positon, Quaternion _rotation)
   {
      positon = _positon;
      rotation = _rotation;
   }
}
