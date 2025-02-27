﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GtfsNet.Enums;

namespace GtfsNet.Entities
{
	public class StopTime : Entity, IEqualityComparer<StopTime>
	{
		[Required]
		public string TripId { get; set; }

		[Required]
		public string ArrivalTime { get; set; }

		[Required]
		public string DepartureTime { get; set; }

		[Required]
		public string StopId { get; set; }

		[Required]
		public int StopSequence { get; set; }

		public string StopHeadsign { get; set; }

		public PickupType? PickupType { get; set; }

		public DropOffType? DropOffType { get; set; }

		public string ShapeDistTravelled { get; set; }

		/// <summary>
		/// Returns a description of this trip.
		/// </summary>
		/// <remarks>https://github.com/OsmSharp/GTFS/blob/226a247861cf90badde49655095193ac829cf227/GTFS/Entities/StopTime.cs</remarks>
		public override string ToString()
		{
			return string.Format("[{0}:{1}] {2}", TripId, StopId, StopHeadsign);
		}

		public bool Equals(StopTime x, StopTime y)
		{
			return AreEqual(x, y);
		}

		public int GetHashCode(StopTime obj)
		{
			return ComputeHashCode(obj);
		}
	}
}
