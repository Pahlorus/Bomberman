using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour, IBlock, IDamage
{
    [SerializeField] private BoxCollider2D _collider;

    public int Damage => throw new System.NotImplementedException();

    public int Health => throw new System.NotImplementedException();

    public Transform Transform => transform;
    public BoxCollider2D Collider => _collider;

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public int GetDamage()
    {
        throw new System.NotImplementedException();
    }

    public void SetDamage(int health)
    {
        throw new System.NotImplementedException();
    }
}
