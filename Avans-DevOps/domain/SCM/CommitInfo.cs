using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.domain.SCM
{
    public class CommitInfo
    {
        public string Hash { get; }

        public string Message { get; }

        public CommitInfo(string hash, string message)
        {
            Hash = hash;
            Message = message;
        }
    }
}
