using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isInputBlocked = false;

    public void BlockInput() => _isInputBlocked = true;
    public void UnblockInput() => _isInputBlocked = false;
    public bool IsInputBlocked => _isInputBlocked;

    public void StartTurn(TeamColor team)
    {
        UnblockInput();
    }

    public void ExecuteMove(Unit unit, Cell targetCell)
    {
        BlockInput();
        StartCoroutine(AnimateMove(unit, targetCell));
    }

    private IEnumerator AnimateMove(Unit unit, Cell targetCell)
    {
        Vector3 startPos = unit.transform.position;
        Vector3 endPos = targetCell.transform.position;
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            unit.transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        unit.transform.position = endPos;
        UnblockInput();
    }
}
