using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject playerIconPrefab;
    public GameObject enemyIconPrefab;
    public GameObject pickupIconPrefab;
    public float mapScale = 0.05f;

    private Transform playerTransform;
    private Dictionary<Transform, RectTransform> minimapIcons = new Dictionary<Transform, RectTransform>();

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
            InitializeMinimap();
        }
    }

    void InitializeMinimap()
    {
        CreateIconForObject(playerTransform, playerIconPrefab);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Agent");
        foreach (GameObject enemy in enemies)
        {
            CreateIconForObject(enemy.transform, enemyIconPrefab);
        }

        int pickupLayer = LayerMask.NameToLayer("Pickup");
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == pickupLayer)
            {
                CreateIconForObject(obj.transform, pickupIconPrefab);
            }
        }
    }

    void CreateIconForObject(Transform worldObject, GameObject iconPrefab)
    {
        GameObject newIcon = Instantiate(iconPrefab, transform);
        RectTransform iconRect = newIcon.GetComponent<RectTransform>();

        UpdateIconPosition(worldObject, iconRect);

        minimapIcons.Add(worldObject, iconRect);
    }

    void Update()
    {
        if (playerTransform == null) return;

        foreach (var pair in minimapIcons)
        {
            if (pair.Key == null)
            {
                if (pair.Value != null) Destroy(pair.Value.gameObject);
                continue;
            }
            UpdateIconPosition(pair.Key, pair.Value);
        }
    }

    void UpdateIconPosition(Transform worldObject, RectTransform iconRect)
    {
        Vector3 relativePosition = worldObject.position - playerTransform.position;

        iconRect.anchoredPosition = new Vector2(relativePosition.x, relativePosition.z) * mapScale;

        if (worldObject.CompareTag("Player"))
        {
            iconRect.localEulerAngles = new Vector3(0, 0, -worldObject.eulerAngles.y);
        }
        else
        {
            iconRect.localEulerAngles = Vector3.zero;
        }
    }
}
