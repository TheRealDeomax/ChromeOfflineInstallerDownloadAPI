using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // comment
    }

    public static Dictionary<string, string> getPosts()
    {
        Dictionary<string, string[]> platforms = new Dictionary<string, string[]>()
        {
            {"win", new string[] { "x64", "x86" } },
            {"mac", new string[] { "x64" } }
        };
        string[] channels = new string[] { "stable", "beta", "dev", "canary" };
        Dictionary<string, string> vers = new Dictionary<string, string>()
        {
            {"win", "10.0" },
            {"mac", "46.0.2490.86" }
        };
        Dictionary<string, string> appids = new Dictionary<string, string>()
        {
            {"win_stable", "{8A69D345-D564-463C-AFF1-A69D9E530F96}" },
            {"win_beta", "{8A69D345-D564-463C-AFF1-A69D9E530F96}" },
            {"win_dev", "{8A69D345-D564-463C-AFF1-A69D9E530F96}" },
            {"win_canary", "{4EA16AC7-FD5A-47C3-875B-DBF4A2008C20}" },
            {"mac_stable", "com.google.Chrome" },
            {"mac_beta", "com.google.Chrome.Beta" },
            {"mac_dev", "com.google.Chrome.Dev" },
            {"mac_canary", "com.google.Chrome.Canary" }
        };
        Dictionary<string, string> aps = new Dictionary<string, string>()
        {
            {"win_stable_x86", "-multi-chrome" },
            {"win_stable_x64", "x64-stable-multi-chrome" },
            {"win_beta_x86", "1.1-beta" },
            {"win_beta_x64", "x64-beta-multi-chrome" },
            {"win_dev_x86", "2.0-dev" },
            {"win_dev_x64", "x64-dev-multi-chrome" },
            {"win_canary_x86", "" },
            {"win_canary_x64", "x64-canary" },
            {"mac_stable_x86", "" },
            {"mac_stable_x64", "" },
            {"mac_beta_x86", "betachannel" },
            {"mac_beta_x64", "betachannel" },
            {"mac_dev_x86", "devchannel" },
            {"mac_dev_x64", "devchannel" },
            {"mac_canary_x86", "" },
            {"mac_canary_x64", "" }
        };

        Dictionary<string, string> posts = new Dictionary<string, string>();
        foreach (KeyValuePair<string, string[]> kvp in platforms)
        {
            string os = kvp.Key;
            foreach (string channel in channels)
            {
                foreach (string arch in kvp.Value)
                {
                    string ver = vers[os];
                    string appid = appids[os + "_" + channel];
                    string ap = aps[os + "_" + channel + "_" + arch];

                    string postdata = @"<?xml version='1.0' encoding='UTF-8'?>
                                        <request protocol='3.0' version='1.3.23.9' shell_version='1.3.21.103' ismachine='0'
                                            sessionid='{3597644B-2952
