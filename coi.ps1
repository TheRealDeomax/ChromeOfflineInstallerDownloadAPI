function Get-Posts {
    $platforms = @{
    'win' = @('x64', 'x86')
    'mac' = @('x64')
    }
    $channels = @('stable', 'beta', 'dev', 'canary')
    $vers = @{
    'win' = '10.0'
    'mac' = '46.0.2490.86'
    }
    $appids = @{
    'win_stable' = '{8A69D345-D564-463C-AFF1-A69D9E530F96}'
    'win_beta' = '{8A69D345-D564-463C-AFF1-A69D9E530F96}'
    'win_dev' = '{8A69D345-D564-463C-AFF1-A69D9E530F96}'
    'win_canary' = '{4EA16AC7-FD5A-47C3-875B-DBF4A2008C20}'
    'mac_stable' = 'com.google.Chrome'
    'mac_beta' = 'com.google.Chrome.Beta'
    'mac_dev' = 'com.google.Chrome.Dev'
    'mac_canary' = 'com.google.Chrome.Canary'
    }
    $aps = @{
    'win_stable_x86' = '-multi-chrome'
    'win_stable_x64' = 'x64-stable-multi-chrome'
    'win_beta_x86' = '1.1-beta'
    'win_beta_x64' = 'x64-beta-multi-chrome'
    'win_dev_x86' = '2.0-dev'
    'win_dev_x64' = 'x64-dev-multi-chrome'
    'win_canary_x86' = ''
    'win_canary_x64' = 'x64-canary'
    'mac_stable_x86' = ''
    'mac_stable_x64' = ''
    'mac_beta_x86' = 'betachannel'
    'mac_beta_x64' = 'betachannel'
    'mac_dev_x86' = 'devchannel'
    'mac_dev_x64' = 'devchannel'
    'mac_canary_x86' = ''
    'mac_canary_x64' = ''
    }
    
    perl
    Copy code
    $posts = @{}
    foreach ($os in $platforms.Keys) {
        foreach ($channel in $channels) {
            foreach ($arch in $platforms[$os]) {
                $ver = $vers[$os]
                $appid = $appids["$os_$channel"]
                $ap = $aps["$os_$channel_$arch"]
    
                $posts["$os_$channel_$arch"] = @"
    <?xml version='1.0' encoding='UTF-8'?>
    <request protocol='3.0' version='1.3.23.9' shell_version='1.3.21.103' ismachine='0'
     sessionid='{3597644B-2952-4F92-AE55-D315F45F80A5}' installsource='ondemandcheckforupdate'
     requestid='{CD7523AD-A40D-49F4-AEEF-8C114B804658}' dedup='cr'>
    <hw sse='1' sse2='1' sse3='1' ssse3='1' sse41='1' sse42='1' avx='1' physmemory='12582912' />
    <os platform='$os' version='$ver' arch='$arch'/>
    <app appid='$appid' ap='$ap