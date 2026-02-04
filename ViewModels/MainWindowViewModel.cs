using AvaloniaTetris.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace AvaloniaTetris.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _currentViewModel;

        private readonly MenuViewModel _menuViewModel;
        private readonly GameViewModel _gameViewModel;

        public MainWindowViewModel()
        {
            _menuViewModel = new MenuViewModel();
            _gameViewModel = new GameViewModel(new GameState());

            _menuViewModel.StartGameRequested += OnStartGameRequested;
            
            _currentViewModel = _menuViewModel;
        }

        private void OnStartGameRequested()
        {
            CurrentViewModel = _gameViewModel;
            _ = _gameViewModel.StartGame();
        }
    }
}
