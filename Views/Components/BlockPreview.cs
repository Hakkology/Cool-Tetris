using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using AvaloniaTetris.Models;
using System.Collections.Generic;

namespace AvaloniaTetris.Views.Components
{
    public class BlockPreview : Control
    {
        public static readonly StyledProperty<Block?> BlockProperty =
            AvaloniaProperty.Register<BlockPreview, Block?>(nameof(Block));

        public Block? Block
        {
            get => GetValue(BlockProperty);
            set => SetValue(BlockProperty, value);
        }

        private readonly Dictionary<int, IBrush> _tileBrushes = new();

        public BlockPreview()
        {
            InitializeBrushes();
        }

        private void InitializeBrushes()
        {
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

        static BlockPreview()
        {
            AffectsRender<BlockPreview>(BlockProperty);
        }

        public override void Render(DrawingContext context)
        {
            if (Block == null) return;

            // Center the block in a 4x4 area
            double cellSize = Bounds.Width / 4;
            var gap = 1.0;

            foreach (var p in Block.TilesPositions())
            {
                // We need relative positions within the block for preview
                // The TilesPositions() returns absolute positions based on current state.
                // For preview, we should use the base tiles.
            }

            // Let's use the base tiles (rotation 0) for preview
            var positions = Block.GetBaseTiles();
            
            // Calculate bounds to center it
            int minR = int.MaxValue, maxR = int.MinValue;
            int minC = int.MaxValue, maxC = int.MinValue;
            foreach(var p in positions)
            {
                minR = System.Math.Min(minR, p.Row);
                maxR = System.Math.Max(maxR, p.Row);
                minC = System.Math.Min(minC, p.Column);
                maxC = System.Math.Max(maxC, p.Column);
            }

            double blockWidth = (maxC - minC + 1) * cellSize;
            double blockHeight = (maxR - minR + 1) * cellSize;
            double offsetX = (Bounds.Width - blockWidth) / 2 - minC * cellSize;
            double offsetY = (Bounds.Height - blockHeight) / 2 - minR * cellSize;

            foreach (var p in positions)
            {
                var rect = new Rect(p.Column * cellSize + offsetX + gap, p.Row * cellSize + offsetY + gap, cellSize - gap * 2, cellSize - gap * 2);
                context.DrawRectangle(_tileBrushes[Block.ID], null, rect, 4);
                
                var shineRect = new Rect(p.Column * cellSize + offsetX + gap + 2, p.Row * cellSize + offsetY + gap + 2, (cellSize - gap * 2)/2, (cellSize - gap * 2)/3);
                context.DrawRectangle(new SolidColorBrush(Colors.White, 0.2), null, shineRect, 2);
            }
        }
    }
}
