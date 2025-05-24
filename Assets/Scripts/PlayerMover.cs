using UnityEngine;
using DG.Tweening;

public class PlayerMover : MonoBehaviour
{
    //сохраняем точки между которыми будет перемещаться игрок
    [SerializeField]
    private Transform[] pathPoints;

    void Start()
    {
        //запуск корутины перемещения по точкам
        MoveAlongPath();

        // изменение масштабов + добавление цикличности анимации
        transform.DOScale(new Vector3(1.5f, 1.5f, 1), 1f)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void MoveAlongPath()
    {
        //создаем массив из сохраненных точек и итерируемся по нему
        Vector3[] positions = new Vector3[pathPoints.Length];
        for (int i = 0; i < pathPoints.Length; i++)
        {
            positions[i] = pathPoints[i].position;
        }

        // движение между заданными точками
        transform.DOPath(positions, 3f, PathType.CatmullRom)
            .SetEase(Ease.InOutSine) // плавное движение
            .SetLoops(-1, LoopType.Yoyo) // цикличность передвижения
            .SetDelay(1f); // подождать 1 секунду перед началом
    }
}