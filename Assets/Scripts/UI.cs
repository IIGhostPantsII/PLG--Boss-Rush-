using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] public PlayerController _pc;
    [SerializeField] public TMP_Text _ammoText; // The UI text element for the speaker's name

    // Update is called once per frame
    void Update()
    {
        _ammoText.text = $"AMMO: {_pc._ammo}/15";
    }
}
