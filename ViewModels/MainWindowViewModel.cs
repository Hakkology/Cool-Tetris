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
            _menuViewModel.ExitRequested += OnExitRequested;
            _menuViewModel.AboutRequested += OnAboutRequested;
            _gameViewModel.BackToMenuRequested += OnBackToMenuRequested;
            
            _currentViewModel = _menuViewModel;
        }

        private void OnAboutRequested()
        {
            var aboutWin = new Views.AboutWindow();
            if (Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
            {
                aboutWin.ShowDialog(desktop.MainWindow!);
            }
        }

        private void OnExitRequested()
        {
            if (Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }

        private void OnBackToMenuRequested()
        {
            CurrentViewModel = _menuViewModel;
        }

        private void OnStartGameRequested()
        {
            CurrentViewModel = _gameViewModel;
            _ = _gameViewModel.StartGame();
        }
    }
}
