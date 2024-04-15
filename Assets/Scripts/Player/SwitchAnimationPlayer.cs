using UnityEngine;

[RequireComponent (typeof(Animator))]
public class SwitchAnimationPlayer : MonoBehaviour
{
    const string BoolNameRun = "isRun";
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SwitchRun(float moveX)
    {
        _animator.SetBool(BoolNameRun, moveX != 0);
    }
}
