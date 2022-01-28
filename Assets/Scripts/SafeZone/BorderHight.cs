using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BorderHight : MonoBehaviour
    {
        private const float FullSize = 2f;

        [SerializeField] private Camera _camera;

        private void Start()
        {
            SetSize();
        }

        private void SetSize()
        {
            float yScale = _camera.ScreenToWorldPoint(Screen.safeArea.max).y * FullSize;
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.size = new Vector2(boxCollider.size.x, yScale);
        }
    }
}
