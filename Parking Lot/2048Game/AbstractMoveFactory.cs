using Parking_Lot.Chess;

namespace Parking_Lot._2048Game
{
    public class AbstractMoveFactory
    {
        public AbstractMoveFactory() { }
        public static IMove GetMoveInstance(MoveDir moveDir)
        {
            IMove moveStrategy = null;
            if (moveDir == MoveDir.Left)
                moveStrategy = new LeftMoveStrategy();
            else if (moveDir == MoveDir.Right)
                moveStrategy = new RightMoveStrategy();
            else if (moveDir == MoveDir.Top)
                moveStrategy = new TopMoveStrategy();
            else
                moveStrategy = new BottomMoveStrategy();


            return moveStrategy;
        }
    }
}
