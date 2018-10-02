using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace DockerWinSCP
{
    /**
     * Docker REST client
     **/
    class DockerRestClient
    {
        private static readonly string URL_DOCKER = "http://localhost:2375";

        public static Image[] getImages()
        {
            var client = new RestClient(URL_DOCKER);

            var request = new RestRequest("images/json", Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Image[] deserializedImages = JsonConvert.DeserializeObject<Image[]>(content);

            return deserializedImages;
        }

        public static Container[] getContainers(string imageName)
        {
            var client = new RestClient(URL_DOCKER);

            var request = new RestRequest("containers/json?filters={\"ancestor\":[\"" + imageName + "\"]}", Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Container[] deserializedContainers = JsonConvert.DeserializeObject<Container[]>(content);

            return deserializedContainers;
        }

        public static string getDirectoryListing(string containerId, string path)
        {
            var client = new RestClient(URL_DOCKER);

            var request = new RestRequest("containers/{containerId}/exec", Method.POST);

            ExecConfig execConfig = new ExecConfig();
            execConfig.Cmd = new string[] { "ls", "-l", path };

            request.AddJsonBody(execConfig); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("containerId", containerId); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("Content-Type", "application/json");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            ExecId execId = JsonConvert.DeserializeObject<ExecId>(content);

            request = new RestRequest("exec/{execId}/start", Method.POST);

            ExecStart execStart = new ExecStart();
            execStart.Detach = false;
            execStart.Tty = true;

            request.AddJsonBody(execStart); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("execId", execId.Id); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("Content-Type", "application/json");

            // execute the request
            response = client.Execute(request);
            content = response.Content;

            return content;
        }
    }
}
