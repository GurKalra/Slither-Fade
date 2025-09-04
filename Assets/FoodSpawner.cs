using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject safeFoodPrefab;
    public BoxCollider2D gridArea;

    public float safeFoodSpawnChance = 0.40f;

    public static FoodSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        Bounds bounds = gridArea.bounds;

        float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        var randomValue = UnityEngine.Random.Range(0.0f, 1.0f);
        GameObject currentPrefab = foodPrefab;
        if (randomValue < safeFoodSpawnChance)
        {
            currentPrefab = safeFoodPrefab;
        }

        Instantiate(currentPrefab, spawnPosition, Quaternion.identity);
    }

}
