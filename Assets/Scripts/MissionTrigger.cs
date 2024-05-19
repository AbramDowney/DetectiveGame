using System;
using UnityEngine;

public class MissionTrigger : MonoBehaviour
{

    void onCollisionEnter(Collision collisionInfo){
        Debug.Log(collisionInfo.collider.name);
    }
   
}
