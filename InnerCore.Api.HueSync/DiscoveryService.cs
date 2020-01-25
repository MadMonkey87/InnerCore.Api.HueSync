using InnerCore.Api.HueSync.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using InnerCore.Api.HueSync.Extensions;

namespace InnerCore.Api.HueSync
{
	public static class DiscoveryService
	{
        private const int port = 8888;
        private const string discoveryRequest = "{\"operation\": null}";

		public static async Task<IEnumerable<DiscoveryResult>> Discover(CancellationToken cancellationToken)
		{
			var result = new List<DiscoveryResult>();

            using(var client = new UdpClient(port))
            {
                try
                {
                    var discoveryMessage = Encoding.ASCII.GetBytes(discoveryRequest);
                    await client
                        .SendAsync(discoveryMessage, discoveryMessage.Length, new IPEndPoint(IPAddress.Broadcast, port))
                        .WithCancellation(cancellationToken);

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var receiveResult = await client.ReceiveAsync().WithCancellation(cancellationToken);
                        var clientRequest = Encoding.ASCII.GetString(receiveResult.Buffer);

                        try
                        {
                            var discoveryResult = JsonConvert.DeserializeObject<DiscoveryResult>(clientRequest);
                            discoveryResult.IpAddress = receiveResult.RemoteEndPoint.Address.ToString();
                            result.Add(discoveryResult);
                        }
                        catch (JsonSerializationException ex)
                        {
                            // at that point we received an invalid message, usually this is just our own discovery message or someone other than a hue sync box
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    client.Close();
                }
            }

            return result.ToArray();
		}
    }
}
