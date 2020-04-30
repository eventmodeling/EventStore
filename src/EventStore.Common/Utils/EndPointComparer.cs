using System;
using System.Collections.Generic;
using System.Net;

namespace EventStore.Common.Utils {
	public class EndPointComparer : IComparer<EndPoint> {
		public int Compare(EndPoint x, EndPoint y) {
			var xx = x.GetHost();
			var yy = y.GetHost();
			var result = string.CompareOrdinal(xx, yy);
			return result == 0 ? x.GetPort().CompareTo(y.GetPort()) : result;
		}
	}
	
	public class EndPointEqualityComparer : IEqualityComparer<EndPoint> {
		public bool Equals(EndPoint x, EndPoint y) {
			return x.GetPort() == y.GetPort() && x.GetHost().Equals(y.GetHost());
		}

		public int GetHashCode(EndPoint obj) {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(ToString());
		}
	}
}
