using UnityEngine;

namespace SlotMachine
{
    public class ControllerAccess : MonoBehaviour
    {
        protected ControllerList Controllers => GameMain.Instance.Controllers;
    }
}