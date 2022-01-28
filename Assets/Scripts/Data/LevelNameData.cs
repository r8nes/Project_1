using UnityEngine;

namespace SodaDefender
{
    public class LevelNameData 
    {
        private const string KEY = "SceneName";
        private const string KEY_LEVEL_INDEX= "LevelIndex";

        public void SetName(string name) 
        {
            PlayerPrefs.SetString(KEY, name);
            PlayerPrefs.Save();
        }

        public string GetName() 
        {
            if (PlayerPrefs.HasKey(KEY))
            {
                return PlayerPrefs.GetString(KEY);
            }
            return null;
        }

        public void SetLevelIndex(int value) 
        {
            PlayerPrefs.SetInt(KEY_LEVEL_INDEX, value);
            PlayerPrefs.Save();
        }

        public int GetLevelIndex() 
        {
            if (PlayerPrefs.HasKey(KEY_LEVEL_INDEX))
            {
                return PlayerPrefs.GetInt(KEY_LEVEL_INDEX);
            }
            return 0;
        }
    }
}
