using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    [SerializeField]
    private float _collectRadius = 1f;
    [SerializeField]
    private LayerMask _trashLayer;

    private void FixedUpdate()
    {
        Collider[] trashItems = Physics.OverlapSphere(transform.position, _collectRadius, _trashLayer);
        foreach (Collider trash in trashItems)
        {
            Destroy(trash.gameObject);
        }
    }
}

