using System;
namespace Xacml.Parsing
{
    public interface IProductionSwitch
    {
        void Case(TokenDefinition tokenDefinition, Action<IProductionStep> body);
        void SetDefault(Action<IProductionStep> body);
    }
}
