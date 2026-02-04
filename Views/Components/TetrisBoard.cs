using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaTetris.Models;
using AvaloniaTetris.Services;
using System.Collections.Generic;

namespace AvaloniaTetris.Views.Components
{
    public class TetrisBoard : Control
    {
        public static readonly StyledProperty<GameState> GameStateProperty =
            AvaloniaProperty.Register<TetrisBoard, GameState>(nameof(GameState));

        public GameState GameState
        {
            get => GetValue(GameStateProperty);
            set => SetValue(GameStateProperty, value);
        }

        private readonly Dictionary<int, IBrush> _tileBrushes = new();

        private void InitializeBrushes()
        {
            _tileBrushes[0] = new SolidColorBrush(Color.Parse("#1A1A1A"));
            _tileBrushes[1] = CreateGradientBrush("#00F2FF", "#0066FF"); // I
            _tileBrushes[2] = CreateGradientBrush("#0066FF", "#0033CC"); // J
            _tileBrushes[3] = CreateGradientBrush("#FF9900", "#CC6600"); // L
            _tileBrushes[4] = CreateGradientBrush("#FFFF00", "#CCCC00"); // O
            _tileBrushes[5] = CreateGradientBrush("#00FF00", "#009900"); // S
            _tileBrushes[6] = CreateGradientBrush("#CC00FF", "#9900CC"); // T
            _tileBrushes[7] = CreateGradientBrush("#FF0033", "#CC0000"); // Z
        }

        private LinearGradientBrush CreateGradientBrush(string startColor, string endColor)
        {
            var brush = new LinearGradientBrush
            {
                StartPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
                EndPoint = new RelativePoint(1, 1, RelativeUnit.Relative)
            };
            brush.GradientStops.Add(new GradientStop(Color.Parse(startColor), 0));
            brush.GradientStops.Add(new GradientStop(Color.Parse(endColor), 1));
            return brush;
        }

        public TetrisBoard()
        {
            InitializeBrushes();
            ClipToBounds = true;
        }

        private static GradientStop newGradientStop(Color color, double offset) => new(color, offset);

        static TetrisBoard()
        {
            AffectsRender<TetrisBoard>(GameStateProperty);
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == GameStateProperty)
            {
                if (change.OldValue is GameState oldState)
                    oldState.PropertyChanged -= OnGameStatePropertyChanged;
                if (change.NewValue is GameState newState)
                    newState.PropertyChanged += OnGameStatePropertyChanged;
            }
        }

        private void OnGameStatePropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvalidateVisual();
        }

        public override void Render(DrawingContext context)
        {
            if (GameState == null) return;

            double tileSize = Bounds.Width / GameState.GameGrid.Columns;
            var gap = 1.0;

            // Draw Background Grid
            for (int r = 2; r < GameState.GameGrid.Rows; r++)
            {
                for (int c = 0; c < GameState.GameGrid.Columns; c++)
                {
                    var id = GameState.GameGrid[r, c];
                    DrawTile(context, r - 2, c, id, tileSize, gap);
                }
            }

            // Draw Ghost Block
            int drop = GameState.BlockDropDistance();
            using (context.PushOpacity(0.2))
            {
                foreach (var p in GameState.CurrentBlock.TilesPositions())
                {
                    if (p.Row + drop >= 2)
                    {
                        DrawTile(context, (p.Row + drop) - 2, p.Column, GameState.CurrentBlock.ID, tileSize, gap);
                    }
                }
            }

            // Draw Current Block
            foreach (var p in GameState.CurrentBlock.TilesPositions())
            {
                if (p.Row >= 2)
                {
                    DrawTile(context, p.Row - 2, p.Column, GameState.CurrentBlock.ID, tileSize, gap);
                }
            }
            
            // Draw Ghost Block (TODO)
        }

        private void DrawTile(DrawingContext context, int r, int c, int id, double size, double gap)
        {
            if (id == 0)
            {
                // Draw empty tile with subtle border
                var rect = new Rect(c * size + gap, r * size + gap, size - gap * 2, size - gap * 2);
                context.DrawRectangle(_tileBrushes[0], new Pen(Brushes.DimGray, 0.1), rect, 4);
                return;
            }

            if (id > 0)
            {
                var rect = new Rect(c * size + gap, r * size + gap, size - gap * 2, size - gap * 2);
                var brush = _tileBrushes[id];
                context.DrawRectangle(brush, null, rect, 4);
                
                // Add a subtle glow/shine effect
                var shineRect = new Rect(c * size + gap + 2, r * size + gap + 2, (size - gap * 2)/2, (size - gap * 2)/3);
                context.DrawRectangle(new SolidColorBrush(Colors.White, 0.2), null, shineRect, 2);
            }
        }
    }
}
