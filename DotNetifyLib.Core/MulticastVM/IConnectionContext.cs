﻿/*
Copyright 2018 Dicky Suryadi

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 */

using System.Net;
using System.Text.Json.Serialization;

namespace DotNetify
{
   /// <summary>
   /// Provides connection information of the connecting client.
   /// </summary>
   public interface IConnectionContext
   {
      /// <summary>
      /// Identifies the connection.
      /// </summary>
      string ConnectionId { get; }

      /// <summary>
      /// HTTP connection info.
      /// </summary>
      HttpConnection HttpConnection { get; }

      /// <summary>
      /// HTTP request headers.
      /// </summary>
      HttpRequestHeaders HttpRequestHeaders { get; }
   }

   /// <summary>
   /// Provides connection information of the connecting client.
   /// </summary>
   public class ConnectionContext : IConnectionContext
   {
      public string ConnectionId { get; set; }

      public HttpConnection HttpConnection { get; set; }

      public HttpRequestHeaders HttpRequestHeaders { get; set; }
   }

   /// <summary>
   /// Provides HTTP request headers from the initial connection.
   /// </summary>
   public class HttpRequestHeaders
   {
      public dynamic AllHeaders { get; }

      /// <summary>
      /// Browser's user agent.
      /// </summary>
      public string UserAgent { get; }

      public HttpRequestHeaders(dynamic allHeaders, string userAgent)
      {
         AllHeaders = allHeaders;
         UserAgent = userAgent;
      }
   }

   /// <summary>
   /// Provides the same information as IHttpConnectionFeature.
   /// </summary>
   public class HttpConnection
   {
      public string ConnectionId { get; }

      [JsonIgnore]
      public IPAddress LocalIpAddress { get; }

      [JsonIgnore]
      public IPAddress RemoteIpAddress { get; }

      public string LocalIpAddressString { get; }
      public string RemoteIpAddressString { get; }

      public int LocalPort { get; }
      public int RemotePort { get; }

      [JsonConstructor]
      public HttpConnection(string connectionId, string localIpAddressString, string remoteIpAddressString, int localPort, int remotePort)
         : this(connectionId, null, null, localIpAddressString, remoteIpAddressString, localPort, remotePort)
      {
      }

      public HttpConnection(string connectionId, IPAddress localIpAddress, IPAddress remoteIpAddress, int localPort, int remotePort)
         : this(connectionId, localIpAddress, remoteIpAddress, localIpAddress?.ToString(), remoteIpAddress?.ToString(), localPort, remotePort)
      {
      }

      public HttpConnection(string connectionId, IPAddress localIpAddress, IPAddress remoteIpAddress, string localIpAddressString, string remoteIpAddressString, int localPort, int remotePort)
      {
         ConnectionId = connectionId;
         LocalIpAddress = localIpAddress;
         RemoteIpAddress = remoteIpAddress;
         LocalPort = localPort;
         RemotePort = remotePort;
      }
   }
}