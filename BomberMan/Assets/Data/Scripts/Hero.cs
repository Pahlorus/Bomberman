using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Person
{
    public void SetBomb()
    {
        var bomb = EntityManager.Instance.GetBomb();
        bomb.SetBomb(transform.position);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SetBomb();
    }
}

