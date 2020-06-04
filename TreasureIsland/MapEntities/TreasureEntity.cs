using System;
using System.Collections.Generic;
using System.Text;

namespace TreasureIsland
{
    public class TreasureEntity : MapEntity
    {
        public TreasureEntity()
        {
            parser = new ParseOnePoint();
            printer = new PrintTreasure();
        }
    }
}
