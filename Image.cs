using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerWinSCP
{
    /**
     * Bean class of the image data for JSON deserialization
     **/
    class Image
    {
        public string Id;
        public string Created;
        public string[] RepoTags = { "No name" };
        public string Size;
    }
}
