using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Person : MonoBehaviour, IPerson, IMoving
{
    [SerializeField] private int _health;

    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private HeroController _controller;

    public int Damage => throw new System.NotImplementedException();

    public int Health => _health;

    public int Speed => throw new System.NotImplementedException();

    public string Name { get; set; }
    public Vector2 Pos
    {
        get { return _controller.Pos; }
        set { _controller.Pos = value; }
    }
    public Transform Transform => transform;
    public BoxCollider2D Collider => _collider;


    public void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual int GetDamage()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Move()
    {
        throw new System.NotImplementedException();
    }

    public virtual void SetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0) Destroy();

    }
}
