using CodingInterviewSolutions.Named;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static CodingInterviewSolutions.Named.CelebrityProblem;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class CelebrityProblemUnitTests
	{
		[TestMethod]
		public void NoCelebrity_Null()
		{
			var peopleGraph = new List<Node>();
			Assert.AreEqual(null, CelebrityProblem.FindCelebrity(peopleGraph));
		}

		[TestMethod]
		public void EveryoneKnowsEveryone_null()
		{
			var peopleGraph = new List<Node>();
			var bob = new Node("Bob");
			var jack = new Node("Jack");
			var jill = new Node("Jill");
			peopleGraph.Add(bob); peopleGraph.Add(jack); peopleGraph.Add(jill);
			bob.Knows.Add(jack);
			bob.Knows.Add(jill);
			jack.Knows.Add(jill);
			jack.Knows.Add(bob);
			jill.Knows.Add(jack);
			jill.Knows.Add(bob);
			Assert.AreEqual(null, CelebrityProblem.FindCelebrity(peopleGraph));
		}

		[TestMethod]
		public void NoOneKnowsAnyone_Null()
		{
			var peopleGraph = new List<Node>();
			var bob = new Node("Bob");
			var jack = new Node("Jack");
			var jill = new Node("Jill");
			peopleGraph.Add(bob); peopleGraph.Add(jack); peopleGraph.Add(jill);
			Assert.AreEqual(null, CelebrityProblem.FindCelebrity(peopleGraph));
		}

		[TestMethod]
		public void OnlyKnow1Person_Null()
		{
			var peopleGraph = new List<Node>();
			var bob = new Node("Bob");
			var jack = new Node("Jack");
			var jill = new Node("Jill");
			peopleGraph.Add(bob); peopleGraph.Add(jack); peopleGraph.Add(jill);
			bob.Knows.Add(jill);
			jack.Knows.Add(bob);
			jill.Knows.Add(jack);
			Assert.AreEqual(null, CelebrityProblem.FindCelebrity(peopleGraph));
		}

		[TestMethod]
		public void CelebrityPresentBasic_Celebrity()
		{
			var peopleGraph = new List<Node>();
			var bob = new Node("Bob");
			var jack = new Node("Jack");
			var jill = new Node("Jill");
			peopleGraph.Add(bob); peopleGraph.Add(jack); peopleGraph.Add(jill);
			bob.Knows.Add(jill);
			jack.Knows.Add(jill);
			Assert.AreEqual(jill, CelebrityProblem.FindCelebrity(peopleGraph));
		}

		[TestMethod]
		public void CelebrityPresentOtherKnowsToo_Celebrity()
		{
			var peopleGraph = new List<Node>();
			var bob = new Node("Bob");
			var jack = new Node("Jack");
			var jill = new Node("Jill");
			peopleGraph.Add(bob); peopleGraph.Add(jack); peopleGraph.Add(jill);
			bob.Knows.Add(jill);
			bob.Knows.Add(jack);
			jack.Knows.Add(jill);
			jack.Knows.Add(bob);
			Assert.AreEqual(jill, CelebrityProblem.FindCelebrity(peopleGraph));
		}
	}
}
