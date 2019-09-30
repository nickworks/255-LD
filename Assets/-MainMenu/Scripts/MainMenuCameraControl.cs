using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraControl : MonoBehaviour
{
    public bool lookAtLevelDetails = false;

    [Tooltip("A reference to another camera in the scene. When lookAtLevelDetails is true, this camera will ease towards the other camera's position and rotation.")]
    public Camera cameraDetails;
    [Tooltip("How long it should take the camera to ease towards its target.")]
    public float easeTime = 1;
    [Tooltip("A curve for how the camera should handle its easing.")]
    public AnimationCurve cameraEasing;

    Quaternion startRotation;
    Quaternion endRotation;
    Vector3 startPosition;
    Vector3 endPosition;

    float time;

    void Start() {
        startPosition = transform.position;
        startRotation = transform.rotation;
        endPosition = cameraDetails ? cameraDetails.transform.position : startPosition;
        endRotation = cameraDetails ? cameraDetails.transform.rotation : startRotation;
    }

    void Update() {
        if (lookAtLevelDetails){
            if (time < easeTime) time += Time.deltaTime;
        } else {
            if (time > 0) time -= Time.deltaTime;
        }

        float percent = time / easeTime;
        percent = cameraEasing.Evaluate(percent);

        transform.position = Vector3.Lerp(startPosition, endPosition, percent);
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, percent);
    }
}
