using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingShape : MonoBehaviour
{
    // ENCAPSULATION

    public float RotationSpeedX { get; set; }

    public float RotationSpeedY { get; set; }

    public float RotationSpeedZ { get; set; }
    
    public Vector3 Scale { get; set; }

    // ABSTRACTION
    public void DoubleSize()
    {
        Vector3 newScale = new Vector3(Scale.x * 2, Scale.y * 2, Scale.z * 2);
        if (HasValidSize(newScale))
        {
            Scale = newScale;
        }
    }

    // ABSTRACTION
    public void HalfSize()
    {
        Vector3 newScale = new Vector3(Scale.x / 2, Scale.y / 2, Scale.z / 2);
        if (HasValidSize(newScale))
        {
            Scale = newScale;
        }
    }

    protected virtual bool HasValidSize(Vector3 newScale)
    {
        bool isValidOnX = newScale.x < 4 && newScale.x > 0.5f;
        bool isValidOnY = newScale.y < 4 && newScale.y > 0.5f;
        bool isValidOnZ = newScale.z < 4 && newScale.z > 0.5f;

        return isValidOnX && isValidOnY && isValidOnZ;
    }

    private void Update()
    {
        transform.Rotate(Vector3.right, RotationSpeedX * Time.deltaTime);
        transform.Rotate(Vector3.up, RotationSpeedY * Time.deltaTime);
        transform.Rotate(Vector3.forward, RotationSpeedZ * Time.deltaTime);
    }
}
