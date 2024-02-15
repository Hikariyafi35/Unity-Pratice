using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHit : MonoBehaviour
{
   private void OnCollisionEnter(Collision other) {
    Debug.Log("You Hit Building!!!");
   }
}
