using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public GameObject cellPrefab; // Ссылка на наш префаб клетки
    public Material whiteMaterial; // Ссылка на белый материал
    public Material blackMaterial; // Ссылка на черный материал

    public int boardSize = 8; // Размер доски

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < boardSize; x++)
        {
            for (int z = 0; z < boardSize; z++)
            {
                // Создаем экземпляр префаба клетки
                GameObject newCell = Instantiate(cellPrefab, new Vector3(x, 0, z), Quaternion.identity, transform);

                // Решаем, какой материал использовать (шахматный порядок)
                bool isOffset = (x % 2 == 0 && z % 2 == 0) || (x % 2 == 1 && z % 2 == 1);
                newCell.GetComponent<Renderer>().material = isOffset ? whiteMaterial : blackMaterial;
            }
        }
    }
}
