using System;
using System.Collections.Generic;
namespace Xacml.Parsing
{
    public interface IProductionStep
    {
        void Call(int productionId);
        void Expect(TokenDefinition tokenDefinition);
        void Switch(Action<ProductionSwitch> switchStatement);
        bool LookaheadEquals(TokenDefinition tokenDefinition);
        IEnumerable<Token> LookAhead(int count);
        Token Peek();
    }
}
