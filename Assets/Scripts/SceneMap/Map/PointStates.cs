using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    [System.Serializable]
    public class PointStates
    {
        public List<PointState> States = new List<PointState>();
    }

    [System.Serializable]
    public enum PointState
    { 
        LOCKED,
        OPEN,
        ONE_STARS,
        TWO_STARS,
        THREE_STARS
    }    
}
