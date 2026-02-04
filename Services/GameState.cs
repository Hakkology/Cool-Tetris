using AvaloniaTetris.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaTetris.Services
{
    public partial class GameState : ObservableObject
    {
        private Block currentBlock = null!;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
                OnPropertyChanged(nameof(CurrentBlock));
            }
        }

        [ObservableProperty]
        private GameGrid _gameGrid;

        [ObservableProperty]
        private BlockQueue _blockQueue;

        [ObservableProperty]
        private bool _gameOver;

        [ObservableProperty]
        private int _score;

        [ObservableProperty]
        private Block? _heldBlock;

        [ObservableProperty]
        private bool _canHold;

        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }

        public bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilesPositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void Restart()
        {
            GameGrid.ClearFullRows(); // This doesn't really clear the whole grid
            for (int r = 0; r < GameGrid.Rows; r++)
            {
                for (int c = 0; c < GameGrid.Columns; c++)
                {
                    GameGrid[r, c] = 0;
                }
            }
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            HeldBlock = null;
            CanHold = true;
            Score = 0;
            GameOver = false;
        }

        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }
            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else
            {
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }

            CanHold = false;
        }

        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
            OnPropertyChanged(nameof(CurrentBlock));
        }

        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
            OnPropertyChanged(nameof(CurrentBlock));
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
            OnPropertyChanged(nameof(CurrentBlock));
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
            OnPropertyChanged(nameof(CurrentBlock));
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
            OnPropertyChanged(nameof(CurrentBlock));
        }

        public bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilesPositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.ID;
            }

            Score += GameGrid.ClearFullRows();
            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }
        }

        private int TileDropDistance(Position p)
        {
            int drop = 0;
            while (GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;
            foreach (Position p in CurrentBlock.TilesPositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }
            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
            OnPropertyChanged(nameof(CurrentBlock));
        }
    }
}
