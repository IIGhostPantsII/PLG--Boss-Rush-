using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] public PlayerController _pc;

    bool _hasSMG = true;
    bool _hasLMG;

    void Update()
    {
        Gun smg = new SMG();
        if(_hasSMG)
        {
            if(_pc._ammo < 1 && !_pc._reload)
            {
                _pc._reload = true;
                StartCoroutine(smg.Reload(_pc));
            }
        }
    }

    public virtual IEnumerator Reload(PlayerController pc)
    {
        yield return new WaitForSeconds(1.0f);
        pc._reload = false;
    }
}


public class SMG : Gun
{
    public override IEnumerator Reload(PlayerController pc)
    {
        yield return new WaitForSeconds(3.0f);
        pc._reload = false;
        pc._ammo = 15;
    }
}

//LMG reload - when I put in a LMG
public class LMG : Gun
{
    public override IEnumerator Reload(PlayerController pc)
    {
        yield return new WaitForSeconds(5.0f);
        pc._reload = false;
    }
}
