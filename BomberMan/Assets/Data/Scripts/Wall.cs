
using UnityEngine;

public class Wall :MonoBehaviour, IBlock
{
    private bool _blockingDestroy;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private SpriteRenderer _renderer;

    public Sprite destroyableSprite;
    public Sprite concreteBlockSprite;
   

    public bool BlockingDestroy
    {
        get { return _blockingDestroy; }
        set
        {
            if (value) _renderer.sprite = concreteBlockSprite;
            else _renderer.sprite = destroyableSprite;
            _blockingDestroy = value;
        }
    }

    public int Health => throw new System.NotImplementedException();
    public Transform Transform => transform;
    public BoxCollider2D Collider => _collider;

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }

    public void SetDamage(int health)
    {
        throw new System.NotImplementedException();
    }
}
