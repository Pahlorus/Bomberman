using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IDestroyable
{
    int Health { get; }
    void SetDamage(int health);
    void Destroy();

}

interface IDamage
{
    int Damage { get; }
    int GetDamage();
}


interface IMoving
{
    int Speed { get; }
    void Move();
}

interface ITemporary
{
    int LifeTime { get; }
    void StartLifeCycle();
    void Destroy();
}


public interface IBlock : IDestroyable
{
    Transform Transform { get; }
    BoxCollider2D Collider { get; }
}

public interface IPerson : IDestroyable
{
    Transform Transform { get; }
    BoxCollider2D Collider { get; }
}

interface ICreateBlock<T>
{
    T CreateBlock(T pref, Transform container);
}

public interface ICreatePerson<T>
{
    T CreateBlock(T pref, Transform container);
}