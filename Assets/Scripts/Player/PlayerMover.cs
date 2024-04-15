using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private bool _isRight;
    private bool _isGround = false;

    private Ground _ground;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _ground))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _ground))
        {
            _isGround = false;
        }
    }

    public void Move(float speed, float moveX)
    {
        Vector2 move = new Vector2(moveX * speed, _rigidbody.velocity.y);
        _rigidbody.velocity = move;

        if (_isRight == true && moveX > 0)
        {
            Flip();
        }
        else if(_isRight == false && moveX < 0)
        {
            Flip();
        }
    }

    public void Jump(float jumpForce, KeyCode jumpKey)
    {
        if (Input.GetKeyDown(jumpKey) == true && _isGround == true)
        {
            _isGround = false;
            Vector2 force = new Vector2(0, jumpForce);
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
