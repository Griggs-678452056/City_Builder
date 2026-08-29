using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private void Start()
    {
        float num = 1;
        Debug.Log("Начинаем двигать дома");
        Vector3 position = MoveObj(num);
        Debug.Log(position);
    }

    private void Update()
    {
        
    }

    private Vector3 MoveObj(float x)
    {
        Debug.Log("Запускаем метод перемещения домов");
        Vector3 position = transform.position += new Vector3(x, 0, 0);
        Debug.Log("Метод завершил работу");
        return position;
    }
}
