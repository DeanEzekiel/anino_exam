using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class LineList : MonoBehaviour
    {
        [SerializeField]
        List<Line> _listLines;

        public List<Line> ListLines => _listLines;
    }
}