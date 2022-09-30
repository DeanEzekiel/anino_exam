using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class Reel : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField]
        int size = 10;
        [SerializeField]
        float speed = 10;

        [SerializeField]
        float firstPos = -1.5f;
        [SerializeField]
        float interval = 1.5f;
        [SerializeField]
        float lastPos = 0f;

        [SerializeField]
        CellSymbol _cellPrefab;

        public CellSymbol LastCell;

        [SerializeField]
        List<Symbol> listSymbols; // TODO check if still needed
        public List<CellSymbol> listCells;
        #endregion // Inspector Fields

        #region Accessors
        public int Size => size;
        public List<Symbol> ListSymbols => listSymbols;
        public float Interval => interval;
        public float LastPos => lastPos;
        public float SpawnPos => lastPos - interval;
        #endregion // Accessors

        #region Public Methods
        public void AddSymbol(Symbol symbol)
        {
            if (listSymbols.Count < size)
            {
                listSymbols.Add(symbol);

                CellSymbol cell = Instantiate(_cellPrefab);
                cell.SetSymbol(symbol); // also sets the sprite
                cell.SetReel(this);

                float yPos = 0f;
                if (listSymbols.Count == 1)
                {
                    yPos = firstPos;
                }
                else
                {
                    yPos = (listSymbols.Count - 2) * interval;
                }
                cell.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
                cell.transform.SetParent(transform);

                listCells.Add(cell);

                // cache the last Position
                lastPos = yPos;
                LastCell = cell;
            }
        }

        public void ChangeLastCell(CellSymbol lastCell)
        {
            LastCell = lastCell;
        }

        [ContextMenu("Randomize Cells")]
        public void RandomizeCells()
        {
            ClearCellsAndSymbols();
            for (int i = 0; i < size; i++)
            {
                int random = Random.Range(0, GameMain.Instance.Symbols.ListSymbols.Count);
                Symbol randomSymbol = GameMain.Instance.Symbols.ListSymbols[random];
                AddSymbol(randomSymbol);
            }
        }

        public void Spin()
        {
            int random = Random.Range(11, 21);
            float distance = interval * random * -1;
            Vector3 targetPosition = new Vector3(transform.position.x,
                transform.position.y + distance,
                transform.position.z);

            StartCoroutine(LerpPosition(targetPosition, 2));
        }

        public CellSymbol GetCellFromPosition(Vector3 position)
        {
            foreach(CellSymbol cell in listCells)
            {
                if (cell.transform.position == position)
                {
                    return cell;
                }
            }
            return null;
        }

        #endregion // Public Methods

        #region Private Methods

        private IEnumerator LerpPosition(Vector3 targetPosition, float duration)
        {
            float time = 0;
            Vector3 startPosition = transform.position;
            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
        }

        private void ClearCellsAndSymbols()
        {
            listSymbols.Clear();
            listCells.Clear();
            foreach(Transform child in transform)
            {
                DestroyImmediate(child);
            }
        }
        #endregion // Private Methods
    }
}