using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float yMax = 15f;

    [SerializeField] private float yMin = -15f;

    private float _tilt;

    // Update is called once per frame
    void Update()
    {
        var rotation = Input.GetAxis("Mouse Y");
        _tilt = Mathf.Clamp(_tilt + rotation, yMin, yMax);
        transform.localRotation = Quaternion.Euler(_tilt, 0f, 0f);
    }
}
