using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace TubesV3
{
    /// <summary> Kontrak untuk semua perintah. </summary>
    // Interface dengan tanggung jawab tunggal
    public interface ICommand
    {
        void Execute();
    }

    /// <summary>
    /// Membungkus Action menjadi perintah yang bisa dieksekusi.
    /// </summary>
    /// Mengubah Action menjadi implementasi command pattern
    public class LambdaCommand : ICommand
    {
        private readonly Action _action;
        public LambdaCommand(Action action) => _action = action;
        public void Execute() => _action();
    }
}
