using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] public PlayerController _pc;
    [SerializeField] public GameObject[] _buttons;
    [SerializeField] public GameObject _options;

    public void BackToGame()
    {
        _pc._menuBool = !_pc._menuBool;
        _pc._noAni = !_pc._noAni;
        _pc._menu.SetActive(_pc._menuBool);
        Time.timeScale = _pc._menuBool ? 0 : 1;
        Cursor.visible = _pc._menuBool;
        Cursor.lockState = _pc._menuBool ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void Options()
    {
        _buttons[0].SetActive(false);
        _buttons[1].SetActive(false);
        _buttons[2].SetActive(false);
        _options.SetActive(true);

    }

    public void Back()
    {
        _buttons[0].SetActive(true);
        _buttons[1].SetActive(true);
        _buttons[2].SetActive(true);
        _options.SetActive(false);

    }
}
