namespace DeveloperSample.ClassRefactoring
{
    public class AfricanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 22,
                SwallowLoad.Coconut => 18,
                _ => throw new UnsupportedSwallowLoadException(Load)
            };
        }
    }
}