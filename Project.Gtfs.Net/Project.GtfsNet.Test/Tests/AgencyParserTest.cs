﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project.GtfsNet.Core;
using Project.GtfsNet.Parsers;
using Xunit;
using Xunit.Abstractions;

namespace Project.GtfsNet.Test.Tests
{
	public class AgencyParserTest
	{
		private readonly ITestOutputHelper _output;
		private const string PATH = "feeds/subway/agency.txt";
		private readonly AgencyParser _sut = new AgencyParser();

		public AgencyParserTest(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void EnsureThatParsingOnNullTextReaderThrowsException()
		{
			Assert.ThrowsAny<ArgumentNullException>(() => _sut.Parse(null));
		}

		[Fact]
		public void AgencyFileIsNotEmpty()
		{
			using (TextReader textReader = GetAgencyTextReader())
			{
				IEnumerable<Agency> agencies = _sut.Parse(textReader);
				List<Agency> agencyList = agencies.ToList();

				Assert.NotNull(agencyList);
				Assert.True(agencyList.Any());
			}
		}

		[Fact]
		public void CheckAgencyDataIsParsedCorrectly()
		{
			using (TextReader textReader = GetAgencyTextReader())
			{
				IEnumerable<Agency> agencies = _sut.Parse(textReader);
				List<Agency> agencyList = agencies.ToList();

				Agency agency = agencyList[0];
				Assert.Equal("LI", agency.Id);
				Assert.Equal("en", agency.Language);
				Assert.Equal("Long Island Rail Road", agency.Name);
				Assert.Equal("718-558-7400", agency.Phone);
				Assert.Equal("America/New_York", agency.Timezone);
				Assert.Equal("http://web.mta.info/lirr", agency.Url);
				Assert.Null(agency.FareUrl);
			}
		}

		public TextReader GetAgencyTextReader()
		{
			return File.OpenText(PATH);
		}
	}
}
