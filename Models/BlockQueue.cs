using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace AvaloniaTetris.Models
{
    public partial class BlockQueue : ObservableObject
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };

        private readonly Random random = new Random();

        [ObservableProperty]
        private Block _nextBlock;

        public BlockQueue()
        {
            _nextBlock = RandomBlock();
        }

        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            do
            {
                NextBlock = RandomBlock();
            } while (block.ID == NextBlock.ID);

            return block;
        }
    }
}
