using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
    public class ShopOpen : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _shopPanel;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_shopPanel != null)
            {
                if (_shopPanel.activeSelf)
                {
                    _shopPanel.SetActive(false);
                }
                else
                {
                    _shopPanel.SetActive(true);
                }
            }
        }
    }
}