using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public class DestroyEffectSpawner : MonoBehaviour
    {
        private DestroyEffectGenerator _generator;

        private void Awake()
        {
            _generator = GetComponent<DestroyEffectGenerator>();
        }
        private void Activate(Transform obj)
        {
            GameObject effect = _generator.GetFreeEffect();
            effect.transform.position = obj.position;
            effect.SetActive(true);
        }

        private void OnEnable()
        {
            DestroyEffect.OnEffectActivated += Activate;
        }

        private void OnDisable()
        {
            DestroyEffect.OnEffectActivated -= Activate;
        }

    }
}
