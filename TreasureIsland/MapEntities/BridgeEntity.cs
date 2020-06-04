using System;
using System.Collections.Generic;
using System.Text;

namespace TreasureIsland
{
    public class BridgeEntity : MapEntity
    {
        public BridgeEntity()
        {
            parser = new ParseOnePoint();
            printer = new PrintBridge();
        }
    }
}
