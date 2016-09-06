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
			public CondensedContact()
			{
				Names = new HashSet<string>();
				Emails = new HashSet<string>();
			}

			public HashSet<string> Names { get; set; }
			public HashSet<string> Emails { get; set; }
		}

		public static List<CondensedContact> Solve(List<Contact> contacts)
		{
			// Everything must be indexed by email
			Dictionary<string, CondensedContact> dict = new Dictionary<string, CondensedContact>();
			HashSet<CondensedContact> condensedContacts = new HashSet<CondensedContact>();
			foreach (var contact in contacts)
			{
				CondensedContact existingCondensedContact = null;
				// Try to find the existing condensed contact
				foreach (var email in contact.Emails)
				{
					if (dict.TryGetValue(email, out existingCondensedContact))
					{
						break;
					}
				}

				if (existingCondensedContact == null)
				{
					// No existing condensed contact - must create and add him
					existingCondensedContact = new CondensedContact();
					condensedContacts.Add(existingCondensedContact);
				}

				// Make sure he is set everywhere
				foreach (var email in contact.Emails)
				{
					dict[email] = existingCondensedContact;
					
					// also, add his email
					existingCondensedContact.Emails.Add(email);
				}

				existingCondensedContact.Names.Add(contact.Name);
			}

			return condensedContacts.ToList();
		}
	}
}
