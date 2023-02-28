using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityController : MonoBehaviour
{
    [SerializeField] public PlayerController _pc;
    [SerializeField] public Slider _slider;

    void Start()
    {
        _slider.value = _pc._mouseSensitivity;
    }

    public void SetMouseSensitivity(float value)
    {
        _pc._mouseSensitivity = value;
    }
}
