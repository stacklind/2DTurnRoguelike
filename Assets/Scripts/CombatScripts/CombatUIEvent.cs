public class CombatUIEvent
{
    public class ShowMoveToolTipEvent
    {
        public readonly Move Move;
        
        public ShowMoveToolTipEvent(Move move)
        {
            Move = move;
        }
    }

    public class ClearToolTipEvent
    {
        public ClearToolTipEvent()
        {
        }
    }
}
