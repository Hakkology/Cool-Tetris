using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaTetris.ViewModels;

namespace AvaloniaTetris.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (DataContext is MainWindowViewModel mainVM && mainVM.CurrentViewModel is GameViewModel gameVM)
            {
                switch (e.Key)
                {
                    case Key.Left:
                        gameVM.MoveLeftCommand.Execute(null);
                        break;
                    case Key.Right:
                        gameVM.MoveRightCommand.Execute(null);
                        break;
                    case Key.Down:
                        gameVM.MoveDownCommand.Execute(null);
                        break;
                    case Key.Up:
                        gameVM.RotateCWCommand.Execute(null);
                        break;
                    case Key.Z:
                        gameVM.RotateCCWCommand.Execute(null);
                        break;
                    case Key.Space:
                        gameVM.DropCommand.Execute(null);
                        break;
                    case Key.C:
                        gameVM.HoldCommand.Execute(null);
                        break;
                }
            }
        }
    }
}