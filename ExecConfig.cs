using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerWinSCP
{
    /**
     * Bean class of the ExecConfig for JSON serialization
     **/
    class ExecConfig
    {
        public Boolean AttachStdin = true;
        public Boolean AttachStdout = true;
        public Boolean AttachStderr = true;
        public string[] Cmd;
        public string DetachKeys = "ctrl-p,ctrl-q";
        public Boolean Privileged = true;
        public Boolean Tty = true;
        public string User = "root";
    }
}
