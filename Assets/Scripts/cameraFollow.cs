using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float Yoffset = 1f;
    public Transform target;
    
    
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + Yoffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}