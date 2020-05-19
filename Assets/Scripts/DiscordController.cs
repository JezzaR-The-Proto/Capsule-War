﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour {

	public Discord.Discord discord;

    // Discord State and Details
    public string State;
    public string Details;

	// Use this for initialization
	void Start () {
		discord = new Discord.Discord(712422591859785778, (System.UInt64)Discord.CreateFlags.Default);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			State = State,
			Details = Details
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
		discord.RunCallbacks();
	}
}