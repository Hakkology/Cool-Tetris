using AvaloniaTetris.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;

namespace AvaloniaTetris.ViewModels
{
    public partial class GameViewModel : ViewModelBase
    {
        [ObservableProperty]
        private GameState _gameState;

        public event Action? BackToMenuRequested;

        private bool _isRunning;

        public GameViewModel(GameState gameState)
        {
            _gameState = gameState;
        }

        [RelayCommand]
        public async Task StartGame()
        {
            if (_isRunning) return;
            
            if (GameState.GameOver)
            {
                GameState.Restart();
            }

            _isRunning = true;

            try
            {
                while (_isRunning && !GameState.GameOver)
                {
                    await Task.Delay(500); // Game speed
                    if (!_isRunning || GameState.GameOver) break;
                    GameState.MoveBlockDown();
                }
            }
            finally
            {
                _isRunning = false;
            }
        }

        [RelayCommand]
        public async Task Restart()
        {
            _isRunning = false;
            // Wait for existing loop to terminate
            await Task.Delay(600);
            GameState.Restart();
            _ = StartGame();
        }

        [RelayCommand]
        public void MoveLeft() => GameState.MoveBlockLeft();

        [RelayCommand]
        public void MoveRight() => GameState.MoveBlockRight();

        [RelayCommand]
        public void MoveDown() => GameState.MoveBlockDown();

        [RelayCommand]
        public void RotateCW() => GameState.RotateBlockCW();

        [RelayCommand]
        public void RotateCCW() => GameState.RotateBlockCCW();

        [RelayCommand]
        public void Drop() => GameState.DropBlock();

        [RelayCommand]
        public void Hold() => GameState.HoldBlock();

        [RelayCommand]
        public void BackToMenu()
        {
            _isRunning = false;
            BackToMenuRequested?.Invoke();
        }
    }
}
