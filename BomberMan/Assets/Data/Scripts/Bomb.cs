using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : DamageEntyty
{

    private Action<Bomb> _bombReturnAction;
    public void Init(Action<Bomb> poolReturnAction)
    {
        _bombReturnAction = poolReturnAction;
        SwitchActive(false);
    }

    public void SetBomb(Vector2 pos)
    {
        transform.position = pos;
        StartLifeCycle();
    }

    public override void StartLifeCycle()
    {
        SwitchActive(true);
        base.StartLifeCycle();
    }

    public override void Destroy()
    {
        base.Destroy();
        ReturnPool();
    }
    private void SwitchActive(bool active)
    {
        gameObject.SetActive(active);
    }

    private void ReturnPool()
    {
        SwitchActive(false);
        _bombReturnAction?.Invoke(this);
    }

}
