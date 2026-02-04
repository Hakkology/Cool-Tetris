namespace AvaloniaTetris.Models
{
    public class IBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(1,0), new(1,1), new(1,2), new(1,3)},
            new Position[] {new(0,2), new(1,2), new(2,2), new(3,2)},
            new Position[] {new(2,0), new(2,1), new(2,2), new(2,3)},
            new Position[] {new(0,1), new(1,1), new(2,1), new(3,1)}
        };

        public override int ID => 1;
        protected override Position StartOffset => new Position(-1, 3);
        protected override Position[][] Tiles => tiles;
    }

    public class JBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,0), new(1,0), new(1,1), new(1,2)},
            new Position[] {new(0,1), new(0,2), new(1,1), new(2,1)},
            new Position[] {new(1,0), new(1,1), new(1,2), new(2,2)},
            new Position[] {new(0,1), new(1,1), new(2,1), new(2,0)}
        };

        public override int ID => 2;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }

    public class LBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,2), new(1,0), new(1,1), new(1,2)},
            new Position[] {new(0,1), new(1,1), new(2,1), new(2,2)},
            new Position[] {new(1,0), new(1,1), new(1,2), new(2,0)},
            new Position[] {new(0,0), new(0,1), new(1,1), new(2,1)}
        };

        public override int ID => 3;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }

    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,0), new(0,1), new(1,0), new(1,1)}
        };

        public override int ID => 4;
        protected override Position StartOffset => new Position(0, 4);
        protected override Position[][] Tiles => tiles;
    }

    public class SBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,1), new(0,2), new(1,0), new(1,1)},
            new Position[] {new(0,1), new(1,1), new(1,2), new(2,2)},
            new Position[] {new(1,1), new(1,2), new(2,0), new(2,1)},
            new Position[] {new(0,0), new(1,0), new(1,1), new(2,1)}
        };

        public override int ID => 5;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }

    public class TBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,1), new(1,0), new(1,1), new(1,2)},
            new Position[] {new(0,1), new(1,1), new(1,2), new(2,1)},
            new Position[] {new(1,0), new(1,1), new(1,2), new(2,1)},
            new Position[] {new(0,1), new(1,0), new(1,1), new(2,1)}
        };

        public override int ID => 6;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }

    public class ZBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,0), new(0,1), new(1,1), new(1,2)},
            new Position[] {new(0,2), new(1,1), new(1,2), new(2,1)},
            new Position[] {new(1,0), new(1,1), new(2,1), new(2,2)},
            new Position[] {new(0,1), new(1,0), new(1,1), new(2,0)}
        };

        public override int ID => 7;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
