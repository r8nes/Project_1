using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    [CreateAssetMenu(fileName ="Path", menuName = "GameSO/Path", order = 0)]
    public class Path : ScriptableObject
    {
        public List<Vector2> Points = new List<Vector2>();
#if UNITY_EDITOR
        [ContextMenu("Save Path")]
        private void SavePoints() 
        {
            ScenePath enemyPath = FindObjectOfType<ScenePath>();

            if (enemyPath != null)
            {
                Points = enemyPath.GetPathPoints();
                UnityEditor.EditorUtility.SetDirty(this);
                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
            }
        }

        [ContextMenu("Load Points")]
        private void LoadPoints() 
        {
            GameObject path = new GameObject("Path");
            ScenePath scenePath = path.AddComponent<ScenePath>();

            for (int i = 0; i < Points.Count; i++)
            {
                GameObject point = new GameObject($"Points{i}");
                point.transform.SetParent(path.transform);
                point.transform.position = Points[i];
                scenePath.AddPoint(point.transform);
            }
        }
#endif
    }
}
