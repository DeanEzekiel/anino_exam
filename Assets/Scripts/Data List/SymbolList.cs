using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class SymbolList : MonoBehaviour
    {
        [SerializeField]
        List<Symbol> _listSymbols;

        public List<Symbol> ListSymbols => _listSymbols;
    }
}