using TMPro;
using UnityEngine;

namespace Code
{
    public class Economy : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dollarsText;

        double _startTime;
        int _dollars;
        int _totalHouses;

        private void Start()
        {
            _startTime = Time.timeAsDouble;
            _dollars = 1000000;
        }

        private void Update()
        {
            _dollars = int.Parse(_dollarsText.text);

            double currentTime = Time.timeAsDouble;
            double timeFromStart = currentTime - _startTime;

            if (timeFromStart > 3)
            {
                _startTime = Time.timeAsDouble;
                _totalHouses = 0;

                GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
                foreach (GameObject obj in allObjects)
                {
                    if (obj != null)
                    {
                        if (obj.CompareTag("House"))
                        {
                            _totalHouses++;
                        }
                    }
                }

                int addDollars = _totalHouses * 100;
                _dollars += addDollars;

                _dollarsText.text = _dollars.ToString();

                Debug.Log("Дома: " + _totalHouses);
            }
        }
    }
}