using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // Multi Requests
        Dictionary<string, string> posts = GetPosts();
        Dictionary<string, Dictionary<string, string>> res = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, HttpWebRequest> ch = new Dictionary<string, HttpWebRequest>();
        HttpWebRequest wr;
        foreach (KeyValuePair<string, string> post in posts)
        {
            wr = (HttpWebRequest)WebRequest.Create("https://tools.google.com/service/update2");
            wr.Method = "POST";
            byte[] postBytes = Encoding.ASCII.GetBytes(post.Value);
            wr.ContentType = "text/xml";
            wr.ContentLength = postBytes.Length;
            Stream requestStream = wr.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();
            ch[post.Key] = wr;
        }

        HttpWebResponse response;
        Stream streamResponse;
        StreamReader streamReader;
        foreach (KeyValuePair<string, HttpWebRequest> req in ch)
        {
            response = (HttpWebResponse)req.Value.GetResponse();
            streamResponse = response.GetResponseStream();
            streamReader = new StreamReader(streamResponse);
            string content = streamReader.ReadToEnd();
            res[req.Key] = new Dictionary<string, string>(){
                { "error", "" },
                { "content", content }
            };
            response.Close();
            streamResponse.Close();
            streamReader.Close();
        }

        // XML to Array
        foreach (KeyValuePair<string, Dictionary<string, string>> r in res)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Request));
            using (TextReader reader = new StringReader(r.Value["content"]))
            {
                Request request = (Request)serializer.Deserialize(reader);
                if (!string.IsNullOrEmpty(r.Value["error"]))
                {
                    // Handle error
                }
                else
                {
                    // Do something with the request object
                }
            }
        }
    }

    static Dictionary<string, string> GetPosts()
    {
        Dictionary<string, string> posts = new Dictionary<string, string>();
        Dictionary<string, string[]> platforms = new Dictionary<string, string[]>(){
            { "win", new string[]{ "x64", "x86" } },
            { "mac", new string
