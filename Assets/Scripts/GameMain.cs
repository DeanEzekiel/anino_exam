namespace SlotMachine
{
    public class GameMain : ASingleton<GameMain>
    {
        public ControllerList Controllers;

        public SymbolList Symbols;
        public LineList Lines;
    }
}