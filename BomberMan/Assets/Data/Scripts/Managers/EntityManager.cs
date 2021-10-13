using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EBlockType
{
    Wall, Debris
}

public enum EPersonType
{
    Hero, Enemy
}


public class EntityManager : MonoBehaviour
{
    [SerializeField] private WallFactory _wallFactory;
    [SerializeField] private DebrisFactory _debrisFactory;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private HeroFactory _heroFactory;

    private Queue<Bomb> _bombPool;

    public int StartBombInPool;
    public Bomb BombPref;
    public Wall WallPref;
    public Transform Board;

    public static EntityManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _bombPool = new Queue<Bomb>();
        for (int i = 0; i < StartBombInPool; i++)
        {
            _bombPool.Enqueue(BombCreate());
        }
    }

    public Bomb GetBomb()
    {
        if (_bombPool.Count > 0) return _bombPool.Dequeue();
        else return BombCreate();
    }


    public IBlock GetWall(bool blockingDestroy, Transform container)
    {
        return _wallFactory.GetBlock(blockingDestroy, container);
    }

    public IBlock GetDebris(Transform container)
    {
        return _debrisFactory.GetBlock( container);
    }


    public IPerson GetHero(Transform container)
    {
        return _heroFactory.GetBlock(container);
    }

    private void BombReturn(Bomb bomb)
    {
        _bombPool.Enqueue(bomb);
    }

    private Bomb BombCreate()
    {
        var bomb = Instantiate(BombPref);
        bomb.Init(BombReturn);
        return bomb;
    }
}

public abstract class BlockFactory<T> : ScriptableObject, ICreateBlock<T> where T : MonoBehaviour
{
    public T pref;
    public virtual T CreateBlock(T pref, Transform container)
    {
        return Instantiate(pref, container);
    }
}

public abstract class PersonFactory<T> : ScriptableObject, ICreatePerson<T> where T : MonoBehaviour
{
    public T pref;
    public virtual T CreateBlock(T pref, Transform container)
    {
        return Instantiate(pref, container);
    }
}

[CreateAssetMenu(fileName = nameof(WallFactory), menuName = "ScriptableObjects/Factory/" + nameof(WallFactory))]
public class WallFactory : BlockFactory<Wall>
{
    public Wall GetBlock(bool blockingDestroy, Transform container)
    {
        var wall = CreateBlock(pref, container);
        wall.BlockingDestroy = blockingDestroy;
        return wall;
    }
}

[CreateAssetMenu(fileName = nameof(DebrisFactory), menuName = "ScriptableObjects/Factory/" + nameof(DebrisFactory))]
public class DebrisFactory : BlockFactory<Debris>
{
    public Debris GetBlock(Transform container)
    {
        return CreateBlock(pref, container);
    }
}

public class EnemyFactory : BlockFactory<Enemy>
{
    public Enemy GetBlock(Transform container)
    {
        return CreateBlock(pref, container);
    }
}

[CreateAssetMenu(fileName = nameof(HeroFactory), menuName = "ScriptableObjects/Factory/" + nameof(HeroFactory))]
public class HeroFactory : PersonFactory<Hero>
{
    public Hero GetBlock(Transform container)
    {
        return CreateBlock(pref, container);
    }
}

