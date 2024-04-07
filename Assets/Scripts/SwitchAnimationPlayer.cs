using UnityEngine;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(PlayerMover))]
public class SwitchAnimationPlayer : MonoBehaviour
{
    const string BoolNameRun = "isRun";

    private PlayerMover _mover;
    private Animator _animator;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SwitchRun();
    }

    private void SwitchRun()
    {
        _animator.SetBool(BoolNameRun, _mover.MoveX != 0);
    }
}
