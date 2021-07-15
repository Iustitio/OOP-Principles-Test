using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingShape : MonoBehaviour
{
    // ENCAPSULATION

    public float RotationSpeedX
    {
        get => _rotationSpeedX;
        set
        {
            _rotationSpeedX = value;
            settingsPanel.UpdateUi();
        }
    }

    public float RotationSpeedY
    {
        get => _rotationSpeedY;
        set
        {
            _rotationSpeedY = value;
            settingsPanel.UpdateUi();
        }
    }

    public float RotationSpeedZ
    {
        get => _rotationSpeedZ;
        set
        {
            _rotationSpeedZ = value;
            settingsPanel.UpdateUi();
        }
    }

    public Vector3 Scale
    {
        get => transform.localScale;
        set
        {
            transform.localScale = value;
            settingsPanel.UpdateUi();
        }
    }

    [SerializeField] private SettingsPanel settingsPanel;
    private float _rotationSpeedX;
    private float _rotationSpeedY;
    private float _rotationSpeedZ;

    // ABSTRACTION
    public void IncreaseSize()
    {
        Vector3 newScale = new Vector3(Scale.x * 1.1f, Scale.y * 1.1f, Scale.z * 1.1f);
        if (HasValidSize(newScale))
        {
            Scale = newScale;
        }
    }

    // ABSTRACTION
    public void DecreaseSize()
    {
        Vector3 newScale = new Vector3(Scale.x * 0.9f, Scale.y * 0.9f, Scale.z * 0.9f);
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