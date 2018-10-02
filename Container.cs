using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerWinSCP
{
    /**
     * Bean class of the container data for JSON deserialization
     **/
    class Container
    {
        public string Id;
        public string[] Names;
        public string Command;
        public string State;
        public string Status;
        public HostConfig HostConfig;
        public NetworkSettings NetworkSettings;
    }
}
