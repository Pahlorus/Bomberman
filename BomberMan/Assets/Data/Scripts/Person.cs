using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Person : MonoBehaviour, IPerson, IMoving
{
    [SerializeField] private BoxCollider2D _collider;

    public int Damage => throw new System.NotImplementedException();

    public int Health => throw new System.NotImplementedException();

    public int Speed => throw new System.NotImplementedException();

    public string Name { get; set; }

    public Transform Transform => transform;
    public BoxCollider2D Collider => _collider;


    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public virtual int GetDamage()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Move()
    {
        throw new System.NotImplementedException();
    }

    public virtual void SetDamage(int health)
    {
        throw new System.NotImplementedException();
    }
}
