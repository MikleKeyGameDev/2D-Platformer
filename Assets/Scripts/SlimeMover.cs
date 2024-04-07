using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlimeMover : MonoBehaviour
{
    private const string NameGroundTag = "Ground";

    [SerializeField]private float _speed = 5f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        Vector2 move = new Vector2(_speed, 0);
        _rigidbody.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == NameGroundTag)
        {
            _speed *= -1f;
        }
    }
}
