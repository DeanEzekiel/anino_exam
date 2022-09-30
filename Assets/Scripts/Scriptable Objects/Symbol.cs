using UnityEngine;

namespace SlotMachine
{
    [CreateAssetMenu(fileName = "Symbol", menuName = "ScriptableObjects/SymbolData")]
    public class Symbol : ScriptableObject
    {
        #region Inspector Fields
        [SerializeField]
        int symbolID;
        [SerializeField]
        string symbolName;
        [SerializeField]
        Sprite sprite;
        [SerializeField]
        int[] payout = new int[5];
        #endregion // Inspector Fields

        #region Accessors
        public int SymbolID => symbolID;
        public string SymbolName => symbolName;
        public int[] Payout => payout;
        public Sprite Sprite => sprite;
        #endregion // Accessors
    }
}