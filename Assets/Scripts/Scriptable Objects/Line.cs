using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = "Line", menuName = "ScriptableObjects/LineData")]
    public class Line : ScriptableObject
    {
        #region Inspector Fields
        [SerializeField]
        int[] combination = new int[5];
        #endregion // Inspector Fields

        #region Accessors
        public int[] Combination => combination;
        #endregion // Accessors
    }
}