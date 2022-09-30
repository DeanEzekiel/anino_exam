using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotMachine
{
    public class Controller : ControllerAccess
    {
        [SerializeField]
        Model model;
        [SerializeField]
        View view;

        public int Coins => model.Coins;
        public int TotalBet => model.TotalBet;

        private List<Line> ListLines => GameMain.Instance.Lines.ListLines;
        private List<Symbol> ListSymbols => GameMain.Instance.Symbols.ListSymbols;

        #region Unity Callbacks
        private void Start()
        {
            Initialize();
        }
        #endregion // Unity Callbacks

        private void Initialize()
        {
            model.Initialize();
            model.RandomizeReels();

            view.SetCoinText();
            view.SetTotalBetText();
            view.SetWinnings(0);
        }

        public void BetMore()
        {
            Debug.Log("BetMore clicked");
            model.BetMore();
            view.SetTotalBetText();
        }

        public void BetLess()
        {
            Debug.Log("BetLess clicked");
            model.BetLess();
            view.SetTotalBetText();
        }

        public void Spin()
        {
            if(TotalBet > Coins)
            {
                Debug.Log("Insufficient Coins. Please bet less.");
            }
            else
            {
                // Reset winnings to 0
                view.SetWinnings(0);

                // Deduct the Bet from the Coins
                model.CollectBet();
                view.SetCoinText();

                Debug.Log("Spin");
                model.SpinReels();

                view.ShowSpinButton(false);

                StartCoroutine(AutoStop(2));
            }
        }

        public void Stop()
        {
            Debug.Log("Stop");
            view.ShowSpinButton(true);
            // TODO Actual Stopping the Reels right where they are
            // TODO make sure to align the cells properly after stopping

            // TODO Compute for the winnings. May use a separate controller
            CheckWinnings();
        }

        private IEnumerator AutoStop(float duration)
        {
            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime;
                yield return null;
            }

            Stop();
        }

        private void CheckWinnings()
        {
            model.BuildResult();

            string tempName = "";
            int counter = 0;
            int winnings = 0;
            Symbol tempSymbol = null;

            for(int i = 0; i < ListLines.Count; i++)
            {
                int[] combination = ListLines[i].Combination;

                Debug.Log($"Pattern: {combination[0]} {combination[1]} {combination[2]} {combination[3]} {combination[4]} ");
                counter = 0;
                for (int j = 0; j < combination.Length; j++)
                {
                    Debug.Log($"Value from [{combination[j]}, {j}]: {model.ArrResult[combination[j], j]}");

                    if (j == 0)
                    {
                        tempName = model.ArrResult[combination[j], j];
                        // get the cell
                        tempSymbol = GetSymbol(tempName);
                        //Debug.Log($"Symbol Name {tempName}");
                    }
                    else
                    {
                        if(tempName == model.ArrResult[combination[j], j])
                        {
                            counter++;

                            if (j == combination.Length - 1)
                            {
                                Debug.Log($"Is tempSymbol NOT Null? {tempSymbol != null}");
                                if (tempSymbol != null)
                                {
                                    Debug.Log("1 Counter index: " + counter + $" Time: {Time.time} j index at {j}");
                                    winnings += tempSymbol.Payout[counter];
                                }
                                counter = 0;
                            }
                        }
                        else
                        {
                            Debug.Log($"Is tempSymbol NOT Null? {tempSymbol != null}");
                            if (tempSymbol != null)
                            {
                                Debug.Log("2 Counter index: " + counter + $" Time: {Time.time} j index at {j}");
                                winnings += tempSymbol.Payout[counter];
                            }
                            counter = 0;
                            
                            break;
                        }
                    }
                }
            }

            Debug.Log("Winnings: " + winnings * TotalBet);
            view.SetWinnings(winnings * TotalBet);
            model.CollectWinnings(winnings * TotalBet);
            view.SetCoinText();

        }

        private Symbol GetSymbol(string Name)
        {
            Debug.Log("GetSymbol - Finding Symbol Name: " + Name);
            foreach (Symbol symbol in ListSymbols)
            {
                if(symbol.SymbolName == Name)
                {
                    Debug.Log("GetSymbol - Found " + Name);
                    return symbol;
                }
            }
            Debug.Log("GetSymbol - No symbol found");
            return null;
        }
    }
}