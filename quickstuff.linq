<Query Kind="Program">
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>

void Main()
{
//	var nameGenerator = new NameGenerator();
//	foreach (var name in nameGenerator.GetNames(10).Take(2).ToList())
//	{
//		name.Dump();
//	}
//
//	var pete = new Person("Pete", "Stephenson");
//	var quick = new Person("Richard", "Wynn");
//	var mat = pete with { Forename = "Mat" };
//	var database = new List<Person> {pete, quick, mat};
//	
//	database.Dump();
//	
//	database.Where(p => p.Surname == "Stephenson").Dump();
//	
//	var stephensons = from p in database where p.Surname == "Stephenson" select p;
//	stephensons.Dump();

	var list1 = new List<string> { "bob" };
	var list2 = new List<string> { "bobbetta" };
	
	list1.Concat(list2).Dump();

	//	var strings = new StringList(new [] { "Bob", "Bobetta" }).ToList();
//	
//	foreach(var s in strings)
//	{
//		s.Dump();
//	}
//
//	foreach (var s in strings)
//	{
//		s.Dump();
//	}


	//var pete = new Person("Pete", "Stephenson");
	//var quick = new Person("Richard", "Wynn");
	//var mat = pete with { Forename = "Mat" };
	//
	//var people = new List<Person> { pete, quick, mat };
	//people.SortByName().Dump();
	//
	//var peopled = new PeopleCollection();
	//peopled.Add(pete);
	//peopled.Add(quick);
	//peopled.Underlying.Dump();

	//try
	//{
	//	new BigBadaBoom();
	//} catch(Exception ex) {
	//	"caught".Dump();
	//	throw new Exception("boom", ex);
	//} finally 
	//{
	//	
	//}
	
	//using var con = new SqlConnection();
//	
//	var instance1 = new Helper();
//	var instance2 = new Helper();
//
//	instance1.ToString().Dump();
//	instance2.ToString().Dump();
}

public class NameGenerator
{
	private static readonly string[] _names = new[] { "Quick", "Pete", "Ally", "Bob" };
	public IEnumerable<string> GetNames(int numberOfNames) {
		for(var i = 0; i < numberOfNames; i++)
		{
			"GET A NAME".Dump();
			yield return _names.OrderBy(n => Guid.NewGuid()).First();
			"DONE".Dump();
		}
	}
}

public class StringList : IEnumerable<string>
{
	private List<string> _underlying;

	public IEnumerator<string> GetEnumerator()
	{
		"REALLY EXPENSIVE THING".Dump();
		return _underlying.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	
	public StringList(string[] underlying)
	{
		_underlying = underlying.ToList();
	}
}

public abstract class MyKeyedCollection<TKey, TValue>
{
	private Dictionary<TKey, TValue> _underlying;
	
	public MyKeyedCollection()
	{
		_underlying = new Dictionary<TKey, TValue>();
	}
	
	protected abstract TKey GetKeyForItem(TValue val);
	
	public void Add(TValue v) => _underlying.Add(GetKeyForItem(v), v);
	
	public ReadOnlyDictionary<TKey, TValue> Underlying => new ReadOnlyDictionary<TKey, TValue>(_underlying);
}

public class PeopleCollection : MyKeyedCollection<string, Person>
{
	protected override string GetKeyForItem(Person item) => item.Surname;
}

public static class PersonArrayExtensions 
{
	public static IEnumerable<Person> SortByName(this IEnumerable<Person> people) => people.OrderBy(p => p.Surname).ThenBy(p => p.Forename);
}


public class Helper
{
	public static string Value = ExpensiveMethod();

	private static string ExpensiveMethod() => Guid.NewGuid().ToString();

	public override string ToString()
	{
		return Value;
	}
}

public class SqlConnection : IDisposable
{
	public void Dispose()
	{
		"disposing".Dump();
	}
}

public record Person(string Forename, string Surname) : IHasName
{
	public string Name => Forename + " " + Surname;
}

public interface IHasName 
{
	string Name { get; }
}

public abstract class Person2 
{
	public string Forename { get; }

	public string Surname { get; }
	
	public string Name => Forename + " " + Surname;
	
	public abstract void Rename(string newName);
}

public class Human : Person2, IHasName
{
	public override void Rename(string newName)
	{
		throw new NotImplementedException();
	}
}

public class BigBadaBoom
{
	public BigBadaBoom()
	{
		throw new NotImplementedException();
	}
}