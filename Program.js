import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {
    public static void main(String[] args) {
        Map<String, String[]> platforms = new HashMap<>();
        platforms.put("win", new String[] { "x64", "x86" });
        platforms.put("mac", new String[] { "x64" });

        String[] channels = new String[] { "stable", "beta", "dev", "canary" };

        Map<String, String> versions = new HashMap<>();
        versions.put("win", "10.0");
        versions.put("mac", "46.0.2490.86");

        Map<String, String> appids = new HashMap<>();
        appids.put("win_stable", "{8A69D345-D564-463C-AFF1-A69D9E530F96}");
        appids.put("win_beta", "{8A69D345-D564-463C-AFF1-A69D9E530F96}");
        appids.put("win_dev", "{8A69D345-D564-463C-AFF1-A69D9E530F96}");
        appids.put("win_canary", "{4EA16AC7-FD5A-47C3-875B-DBF4A2008C20}");
        appids.put("mac_stable", "com.google.Chrome");
        appids.put("mac_beta", "com.google.Chrome.Beta");
        appids.put("mac_dev", "com.google.Chrome.Dev");
        appids.put("mac_canary", "com.google.Chrome.Canary");

        Map<String, String> aps = new HashMap<>();
        aps.put("win_stable_x86", "-multi-chrome");
        aps.put("win_stable_x64", "x64-stable-multi-chrome");
        aps.put("win_beta_x86", "1.1-beta");
        aps.put("win_beta_x64", "x64-beta-multi-chrome");
        aps.put("win_dev_x86", "2.0-dev");
        aps.put("win_dev_x64", "x64-dev-multi-chrome");
        aps.put("win_canary_x86", "");
        aps.put("win
