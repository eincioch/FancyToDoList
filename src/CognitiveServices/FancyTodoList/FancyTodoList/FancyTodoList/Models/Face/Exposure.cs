﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FancyTodoList.Models
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ExposureLevel
	{
		UnderExposure,
        GoodExposure,
        OverExposure
	}

    public class Exposure
    {
		public ExposureLevel ExposureLevel { get; set; }
		public double Value { get; set; }
    }
}
