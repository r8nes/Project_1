using UnityEngine;

namespace SodaDefender
{
    public class StartEvents : MonoBehaviour
    {
        [SerializeField] private GameEvent _startScene;
        [SerializeField] private GameEvent _gamePlay;

        private void Start()
        {
            _startScene.Init();
            _gamePlay.Init();
        }
    }
}
