using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public enum ObjectTags {HERO = 1, WALL = 2 }
public enum Direction { NONE, LEFT, RIGHT, TOP, BOTTOM }


public class HeroController : MonoBehaviour
{
    private bool _isMoving;
    private Direction _dir;
    private Tween _tween;

    public float speed;

    public Vector2 Pos;


    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (_isMoving) return;

        if (movement.x > 0) _dir = Direction.RIGHT;
        else if (movement.x < 0) _dir = Direction.LEFT;
        else if (movement.y > 0) _dir = Direction.TOP;
        else if (movement.y < 0) _dir = Direction.BOTTOM;
        else _dir = Direction.NONE;
        Moving(_dir).Forget();
    }

    private async UniTask Moving(Direction dir)
    {
        if (_isMoving) return;
        if (dir == Direction.NONE) return;
        _isMoving = true;
        Vector2 newPos;
        switch (dir)
        {
            case Direction.LEFT: newPos = new Vector3(Pos.x - Board.ShiftX, Pos.y); break;
            case Direction.RIGHT: newPos = new Vector3(Pos.x + Board.ShiftX, Pos.y); break;
            case Direction.TOP: newPos = new Vector3(Pos.x, Pos.y + Board.ShiftY); break;
            case Direction.BOTTOM: newPos = new Vector3(Pos.x, Pos.y - Board.ShiftY); break;
            default: newPos = Vector3.zero; break;
        }

        _tween = _rigidbody.DOMove(newPos, 0.3f).SetEase(Ease.Linear);
        await _tween.AsyncWaitForCompletion();
        _tween.Kill();
        if (_isMoving) Pos = newPos;
        _isMoving = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Stop();
        var tag = collision.gameObject.tag.GetTag();

    }

    private void Stop()
    {
        _tween.Kill();
        _rigidbody.MovePosition(Pos);
        _isMoving = false;
    }

}
