<Query Kind="Program" />

using System.Dynamic;

void Main()
{
	var accessTree = new AccessTreeProvider();
	var tree = accessTree.GetAccessTree();
}



/// <summary>
/// Сервис для построения дерева прав
/// </summary>
public class AccessTreeProvider
{
	public class AccessRow
	{

		public AccessRow() { }

		public AccessRow(string alias, bool read, bool write)
		{
			Alias = alias;
			Read = read;
			Write = write;
		}
		public string Alias { get; set; }

		public bool Read { get; set; }

		public bool Write { get; set; }
	}


	/// <summary>
	/// Имитация базы данных
	/// </summary>
	private List<AccessRow> _data = new List<AccessRow>
		{

			new AccessRow("Order.Price", read: true, write: false),
			new AccessRow("Order.Quantity", read: true, write: true),
			new AccessRow("Order.Item", read: true, write: true),
			new AccessRow("Order", read: true, write: true),
			new AccessRow("Order.Item.InnerCode", read: false, write: false),
			new AccessRow("Order.Item.Name", read: false, write: true),
			new AccessRow("Order.Item.Foo", read: false, write: true),
            /* 
             * 
             * 
             * 
             * Должно все выглядеть в итоге вот так
             * 
             * 
             * {
             *      Order:{
             *          read: true,
             *          write: true,
             *          Price: {
             *              read: true, 
             *              write: false,
             *          },
             *          Quantity: {
             *              read: true,
             *              write: true, 
             *          },
             *          Item: {
             *              read: true, 
             *              write: false,
             *              InnerCode: {
             *                  read: false,
             *                  write: false,
             *              },
             *              Name: {
             *                  read: false, 
             *                  write: true,
             *              }
             *          },
             * }
             */
        };

	public ExpandoObject GetAccessTree()
	{
		var res = new ExpandoObject();
		foreach (var d in _data)
		{
			var parts = d.Alias.Split('.').AsEnumerable();
			var e = parts.GetEnumerator();
			e.MoveNext();
			ProcessNode(res, e, d);
		}

		return res;

	}

	private void ProcessNode(
		ExpandoObject node,
		IEnumerator<string> enumerator,
		AccessRow row)
	{

		//
		var dict = node as IDictionary<string, object>;
		// Возвращаем текущее знчение в вспике
		var currentValue = enumerator.Current;


		ExpandoObject newNode;
		if (dict.ContainsKey(currentValue))
		{
			newNode = (ExpandoObject)dict[currentValue];
		}
		else
		{
			newNode = new ExpandoObject();
			dict.Add(currentValue, newNode);
		}

		if (enumerator.MoveNext())
		{
			ProcessNode(newNode, enumerator, row);
		}
		else
		{
			newNode.TryAdd("read", row.Read);
			newNode.TryAdd("write", row.Write);
		}

	}
}