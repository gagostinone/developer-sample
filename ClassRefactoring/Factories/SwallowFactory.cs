namespace DeveloperSample.ClassRefactoring
{
    public class SwallowFactory : ISwallowFactory
    {
        public ISwallow GetSwallow(SwallowType swallowType)
        {
            return swallowType switch
            {
                SwallowType.European => new EuropeanSwallow(),
                SwallowType.African => new AfricanSwallow(),
                _ => throw new UnsupportedSwallowTypeException(swallowType)
            };
        }
    }
}