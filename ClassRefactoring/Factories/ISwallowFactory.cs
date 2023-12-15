namespace DeveloperSample.ClassRefactoring
{
    public interface ISwallowFactory
    {
        public ISwallow GetSwallow(SwallowType swallowType);
    }
}