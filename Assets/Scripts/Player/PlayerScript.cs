using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private const string AxisNameX = "Horizontal";

    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _jumpForce = 15.0f;

    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;

    private Rigidbody2D _rigidbody;

    private float _moveX;

    public float MoveX { get { return _moveX; } }
    public float Speed { get { return _speed; } }
    public float JumpForce { get { return _jumpForce; } }

    public KeyCode JumpKey { get { return _jumpKey; } }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        _moveX = Input.GetAxis(AxisNameX);
    }
}
