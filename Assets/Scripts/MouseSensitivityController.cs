using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseSensitivityController : MonoBehaviour
{
    [SerializeField] public TMP_InputField _inputField;
    [SerializeField] public PlayerController _pc;
    [SerializeField] public Slider _slider;

    public void SetMouseSensitivity(float value)
    {
        Debug.Log("Setting mouse sensitivity to " + value);
        _pc._mouseSensitivity = value;
        value = Mathf.Round(value * 1000f) / 1000f;
        _inputField.text = value.ToString();
    }
}
