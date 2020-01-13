using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Greatzee.Spider.Core
{
    public class HtmlStorage
    {
        /// <summary>
        /// 发送给Socket
        /// </summary>
        /// <param name="socketAddress"></param>
        /// <param name="bytes"></param>
        public void SendToSocket(string socketAddress, byte[] bytes)
        {
            try
            {
                string[] addressArray = socketAddress.Split(':');
                string address = addressArray[0];
                if (address == "localhost")
                {
                    address = "127.0.0.1";
                }
                string port = "80";
                if (addressArray.Length > 1)
                {
                    port = addressArray[1];
                }
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(address), int.Parse(port));
                Socket socketClient = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socketClient.Connect(endPoint);
                socketClient.Send(bytes);
            }
            catch { }
        }

        /// <summary>
        /// 发送给webapi
        /// </summary>
        /// <param name="url"></param>
        /// <param name="bytes"></param>
        public void SendToWebApi(string url, byte[] bytes)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Timeout = 1000 * 10;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = bytes.Length;
                webRequest.KeepAlive = true;
                using (Stream stream = webRequest.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch { }
        }

        /// <summary>
        /// 保存到本地
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        public void SaveFile(string path, byte[] bytes)
        {
            try
            {
                string fileName = Guid.NewGuid().ToString() + ".html";
                string savePath = Path.Combine(path, fileName);
                using (FileStream fs = new FileStream(savePath, FileMode.CreateNew))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch { }
        }

        /// <summary>
        /// 执行配置的socket存储,webapi存储,本地文件存储
        /// </summary>
        /// <param name="socketAddress"></param>
        /// <param name="webapi"></param>
        /// <param name="directoryPath"></param>
        /// <param name="bytes"></param>
        public void ExecuteStorage(string socketAddress, string webapi, string directoryPath, byte[] bytes)
        {
            if (!string.IsNullOrEmpty(socketAddress))
            {
                this.SendToSocket(socketAddress, bytes);
            }
            if (!string.IsNullOrEmpty(webapi))
            {
                this.SendToWebApi(webapi, bytes);
            }
            if (!string.IsNullOrEmpty(directoryPath))
            {
                this.SaveFile(directoryPath, bytes);
            }
        }

    }
}
