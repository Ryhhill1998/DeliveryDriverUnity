using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    // the camera's position should be the same as the car's at all times 

    // Update is called once per frame
    void LateUpdate()
    {
        const int cameraOffset = -10;
        transform.position = objectToFollow.transform.position + new Vector3(0, 0, cameraOffset);
    }
}
