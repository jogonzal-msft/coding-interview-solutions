using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class CondensingContactsUnitTests
	{
		[TestMethod]
		public void MultipleLists_OneList()
		{
			var contacts = new List<CondensingContacts.Contact>()
			{
				new CondensingContacts.Contact()
				{
					Name = "Jorge",
					Emails = new List<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
				new CondensingContacts.Contact()
				{
					Name = "George",
					Emails = new List<string>()
					{
						"jo@msft.com",
						"jorgeaguirre@msft.com",
					}
				},
				new CondensingContacts.Contact()
				{
					Name = "Bob",
					Emails = new List<string>()
					{
						"bob@msft.com",
						"bob2@msft.com",
					}
				},
				new CondensingContacts.Contact()
				{
					Name = "Jorge2",
					Emails = new List<string>()
					{
						"jrogenew@msft.com",
						"jorge@msft.com",
					}
				},
			};

			var expected = new List<CondensingContacts.CondensedContact>()
			{
				new CondensingContacts.CondensedContact()
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
				new CondensingContacts.CondensedContact()
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

			List<CondensingContacts.CondensedContact> result = CondensingContacts.Solve(contacts);

			result.ShouldBeEquivalentTo(expected);
		}
	}
}
