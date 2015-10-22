﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.GtfsNet.Entities;
using Project.GtfsNet.Entities.Maps;
using Project.GtfsNet.Parsers;
using Xunit;
using Xunit.Abstractions;

namespace Project.GtfsNet.Test.Tests
{
	public class FrequenciesParserTest : ParserTestBase
	{
		private readonly EntitiesParser<Frequencies, FrequenciesMap> _parser = new EntitiesParser<Frequencies, FrequenciesMap>();

		public override string TestFilePath { get; } = "feeds/subway/frequencies.txt";

		public FrequenciesParserTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void FileIsNotEmpty()
		{
			using (TextReader textReader = GetTextReader())
			{
				IEnumerable<Frequencies> parsed = _parser.Parse(textReader);
				List<Frequencies> parsedList = parsed.ToList();

				Assert.NotNull(parsedList);
				Assert.True(parsedList.Any());
				Assert.Equal(11, parsedList.Count);
			}
		}

		[Fact]
		public void CheckDataIsParsedCorrectly()
		{
			using (TextReader textReader = GetTextReader())
			{
				IEnumerable<Frequencies> parsed = _parser.Parse(textReader);
				List<Frequencies> parsedList = parsed.ToList();

				Frequencies item = parsedList[0];

				Assert.Null(item.ExactTimes);

				Assert.Equal("22:00:00", item.EndTime);
				Assert.Equal("1800", item.HeadwaySecs);
				Assert.Equal("6:00:00", item.StartTime);
				Assert.Equal("STBA", item.TripId);
			}
		}
	}
}
