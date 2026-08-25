using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private Elephant elephantPrefab;
    [SerializeField] private Transform elephantSpawnPoint;

    private void Start()
    {
        SpawnElephant();
    }

    private void SpawnElephant()
    {
        Instantiate(elephantPrefab, elephantSpawnPoint.position, elephantSpawnPoint.rotation);
    }
}
