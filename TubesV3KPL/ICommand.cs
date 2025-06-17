using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    /// <summary>
    /// Blueprint dasar untuk semua command/perintah
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Menjalankan aksi utama dari command
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// Command sederhana yang membungkus Action
    /// </summary>
    public class LambdaCommand : ICommand
    {
        private readonly Action _action;

        /// <summary>
        /// Membuat command dari Action
        /// </summary>
        public LambdaCommand(Action action) => _action = action;

        /// <summary>
        /// Menjalankan action yang sudah disimpan
        /// </summary>
        public void Execute() => _action();
    }
}
