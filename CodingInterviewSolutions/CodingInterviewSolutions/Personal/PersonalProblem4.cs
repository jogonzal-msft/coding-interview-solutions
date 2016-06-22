using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterviewSolutions.Personal
{
	public class PersonalProblem4
	{
		public class Contact
		{
			public string Name { get; set; }
			public List<string> Emails { get; set; }
		}

		public class CondensedContact
		{
			public List<string> Names { get; set; }
			public List<string> Emails { get; set; }
		}

		public static List<CondensedContact> Solve(List<Contact> contacts)
		{
			throw new NotImplementedException();
		}
	}
}
