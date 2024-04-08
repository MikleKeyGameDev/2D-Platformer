using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerScript))]
public class PlayerMover : MonoBehaviour
{
    private const string NameGroundTag = "Ground";

    private Rigidbody2D _rigidbody;
    private PlayerScript _player;

    private bool _isRight;
    private bool _isGround = false;
    private bool _isDownJumpKey;

    private void Start()
    {
        _player = GetComponent<PlayerScript>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == NameGroundTag)
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == NameGroundTag)
        {
            _isGround = false;
        }
    }

    private void Move()
    {
        Vector2 move = new Vector2(_player.MoveX * _player.Speed, _rigidbody.velocity.y);
        _rigidbody.velocity = move;

        if (_isRight == true && _player.MoveX > 0)
        {
            Flip();
        }
        else if(_isRight == false && _player.MoveX < 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(_player.JumpKey) == true && _isGround == true)
        {
            _isGround = false;
            Vector2 force = new Vector2(0, _player.JumpForce);
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        Quaternion rotation = transform.rotation;
        _isRight = !_isRight;

        if(rotation.y > 0)
        {
            rotation.y = 0;
            transform.rotation = rotation;
        }
        else if(rotation.y <= 0)
        {
            rotation.y = 180;
            transform.rotation = rotation;
        }
    }
}
