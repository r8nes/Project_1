using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SodaDefender
{
    [RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
    public class MapPoint : MonoBehaviour, IPointerDownHandler
    {
        private int _index;

        [SerializeField] private TextMeshPro _text;
        [SerializeField] private UnityEvent OnClick;

        public void SetParameters(Sprite sprite, int index) 
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            _index = index;
            _text.text = _index.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            LevelNameData level = new LevelNameData();
            level.SetName("Game"); //HACK: строка
            level.SetLevelIndex(_index);
            OnClick.Invoke();
        }
    }
}
