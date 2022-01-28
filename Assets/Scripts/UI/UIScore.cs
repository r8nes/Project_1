using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SodaDefender
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void ShowValue(int value) 
        {
            _text.text = value.ToString();
        }
    }
}
