using TMPro;
using UnityEngine;

namespace Code
{
    public class GetInputAndPlace : MonoBehaviour
    {
        [SerializeField] private LayerMask _mouseLayerMask;

        [SerializeField] private GameObject _building1;

        private int _cellSize = 2;

        int _dollars;
        int _citizens;
        int _popularity;

        [SerializeField] private TextMeshProUGUI _dollarsText;
        [SerializeField] private TextMeshProUGUI _citizensText;
        [SerializeField] private TextMeshProUGUI _popularityText;

        private void Start()
        {
            _dollars = int.Parse(_dollarsText.text);
            _citizens = int.Parse(_citizensText.text);
            _popularity = int.Parse(_popularityText.text);
        }

        private void Update()
        {
            InputAndPlace();

            _dollars = int.Parse(_dollarsText.text);
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

                    Vector3 gridPos = CalculateGridPosition(position);

                    if (ObjectAtPosition(gridPos))
                    {
                        return;
                    }
                    else
                    {
                        GameObject house = Instantiate(_building1, gridPos, transform.rotation * Quaternion.Euler(270, 180, 0));
                        BoxCollider houseCollider = house.AddComponent<BoxCollider>();
                        house.tag = "House";

                        _dollars -= 20000;
                        _dollarsText.text = _dollars.ToString();

                        _citizens += 5;
                        _citizensText.text = _citizens.ToString();

                        _popularity += 5;
                        _popularityText.text = _popularity.ToString();
                    }
                }
            }
        }

        private Vector3 CalculateGridPosition(Vector3 inputPosition)
        {
            int x = Mathf.FloorToInt(inputPosition.x);
            int z = Mathf.FloorToInt(inputPosition.z);
            return new Vector3(x, 0, z);
        }

        private bool ObjectAtPosition(Vector3 inputPosition)
        {
            Collider[] intersecting = Physics.OverlapSphere(inputPosition, 1f);

            if (intersecting.Length < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}