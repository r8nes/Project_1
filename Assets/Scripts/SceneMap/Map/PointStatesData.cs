using UnityEngine;

namespace SodaDefender
{
    public class PointStatesData : MonoBehaviour
    {
        private const string KEY = "StateData";

        public void Save(PointStates pointStates)
        {
            PlayerPrefs.SetString(KEY, JsonUtility.ToJson(pointStates));
            PlayerPrefs.Save();
        }

        public PointStates Load()
        {
            if (PlayerPrefs.HasKey(KEY))
            {
                return JsonUtility.FromJson<PointStates>(PlayerPrefs.GetString(KEY));
            }
            return null;
        }
    }
}
