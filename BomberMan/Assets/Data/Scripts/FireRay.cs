using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRay : InteractableObject, ITemporary, IDamage
{
    public int LifeTime => throw new System.NotImplementedException();

    public int Damage => throw new System.NotImplementedException();

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public int GetDamage()
    {
        throw new System.NotImplementedException();
    }

    public void StartLifeCycle()
    {
        throw new System.NotImplementedException();
    }

}
