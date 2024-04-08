using UnityEngine;

[RequireComponent (typeof(Animator), typeof(PlayerScript))]
public class SwitchAnimationPlayer : MonoBehaviour
{
    const string BoolNameRun = "isRun";

    private PlayerScript _player;
    private Animator _animator;

    private void Start()
    {
        _player = GetComponent<PlayerScript>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SwitchRun();
    }

    private void SwitchRun()
    {
        _animator.SetBool(BoolNameRun, _player.MoveX != 0);
    }
}
