using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime : MonoBehaviour
{
   public Vector3 positon;
   public Quaternion rotation;

   public PointInTime(Vector3 _positon, Quaternion _rotation)
   {
      positon = _positon;
      rotation = _rotation;
   }
}
