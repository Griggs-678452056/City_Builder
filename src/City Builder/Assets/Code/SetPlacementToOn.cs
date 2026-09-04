using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
    public class SetPlacementToOn : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _instantiateScript;
        [SerializeField] private GameObject _shopPanel;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_instantiateScript != null && _shopPanel != null)
            {
                if (_instantiateScript.activeSelf)
                {
                    _instantiateScript.SetActive(false);
                    _shopPanel.SetActive(false);
                }
                else
                {
                    _instantiateScript.SetActive(true);
                    _shopPanel.SetActive(false);
                }
            }
        }
    }
}