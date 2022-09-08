﻿using System;
using HarmonyLib;
using YamlDotNet.Serialization;

namespace WardIsLove.Util.DiscordMessenger;

[HarmonyPatch]
[Serializable]
public class Image
{
    [YamlMember(Alias = "url")] public string Url { get; set; }

    [YamlMember(Alias = "proxy_url")] public string ProxyIcon { get; set; }

    [YamlMember(Alias = "width")] public string Width { get; set; }

    [YamlMember(Alias = "height")] public string Height { get; set; }
}