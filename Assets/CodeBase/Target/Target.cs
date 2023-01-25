using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public event Action OnPlayerInteracted;
    
    public void UpdatePosition(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        OnPlayerInteracted?.Invoke();
    }
}
