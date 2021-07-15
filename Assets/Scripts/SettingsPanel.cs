using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private RotatingShape target;

    [SerializeField] private TMP_InputField rotXInputField;
    [SerializeField] private TMP_InputField rotYInputField;
    [SerializeField] private TMP_InputField rotZInputField;

    [SerializeField] private Button addSizeButton;
    [SerializeField] private Button minusSizeButton;

    [SerializeField] private TextMeshProUGUI sizeText;

    // Start is called before the first frame update
    void Start()
    {
        addSizeButton.onClick.AddListener(() => target.IncreaseSize());
        minusSizeButton.onClick.AddListener(() => target.DecreaseSize());
        
        SetupOnEndEditListenersForInputFields();
    }

    private void SetupOnEndEditListenersForInputFields()
    {
        rotXInputField.onEndEdit.AddListener(text =>
        {
            try
            {
                float newRotX = float.Parse(text);
                target.RotationSpeedX = newRotX;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
        
        rotYInputField.onEndEdit.AddListener(text =>
        {
            try
            {
                float newRotY = float.Parse(text);
                target.RotationSpeedY = newRotY;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
        
        rotZInputField.onEndEdit.AddListener(text =>
        {
            try
            {
                float newRotZ = float.Parse(text);
                target.RotationSpeedZ = newRotZ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
    }

    public void UpdateUi()
    {
        rotXInputField.text = target.RotationSpeedX.ToString(CultureInfo.InvariantCulture);
        rotYInputField.text = target.RotationSpeedY.ToString(CultureInfo.InvariantCulture);
        rotZInputField.text = target.RotationSpeedZ.ToString(CultureInfo.InvariantCulture);

        sizeText.text = "Current size: " + target.Scale.magnitude.ToString("0.##");
    }
}