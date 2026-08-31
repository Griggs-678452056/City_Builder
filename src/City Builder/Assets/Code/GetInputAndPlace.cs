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
                Debug.Log(position);
            }
        }
    }
}
