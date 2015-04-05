using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL.FileComparer.Utilities;

namespace HL.FileComparer.Controls.EventArguments
{
    public class MatchClickEventArgs: EventArgs
    {
        public List<FileHashPair> Files { get; private set; }

        public MatchClickEventArgs(List<FileHashPair> files)
        {
            Files = files;
        }
    }
}
