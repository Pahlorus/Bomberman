using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageEntyty : MonoBehaviour, ITemporary, IDamage
{
    [SerializeField] private  int _lifeTime;
    private Coroutine _timeCoroutine;

    

    public int LifeTime => _lifeTime;

    public int Damage => throw new System.NotImplementedException();

    public virtual void StartLifeCycle()
    {
        _timeCoroutine = StartCoroutine(LifeCycle());
    }

    public virtual void Destroy()
    {
        StopAllCoroutines();
        _timeCoroutine = default;
    }

    public virtual int GetDamage()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator LifeCycle()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy();
    }


    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
