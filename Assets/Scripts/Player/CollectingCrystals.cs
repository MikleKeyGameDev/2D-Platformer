using UnityEngine;

public class CollectingCrystals : MonoBehaviour
{
    private Crystal _crystal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Crystal>(out _crystal) == true)
        {
            _crystal.DeleteObject();
            Debug.Log("Вы подобрали кристал!");
        }
    }
}
