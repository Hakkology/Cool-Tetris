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

            while (_isRunning && !GameState.GameOver)
            {
                await Task.Delay(500); // Game speed
                if (!_isRunning) break;
                GameState.MoveBlockDown();
            }

            _isRunning = false;
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
    }
}
