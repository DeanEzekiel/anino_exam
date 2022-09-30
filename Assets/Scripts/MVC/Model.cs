using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class Model : MonoBehaviour
    {
        [SerializeField]
        Controller controller;

        [SerializeField]
        int initCoins = 200000;

        private int _coins;
        public int Coins => _coins;

        private int lines => GameMain.Instance.Lines.ListLines.Count;
        private int _bet;
        public int Bet => _bet;
        public int TotalBet => _bet * lines;

        public List<List<CellSymbol>> result = new List<List<CellSymbol>>();

        public string[,] ArrResult = new string[3, 5];

        private int minBet = 1;

        public List<Reel> Reels;

        public List<Row> Rows;

        public void RandomizeReels()
        {
            foreach(Reel reel in Reels)
            {
                reel.RandomizeCells();
            }
        }

        public void SpinReels()
        {
            foreach(Reel reel in Reels)
            {
                reel.Spin();
            }
        }

        public void Initialize()
        {
            _coins = initCoins;
            _bet = 1;
        }

        public void BetMore()
        {
            Debug.Log("Model: BetMore clicked");
            if (Coins > TotalBet)
            {
                _bet++;
                Debug.Log($"New Bet: {_bet} and Total Bet is {_bet * lines}");
            }
        }

        public void BetLess()
        {
            Debug.Log("Model: BetLess clicked");
            if (_bet > minBet)
            {
                _bet--;
                Debug.Log($"New Bet: {_bet} and Total Bet is {_bet * lines}");
            }
        }

        public void CollectBet()
        {
            _coins -= TotalBet;
        }

        public void CollectWinnings(int winnings)
        {
            _coins += winnings;
        }

        public void BuildResult()
        {
            for (int x = 0; x < Rows.Count; x++)
            {
                for (int y = 0; y < Reels.Count; y++)
                {
                    Vector3 position = Rows[x].Positions[y].position;

                    CellSymbol cell = Reels[y].GetCellFromPosition(position);
                    if (cell != null)
                    {
                        ArrResult[x,y] = cell.Symbol.SymbolName;
                        //Debug.Log($"Result X {x} Y {y}: {cell.Symbol.SymbolName}");
                    }
                    else
                    {
                        Debug.Log($"Cell in position {position} is null");
                    }
                }
            }


            //result.Clear();

            //List<CellSymbol> temp = new List<CellSymbol>();
            //for (int x = 0; x < Rows.Count; x++)
            //{
            //    // clear the temp
            //    temp.Clear();

            //    for (int y = 0; y < Reels.Count; y++)
            //    {
            //        Vector3 position = Rows[x].Positions[y].position;

            //        CellSymbol cell = Reels[y].GetCellFromPosition(position);
            //        if (cell != null)
            //        {
            //            temp.Add(cell);
            //            Debug.Log($"Result X {x} Y {y}: {cell.Symbol.SymbolName}");
            //        }
            //        else
            //        {
            //            Debug.Log($"Cell in position {position} is null");
            //        }
            //    }

            //    result.Add(temp);
            //}
        }
    }
}