

namespace TubesV3
{
    // Kontrak semua perintah
    public interface ICommand
    {
        void Execute();
    }

    // Helper: cukup bungkus Action agar tidak perlu bikin kelas command penuh
    public class LambdaCommand : ICommand
    {
        private readonly Action _action;
        public LambdaCommand(Action action) => _action = action;
        public void Execute() => _action();
    }
}
