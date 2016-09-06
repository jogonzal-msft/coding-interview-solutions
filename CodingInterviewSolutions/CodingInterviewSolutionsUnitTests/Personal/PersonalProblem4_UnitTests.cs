using System.Collections.Generic;
using CodingInterviewSolutions.Personal;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Personal
{
	[TestClass]
	public class PersonalProblem4_UnitTests
	{
		[TestMethod]
		public void MultipleLists_OneList()
		{
			var contacts = new List<PersonalProblem4.Contact>()
			{
				new PersonalProblem4.Contact()
				{
					Name = "Jorge",
					Emails = new List<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
				new PersonalProblem4.Contact()
				{
					Name = "George",
					Emails = new List<string>()
					{
						"jo@msft.com",
						"jorgeaguirre@msft.com",
					}
				},
				new PersonalProblem4.Contact()
				{
					Name = "Bob",
					Emails = new List<string>()
					{
						"bob@msft.com",
						"bob2@msft.com",
					}
				},
				new PersonalProblem4.Contact()
				{
					Name = "Jorge2",
					Emails = new List<string>()
					{
						"jrogenew@msft.com",
						"jorge@msft.com",
					}
				},
			};

			var expected = new List<PersonalProblem4.CondensedContact>()
			{
				new PersonalProblem4.CondensedContact()
				{
					Names = new HashSet<string>()
					{
						"Jorge",
						"Jorge2",
						"George",
					},
					Emails = new HashSet<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
						"jrogenew@msft.com",
						"jorgeaguirre@msft.com",
					}
				},
				new PersonalProblem4.CondensedContact()
				{
					Names = new HashSet<string>()
					{
						"Bob",
					},
					Emails = new HashSet<string>()
					{
						"bob@msft.com",
						"bob2@msft.com",
					}
				},
			};

			List<PersonalProblem4.CondensedContact> result = PersonalProblem4.Solve(contacts);

			result.ShouldBeEquivalentTo(expected);
		}
	}
}
