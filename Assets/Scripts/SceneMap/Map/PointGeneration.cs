using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SodaDefender
{
    public class PointGeneration : MonoBehaviour
    {
        [SerializeField] private MapPoint _pointPlayable;
        [SerializeField] private GameObject _path;
        [SerializeField] private GameObject _pointLocked;
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private UnityEvent OnGenerated;

        private void Start()
        {
            Generated(); 
        }

        private void Generated()
        {
            PointStates pointStates = new PointStates();

            pointStates.States.Add(PointState.OPEN);
            pointStates.States.Add(PointState.ONE_STARS);
            pointStates.States.Add(PointState.TWO_STARS);
            pointStates.States.Add(PointState.THREE_STARS);
            pointStates.States.Add(PointState.LOCKED);
            pointStates.States.Add(PointState.LOCKED);
            pointStates.States.Add(PointState.LOCKED);

            PointPosition pointPosition = new PointPosition();
            Vector2 currentPosition; 
            List<Vector2> pointPositions = new List<Vector2>();

            for (int i = 0; i < pointStates.States.Count; i++)
            {
                currentPosition = pointPosition.GetNextPosition();
                pointPositions.Add(currentPosition);

                if (pointStates.States[i] == PointState.LOCKED)
                {
                    Instantiate(_pointLocked, transform).transform.position = currentPosition;
                }
                else 
                {
                    MapPoint point = Instantiate(_pointPlayable, transform);
                    point.transform.position = currentPosition;

                    Sprite sprite = null;

                    switch (pointStates.States[i])
                    {
                        case PointState.OPEN:
                            sprite = _sprites[1];
                            break;
                        case PointState.ONE_STARS:
                            sprite = _sprites[2];
                            break;
                        case PointState.TWO_STARS:
                            sprite = _sprites[3];
                            break;
                        case PointState.THREE_STARS:
                            sprite = _sprites[4];
                            break;
                    }
                    point.SetParameters(sprite, i);
                }
            }

            for (int i = 0; i < pointPositions.Count-1; i++)
            {
                currentPosition = (pointPositions[i]+pointPositions[i + 1]) / 2f;

                GameObject path = Instantiate(_path, transform);
                path.transform.position = currentPosition;

                Vector2 vector = pointPositions[i + 1] - pointPositions[i];
                float zRotate = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

                path.transform.Rotate(0,0, zRotate);
            }
            OnGenerated?.Invoke();
        }
    }
}