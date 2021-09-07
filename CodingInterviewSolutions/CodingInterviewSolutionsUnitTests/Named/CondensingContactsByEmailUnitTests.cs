using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class CondensingContactsByEmailUnitTests
	{
		[TestMethod]
		public void NoContacts_NoCondensedContacts()
		{
			var contacts = new List<CondensingContactsByEmail.Contact>()
			{
			};

			var expected = new List<CondensingContactsByEmail.CondensedContact>()
			{
			};

			List<CondensingContactsByEmail.CondensedContact> result = CondensingContactsByEmail.Solve(contacts);

			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void Only1Contact_CondensedTo1()
		{
			var contacts = new List<CondensingContactsByEmail.Contact>()
			{
				new CondensingContactsByEmail.Contact()
				{
					Name = "Jorge",
					Emails = new List<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
			};

			var expected = new List<CondensingContactsByEmail.CondensedContact>()
			{
				new CondensingContactsByEmail.CondensedContact()
				{
					Names = new HashSet<string>()
					{
						"Jorge",
					},
					Emails = new HashSet<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
			};

			List<CondensingContactsByEmail.CondensedContact> result = CondensingContactsByEmail.Solve(contacts);

			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void TwoContacts_SameEmail_CondensedTo1()
		{
			var contacts = new List<CondensingContactsByEmail.Contact>()
			{
				new CondensingContactsByEmail.Contact()
				{
					Name = "Jorge",
					Emails = new List<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
				new CondensingContactsByEmail.Contact()
				{
					Name = "Jorge Aguirre",
					Emails = new List<string>()
					{
						"jorge@msft.com",
					}
				},
			};

			var expected = new List<CondensingContactsByEmail.CondensedContact>()
			{
				new CondensingContactsByEmail.CondensedContact()
				{
					Names = new HashSet<string>()
					{
						"Jorge",
						"Jorge Aguirre"
					},
					Emails = new HashSet<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
			};

			List<CondensingContactsByEmail.CondensedContact> result = CondensingContactsByEmail.Solve(contacts);

			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void TwoContacts_SameName_CondensedTo2()
		{
			var contacts = new List<CondensingContactsByEmail.Contact>()
			{
				new CondensingContactsByEmail.Contact()
				{
					Name = "Jorge",
					Emails = new List<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
				new CondensingContactsByEmail.Contact()
				{
					Name = "Jorge",
					Emails = new List<string>()
					{
						"jorge2@aol.com",
					}
				},
			};

			var expected = new List<CondensingContactsByEmail.CondensedContact>()
			{
				new CondensingContactsByEmail.CondensedContact()
				{
					Names = new HashSet<string>()
					{
						"Jorge",
					},
					Emails = new HashSet<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
				new CondensingContactsByEmail.CondensedContact()
				{
					Names = new HashSet<string>()
					{
						"Jorge",
					},
					Emails = new HashSet<string>()
					{
						"jorge2@aol.com",
					}
				},
			};

			List<CondensingContactsByEmail.CondensedContact> result = CondensingContactsByEmail.Solve(contacts);

			result.Should().BeEquivalentTo(expected);
		}

		[TestMethod]
		public void MultipleLists_OneList()
		{
			var contacts = new List<CondensingContactsByEmail.Contact>()
			{
				new CondensingContactsByEmail.Contact()
				{
					Name = "Jorge",
					Emails = new List<string>()
					{
						"jorge@msft.com",
						"jo@msft.com",
					}
				},
				new CondensingContactsByEmail.Contact()
				{
					Name = "George",
					Emails = new List<string>()
					{
						"jo@msft.com",
						"jorgeaguirre@msft.com",
					}
				},
				new CondensingContactsByEmail.Contact()
				{
					Name = "Bob",
					Emails = new List<string>()
					{
						"bob@msft.com",
						"bob2@msft.com",
					}
				},
				new CondensingContactsByEmail.Contact()
				{
					Name = "Jorge2",
					Emails = new List<string>()
					{
						"jrogenew@msft.com",
						"jorge@msft.com",
					}
				},
			};

			var expected = new List<CondensingContactsByEmail.CondensedContact>()
			{
				new CondensingContactsByEmail.CondensedContact()
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
				new CondensingContactsByEmail.CondensedContact()
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

			List<CondensingContactsByEmail.CondensedContact> result = CondensingContactsByEmail.Solve(contacts);

			result.Should().BeEquivalentTo(expected);
		}
	}
}
