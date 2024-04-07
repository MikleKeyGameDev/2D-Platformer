using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string AxisNameX = "Horizontal";
    private const string NameGroundTag = "Ground";

    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _jumpForce;

    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;

    private Rigidbody2D _rigidbody;

    private bool _isRight;
    private bool _isGround = false;

    public float MoveX { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        MoveX = Input.GetAxis(AxisNameX);
        Vector2 move = new Vector2(MoveX * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = move;

        if(_isRight == true && MoveX > 0)
        {
            Flip();
        }
        else if(_isRight == false && MoveX < 0)
        {
            Flip();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == NameGroundTag)
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

    private void Jump()
    {
        if (Input.GetKeyDown(_jumpKey) && _isGround == true)
        {
            _isGround = false;
            Vector2 force = new Vector2(0, _jumpForce);
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        _isRight = !_isRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}
