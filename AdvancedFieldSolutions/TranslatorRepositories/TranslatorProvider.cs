namespace AdvancedFieldSolutions.TranslatorRepositories
{
    public abstract class TranslatorProvider
    {
        public abstract Task<bool> CallClientAsync(string text);
    }
}
