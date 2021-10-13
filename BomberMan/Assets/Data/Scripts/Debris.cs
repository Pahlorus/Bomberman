using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : InteractableObject, IBlock, IDamage
{
    [SerializeField] private DebrisConfig _config;
    [SerializeField] private BoxCollider2D _collider;

    public int Damage => _config.Damage;

    public int Health => throw new System.NotImplementedException();

    public Transform Transform => transform;
    public BoxCollider2D Collider => _collider;


    protected override void OnCollisionStay2D(Collision2D collision)
    {
        var go = collision.gameObject;
        var tag = go.tag.GetTag();
        if(tag == Tag.HERO)
        {
            var iHero = go.GetComponent<IPerson>();
            iHero.SetDamage(Damage);
        }
    }


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
