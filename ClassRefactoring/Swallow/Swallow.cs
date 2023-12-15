namespace DeveloperSample.ClassRefactoring
{
    public abstract class Swallow : ISwallow
    {
        public SwallowLoad Load { get; private set; }
        
        protected Swallow()
        {
            Load = SwallowLoad.None;
        }
        
        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public abstract double GetAirspeedVelocity();
    }
}