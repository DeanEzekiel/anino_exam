using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SlotMachine
{
    public class View : MonoBehaviour
    {
        [SerializeField]
        Controller controller;

        [Header("Coins Section")]
        [SerializeField]
        TextMeshProUGUI txtCoins;

        [Header("Spin Section")]
        [SerializeField]
        Button btnSpin;
        [SerializeField]
        Button btnStop;

        [Header("Bet Section")]
        [SerializeField]
        Button btnBetLess;
        [SerializeField]
        Button btnBetMore;
        [SerializeField]
        TextMeshProUGUI txtTotalBet;

        [Header("Wins Section")]
        [SerializeField]
        TextMeshProUGUI txtWins;

        private void Start()
        {
            btnBetMore.onClick.AddListener(delegate { controller.BetMore(); });
            btnBetLess.onClick.AddListener(delegate { controller.BetLess(); });

            btnSpin.onClick.AddListener(delegate { controller.Spin(); });
            btnStop.onClick.AddListener(delegate { controller.Stop(); });
        }

        public void ShowSpinButton(bool toShow)
        {
            btnSpin.gameObject.SetActive(toShow);
            //btnStop.gameObject.SetActive(!toShow); // TODO
        }

        public void SetCoinText()
        {
            txtCoins.text = controller.Coins.ToString();
        }

        public void SetTotalBetText()
        {
            txtTotalBet.text = controller.TotalBet.ToString();
        }

        public void SetWinnings(int coinsWon)
        {
            txtWins.text = coinsWon.ToString();
        }
    }
}