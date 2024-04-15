using UnityEngine;

[RequireComponent (typeof(PlayerMover), typeof(SwitchAnimationPlayer))]

public class Player : MonoBehaviour
{
    private const string AxisNameX = "Horizontal";

    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _jumpForce = 15.0f;

    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;

    private PlayerMover _playerMover;
    private SwitchAnimationPlayer _switchAnim;

    private float _moveX;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _switchAnim = GetComponent<SwitchAnimationPlayer>();
    }

    private void Update()
    {
        CheckInput();
        _playerMover.Jump(_jumpForce, _jumpKey);
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_speed, _moveX);
        _switchAnim.SwitchRun(_moveX);
    }

    private void CheckInput()
    {
        _moveX = Input.GetAxis(AxisNameX);
    }
}
