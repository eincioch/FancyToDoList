﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FancyTodoList.Models
{
	[JsonConverter(typeof(StringEnumConverter))]
    public enum BlurLevel
	{
		Low,
        Medium,
        High
	}

    public class Blur
    {
		public BlurLevel BlurLevel { get; set; }
		public double Value { get; set; }
    }
}
