using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class CellSymbol : MonoBehaviour
    {
        [SerializeField]
        public Symbol Symbol;
        [SerializeField]
        SpriteRenderer _spriteRenderer;
        [SerializeField]
        Reel reelParent;

        public void SetSymbol(Symbol symbol)
        {
            Symbol = symbol;
            SetSprite();
        }

        public void SetReel(Reel reel)
        {
            reelParent = reel;
        }

        [ContextMenu("Set Sprite")]
        private void SetSprite()
        {
            _spriteRenderer.sprite = Symbol.Sprite;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log($"2D Repositioning to {reelParent.SpawnPos}");
            float toYPosition = reelParent.LastCell.transform.position.y + reelParent.Interval;
            transform.position = new Vector3(transform.position.x, toYPosition, transform.position.z);

            reelParent.ChangeLastCell(this);
        }
    }
}