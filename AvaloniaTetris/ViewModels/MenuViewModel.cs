using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace AvaloniaTetris.ViewModels
{
    public partial class MenuViewModel : ViewModelBase
    {
        public event Action? StartGameRequested;
        public event Action? ExitRequested;

        [RelayCommand]
        public void StartGame() => StartGameRequested?.Invoke();

        [RelayCommand]
        public void Exit() => ExitRequested?.Invoke();
    }
}
