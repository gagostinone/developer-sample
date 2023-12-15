namespace DeveloperSample.ClassRefactoring
{
    public class EuropeanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 20,
                SwallowLoad.Coconut => 16,
                _ => throw new UnsupportedSwallowLoadException(Load)
            };
        }
    }
}