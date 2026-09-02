using UnityEngine;

public class GetInputAndPlace : MonoBehaviour
{
    [SerializeField] private LayerMask _mouseLayerMask;

    [SerializeField] private GameObject _building1;

    private int _cellSize = 5;

    private void Start()
    {
        
    }

    private void Update()
    {
        InputAndPlace();
    }

    private void InputAndPlace() // сначала устанавливаем позицию клика, затем создаём здание
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Нажата левая кнопка мыши...");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _mouseLayerMask))
            {
                Debug.Log("Raycast выполнен");
                Vector3 position = hit.point;
                Debug.Log("Позиция здания: " + CalculateGridPosition(position));

                GameObject house = Instantiate(_building1, position, transform.rotation * Quaternion.Euler(270, 180, 0));
            }
        }
    }

    private Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt(inputPosition.x);
        int z = Mathf.FloorToInt(inputPosition.z);
        return new Vector3(x, 0, z);
    }
}
