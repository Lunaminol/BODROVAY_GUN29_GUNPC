using UnityEngine;
public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _trashPrefab;
    [SerializeField]
    private int _trashCount = 10;
    [SerializeField]
    private Vector3 _roomSize = new Vector3(10, 1, 10);

    private void Start()
    {
        for (int i = 0; i < _trashCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-_roomSize.x / 2, _roomSize.x / 2),
                0.5f,
                Random.Range(-_roomSize.z / 2, _roomSize.z / 2)
            );

            Instantiate(_trashPrefab, randomPosition, Quaternion.identity);
        }
    }
}
