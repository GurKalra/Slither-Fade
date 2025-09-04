using System;
using UnityEngine;

public class SafeFood : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (FoodSpawner.Instance != null)
            {
                FoodSpawner.Instance.SpawnFood();

                Destroy(this.gameObject);
            }
        }
    }
}
