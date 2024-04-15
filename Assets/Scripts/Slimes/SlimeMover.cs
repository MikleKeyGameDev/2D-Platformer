using UnityEngine;

public class SlimeMover : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsTransform;
    [SerializeField] private float _speed;

    [SerializeField] private bool _isRight;

    private void Update()
    {
        CheckPosition();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_isRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointsTransform[1].position, _speed * Time.deltaTime);
        }
        else if(_isRight == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointsTransform[0].position, _speed * Time.deltaTime);
        }
    }

    private void CheckPosition()
    {
        if (transform.position.x <= _pointsTransform[0].position.x && _isRight == false)
        {
            _isRight = true;
        }
        else if (transform.position.x >= _pointsTransform[1].position.x && _isRight == true)
        {
            _isRight = false;
        }
    }
}
