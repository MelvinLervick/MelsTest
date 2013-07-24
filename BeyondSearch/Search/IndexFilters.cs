using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Index
{
	class IndexFilters
	{
		Dictionary<string, Dictionary<string,bool>> filters = null;

		public IndexFilters()
		{
			filters = new Dictionary<string, Dictionary<string,bool>>();
		}

		public void AddFilter(string filterName)
		{
			filters.Add(filterName, new Dictionary<string, bool>());
		}

		public void RemoveFilter(string filterName)
		{
			filters.Remove(filterName);
		}
	}
}
