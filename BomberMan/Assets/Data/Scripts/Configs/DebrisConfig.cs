using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(DebrisConfig), menuName = "ScriptableObjects/" + nameof(DebrisConfig))]
public class DebrisConfig : ScriptableObject
{
    public int Health;
    public int Damage;
}
