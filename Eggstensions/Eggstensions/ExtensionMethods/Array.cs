using System.Linq;



namespace Eggstensions.ExtensionMethods
{
	static public class Array
	{
		#region All
		/// <summary>If all elements in this array meet the specified condition.</summary>
		static public System.Boolean All<T>(this T[,] array, System.Func<T, System.Boolean> condition)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			var upperBoundRows = array.UpperBoundRows();
			var upperBoundColumns = array.UpperBoundColumns();

			for (var row = array.LowerBoundRows(); row <= upperBoundRows; row++)
			{
				for (var column = array.LowerBoundColumns(); column <= upperBoundColumns; column++)
				{
					if (!condition(array[row, column]))
					{
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>If all elements in this array meet the specified condition.</summary>
		static public System.Boolean AllJagged<T>(this T[][,] arrays, System.Func<T, System.Boolean> condition)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			var upperBound = arrays.UpperBound();

			for (var i = arrays.LowerBound(); i <= upperBound; i++)
			{
				if (arrays[i] == null)
				{
					continue;
				}

				var upperBoundRows = arrays[i].UpperBoundRows();
				var upperBoundColumns = arrays[i].UpperBoundColumns();

				for (var row = arrays[i].LowerBoundRows(); row <= upperBoundRows; row++)
				{
					for (var column = arrays[i].LowerBoundColumns(); column <= upperBoundColumns; column++)
					{
						if (!condition(arrays[i][row, column]))
						{
							return false;
						}
					}
				}
			}

			return true;
		}
		#endregion



		#region AllDimensions
		/// <summary>If all dimensions of this array meet the specified condition.</summary>
		static public System.Boolean AllDimensions<T>(this T[] array, System.Func<System.Int32, System.Int32, System.Boolean> condition, System.Int32? length)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			return
				Length();



			System.Boolean Length()
			{
				if (length.HasValue)
				{
					if (length.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(length)); }
					if (condition(length.Value, array.Length)) { return true; }

					return false;
				}

				return true;
			}
		}

		/// <summary>If all dimensions of this array meet the specified condition.</summary>
		static public System.Boolean AllDimensions<T>(this T[,] array, System.Func<System.Int32, System.Int32, System.Boolean> condition, System.Int32? rows, System.Int32? columns)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			return
				Rows()
				&&
				Columns();



			System.Boolean Rows()
			{
				if (rows.HasValue)
				{
					if (rows.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(rows)); }
					if (condition(rows.Value, array.Rows())) { return true; }

					return false;
				}

				return true;
			}

			System.Boolean Columns()
			{
				if (columns.HasValue)
				{
					if (columns.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(columns)); }
					if (condition(columns.Value, array.Columns())) { return true; }

					return false;
				}

				return true;
			}
		}

		/// <summary>If all dimensions of this array meet the specified condition.</summary>
		static public System.Boolean AllDimensionsJagged<T>(this T[][,] arrays, System.Func<System.Int32, System.Int32, System.Boolean> condition, System.Int32? length, System.Int32? rows, System.Int32? columns)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			return
				Length()
				&&
				Rows()
				&&
				Columns();



			System.Boolean Length()
			{
				if (length.HasValue)
				{
					if (length.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(length)); }
					if (condition(length.Value, arrays.Length)) { return true; }

					return false;
				}

				return true;
			}

			System.Boolean Rows()
			{
				if (rows.HasValue)
				{
					if (rows.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(rows)); }

					return arrays.All(elements => elements != null ? condition(rows.Value, elements.Rows()) : false);
				}

				return true;
			}

			System.Boolean Columns()
			{
				if (columns.HasValue)
				{
					if (columns.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(columns)); }

					return arrays.All(elements => elements != null ? condition(columns.Value, elements.Columns()) : false);
				}

				return true;
			}
		}
		#endregion



		#region Any
		/// <summary>If any elements in this array meet the specified condition.</summary>
		static public System.Boolean Any<T>(this T[,] array, System.Func<T, System.Boolean> condition)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			var upperBoundRows = array.UpperBoundRows();
			var upperBoundColumns = array.UpperBoundColumns();

			for (var row = array.LowerBoundRows(); row <= upperBoundRows; row++)
			{
				for (var column = array.LowerBoundColumns(); column <= upperBoundColumns; column++)
				{
					if (condition(array[row, column]))
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>If any elements in this array meet the specified condition.</summary>
		static public System.Boolean AnyJagged<T>(this T[][,] arrays, System.Func<T, System.Boolean> condition)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			var upperBound = arrays.UpperBound();

			for (var i = arrays.LowerBound(); i <= upperBound; i++)
			{
				if (arrays[i] == null)
				{
					continue;
				}

				var upperBoundRows = arrays[i].UpperBoundRows();
				var upperBoundColumns = arrays[i].UpperBoundColumns();

				for (var row = arrays[i].LowerBoundRows(); row <= upperBoundRows; row++)
				{
					for (var column = arrays[i].LowerBoundColumns(); column <= upperBoundColumns; column++)
					{
						if (condition(arrays[i][row, column]))
						{
							return true;
						}
					}
				}
			}

			return false;
		}
		#endregion



		#region AnyDimensions
		/// <summary>If any dimensions of this array meet the specified condition.</summary>
		static public System.Boolean AnyDimensions<T>(this T[] array, System.Func<System.Int32, System.Int32, System.Boolean> condition, System.Int32? length)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			return
				Length();



			System.Boolean Length()
			{
				if (length.HasValue)
				{
					if (length.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(length)); }
					if (condition(length.Value, array.Length)) { return true; }
				}

				return false;
			}
		}

		/// <summary>If any dimensions of this array meet the specified condition.</summary>
		static public System.Boolean AnyDimensions<T>(this T[,] array, System.Func<System.Int32, System.Int32, System.Boolean> condition, System.Int32? rows, System.Int32? columns)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			return
				Rows()
				||
				Columns();



			System.Boolean Rows()
			{
				if (rows.HasValue)
				{
					if (rows.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(rows)); }
					if (condition(rows.Value, array.Rows())) { return true; }
				}

				return false;
			}

			System.Boolean Columns()
			{
				if (columns.HasValue)
				{
					if (columns.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(columns)); }
					if (condition(columns.Value, array.Columns())) { return true; }
				}

				return false;
			}
		}

		/// <summary>If any dimensions of this array meet the specified condition.</summary>
		static public System.Boolean AnyDimensionsJagged<T>(this T[][,] arrays, System.Func<System.Int32, System.Int32, System.Boolean> condition, System.Int32? length, System.Int32? rows, System.Int32? columns)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			return
				Length()
				||
				Rows()
				||
				Columns();



			System.Boolean Length()
			{
				if (length.HasValue)
				{
					if (length.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(length)); }
					if (condition(length.Value, arrays.Length)) { return true; }
				}

				return false;
			}

			System.Boolean Rows()
			{
				if (rows.HasValue)
				{
					if (rows.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(rows)); }

					return arrays.Any(elements => elements != null ? condition(rows.Value, elements.Rows()) : false);
				}

				return false;
			}

			System.Boolean Columns()
			{
				if (columns.HasValue)
				{
					if (columns.Value < 0) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(columns)); }

					return arrays.Any(elements => elements != null ? condition(columns.Value, elements.Columns()) : false);
				}

				return false;
			}
		}
		#endregion



		#region Column
		/// <summary>The specified column of this array.</summary>
		static public T[] Column<T>(this T[,] array, System.Int32 column, System.Int32 lowerBound = 0)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (array.OutOfBounds(null, column)) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(column)); }
			// lowerBound

			var rows = array.Rows();
			var result = (T[])System.Array.CreateInstance(typeof(T), new System.Int32[] { rows }, new System.Int32[] { lowerBound });

			var lowerBoundRows = array.LowerBoundRows();
			var lowerBoundColumns = array.LowerBoundColumns();

			for (var row = 0; row < rows; row++)
			{
				result[row + lowerBound] = array[row + lowerBoundRows, column + lowerBoundColumns];
			}

			return result;
		}
		#endregion



		#region ColumnBind
		/// <summary>Creates a multidimensional array from this jagged array where each element is a column.</summary>
		static public T[,] ColumnBindJagged<T>(this T[][] arrays, System.Int32 lowerBoundRows = 0, System.Int32 lowerBoundColumns = 0)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			// lowerBoundRows
			// lowerBoundColumns
			if (!arrays.SameDimensionsJagged()) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(arrays)); }

			var arraysLowerBound = arrays.LowerBound();

			var rows = arrays[arraysLowerBound]?.Length ?? 0; // If all arrays are null then set the number of rows to 0
			var columns = arrays.Length;
			var result = (T[,])System.Array.CreateInstance(typeof(T), new System.Int32[] { rows, columns }, new System.Int32[] { lowerBoundRows, lowerBoundColumns });

			for (var column = 0; column < columns; column++)
			{
				if (arrays[column] == null)
				{
					continue;
				}

				var arrayLowerBound = arrays[column].LowerBound();

				for (var row = 0; row < rows; row++)
				{
					result[row + lowerBoundRows, column + lowerBoundColumns] = arrays[column + arraysLowerBound][row + arrayLowerBound];
				}
			}

			return result;
		}
		#endregion



		#region Columns
		/// <summary>The number of columns in this array.</summary>
		static public System.Int32 Columns<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLength(1);
		}
		#endregion



		#region Convert
		/// <summary>Converts each element of this array to an array of another type.</summary>
		static public TOutput[] Convert<TInput, TOutput>(this TInput[] array, System.Func<TInput, TOutput> converter)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (converter == null) { throw new Eggceptions.ArgumentNullException(nameof(converter)); }

			var lowerBound = array.LowerBound();
			var upperBound = array.UpperBound();
			var result = (TOutput[])System.Array.CreateInstance(typeof(TOutput), new System.Int32[] { array.Length }, new System.Int32[] { lowerBound });

			for (var i = lowerBound; i <= upperBound; i++)
			{
				result[i] = converter(array[i]);
			}

			return result;
		}

		/// <summary>Convert an array of one type to an array of another type.</summary>
		static public TOutput[,] Convert<TInput, TOutput>(this TInput[,] array, System.Func<TInput, TOutput> converter)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (converter == null) { throw new Eggceptions.ArgumentNullException(nameof(converter)); }

			var lowerBoundRows = array.LowerBoundRows();
			var upperBoundRows = array.UpperBoundRows();
			var lowerBoundColumns = array.LowerBoundColumns();
			var upperBoundColumns = array.UpperBoundColumns();
			var result = (TOutput[,])System.Array.CreateInstance(typeof(TOutput), new System.Int32[] { array.Rows(), array.Columns() }, new System.Int32[] { lowerBoundRows, lowerBoundColumns });

			for (var row = lowerBoundRows; row <= upperBoundRows; row++)
			{
				for (var column = lowerBoundColumns; column <= upperBoundColumns; column++)
				{
					result[row, column] = converter(array[row, column]);
				}
			}

			return result;
		}

		/// <summary>Convert an array of one type to an array of another type.</summary>
		static public TOutput[][,] ConvertJagged<TInput, TOutput>(this TInput[][,] arrays, System.Func<TInput, TOutput> converter)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (converter == null) { throw new Eggceptions.ArgumentNullException(nameof(converter)); }

			var lowerBound = arrays.LowerBound();
			var upperBound = arrays.UpperBound();
			var result = (TOutput[][,])System.Array.CreateInstance(typeof(TOutput), new System.Int32[] { arrays.Length }, new System.Int32[] { lowerBound });

			for (var i = lowerBound; i <= upperBound; i++)
			{
				if (arrays[i] == null)
				{
					continue;
				}

				var lowerBoundRows = arrays[i].LowerBoundRows();
				var upperBoundRows = arrays[i].UpperBoundRows();
				var lowerBoundColumns = arrays[i].LowerBoundColumns();
				var upperBoundColumns = arrays[i].UpperBoundColumns();
				result[i] = (TOutput[,])System.Array.CreateInstance(typeof(TOutput), new System.Int32[] { arrays[i].Rows(), arrays[i].Columns() }, new System.Int32[] { lowerBoundRows, lowerBoundColumns });

				for (var row = lowerBoundRows; row <= upperBoundRows; row++)
				{
					for (var column = lowerBoundColumns; column <= upperBoundColumns; column++)
					{
						result[i][row, column] = converter(arrays[i][row, column]);
					}
				}
			}

			return result;
		}
		#endregion



		#region Copy
		/// <summary>A deep copy of this array.</summary>
		static public T[] Copy<T>(this T[] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			var lowerBound = array.LowerBound();
			var upperBound = array.UpperBound();
			var result = (T[])System.Array.CreateInstance(typeof(T), new System.Int32[] { array.Length }, new System.Int32[] { lowerBound });

			for (var i = lowerBound; i <= upperBound; i++)
			{
				result[i] = array[i];
			}

			return result;
		}

		/// <summary>A deep copy of this array.</summary>
		static public T[,] Copy<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			var lowerBoundRows = array.LowerBoundRows();
			var upperBoundRows = array.UpperBoundRows();
			var lowerBoundColumns = array.LowerBoundColumns();
			var upperBoundColumns = array.UpperBoundColumns();
			var result = (T[,])System.Array.CreateInstance(typeof(T), new System.Int32[] { array.Rows(), array.Columns() }, new System.Int32[] { lowerBoundRows, lowerBoundColumns });

			for (var row = lowerBoundRows; row <= upperBoundRows; row++)
			{
				for (var column = lowerBoundColumns; column <= upperBoundColumns; column++)
				{
					result[row, column] = array[row, column];
				}
			}

			return result;
		}

		/// <summary>A deep copy of this array.</summary>
		static public T[][,] CopyJagged<T>(this T[][,] arrays)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }

			var lowerBound = arrays.LowerBound();
			var upperBound = arrays.UpperBound();
			var result = (T[][,])System.Array.CreateInstance(typeof(T), new System.Int32[] { arrays.Length }, new System.Int32[] { lowerBound });

			for (var i = lowerBound; i <= upperBound; i++)
			{
				if (arrays[i] == null)
				{
					continue;
				}

				var lowerBoundRows = arrays[i].LowerBoundRows();
				var upperBoundRows = arrays[i].UpperBoundRows();
				var lowerBoundColumns = arrays[i].LowerBoundColumns();
				var upperBoundColumns = arrays[i].UpperBoundColumns();
				result[i] = (T[,])System.Array.CreateInstance(typeof(T), new System.Int32[] { arrays[i].Rows(), arrays[i].Columns() }, new System.Int32[] { lowerBoundRows, lowerBoundColumns });

				for (var row = lowerBoundRows; row <= upperBoundRows; row++)
				{
					for (var column = lowerBoundColumns; column <= upperBoundColumns; column++)
					{
						result[i][row, column] = arrays[i][row, column];
					}
				}
			}

			return result;
		}
		#endregion



		#region Equals
		// Cannot override Object.Equals
		/// <summary>If this array is equal to other arrays.</summary>
		static public System.Boolean Equals<T>(this T[,] array, params T[][,] arrays)
		{
			// array
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }

			return arrays.Unshift(array).EqualsJagged();
		}

		/// <summary>If each element in this jagged array are equal.</summary>
		static public System.Boolean EqualsJagged<T>(this T[][,] arrays)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (arrays.Length < 2) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(arrays)); }

			if (arrays.Any(elements => elements == null))
			{
				return arrays.All(elements => elements == null);
			}

			if (!arrays.SameDimensionsJagged())
			{
				return false;
			}

			var lowerBound = arrays.LowerBound();
			var upperBound = arrays.UpperBound();

			var firstArray = arrays[lowerBound];
			var lowerBoundRows = firstArray.LowerBoundRows();
			var upperBoundRows = firstArray.UpperBoundRows();
			var lowerBoundColumns = firstArray.LowerBoundColumns();
			var upperBoundColumns = firstArray.UpperBoundColumns();

			for (var i = lowerBound + 1; i <= upperBound; i++) // Skip firstArray
			{
				for (var row = lowerBoundRows; row <= upperBoundRows; row++)
				{
					for (var column = lowerBoundColumns; column <= upperBoundColumns; column++)
					{
						if (!arrays[i][row, column].Equals(firstArray[row, column]))
						{
							return false;
						}
					}
				}
			}

			return true;
		}
		#endregion



		#region Flatten
		/// <summary>Creates a new one-dimension array from this two-dimensional array.</summary>
		static public T[] Flatten<T>(this T[,] array, System.Int32 lowerBound = 0)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			// lowerBound

			var rows = array.Rows();
			var columns = array.Columns();
			var result = (T[])System.Array.CreateInstance(typeof(T), new System.Int32[] { rows * columns }, new System.Int32[] { lowerBound });

			var lowerBoundRows = array.LowerBoundRows();
			var lowerBoundColumns = array.LowerBoundColumns();

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[(columns * row + column) + lowerBound] = array[row + lowerBoundRows, column + lowerBoundColumns];
				}
			}

			return result;
		}
		#endregion



		#region ForEach
		/// <summary>Performs the specified action on each element of this array.</summary>
		static public void ForEach<T>(this T[] array, System.Action<T, System.Int32> action)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (action == null) { throw new Eggceptions.ArgumentNullException(nameof(action)); }

			var upperBound = array.UpperBound();

			for (var i = array.LowerBound(); i <= upperBound; i++)
			{
				action(array[i], i);
			}
		}

		/// <summary>Performs the specified action on each element of this array.</summary>
		static public void ForEach<T>(this T[,] array, System.Action<T, System.Int32, System.Int32> action)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (action == null) { throw new Eggceptions.ArgumentNullException(nameof(action)); }

			var upperBoundRows = array.UpperBoundRows();
			var upperBoundColumns = array.UpperBoundColumns();

			for (var row = array.LowerBoundRows(); row <= upperBoundRows; row++)
			{
				for (var column = array.LowerBoundColumns(); column <= upperBoundColumns; column++)
				{
					action(array[row, column], row, column);
				}
			}
		}

		/// <summary>Performs the specified action on each element of this array.</summary>
		static public void ForEach<T>(this T[][,] array, System.Action<T, System.Int32, System.Int32, System.Int32> action)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (action == null) { throw new Eggceptions.ArgumentNullException(nameof(action)); }

			var upperBound = array.UpperBound();

			for (var i = array.LowerBound(); i <= upperBound; i++)
			{
				if (array[i] == null)
				{
					continue;
				}
				
				var upperBoundRows = array[i].UpperBoundRows();
				var upperBoundColumns = array[i].UpperBoundColumns();

				for (var row = array[i].LowerBoundRows(); row <= upperBoundRows; row++)
				{
					for (var column = array[i].LowerBoundColumns(); column <= upperBoundColumns; column++)
					{
						action(array[i][row, column], i, row, column);
					}
				}
			}
		}
		#endregion



		#region Insert
		/// <summary>Inserts the specified elements into this array at the specified index.</summary>
		static public T[] Insert<T>(this T[] array, System.Int32 index, params T[] elements)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (array.OutOfBounds(index)) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(index)); }
			if (elements == null) { throw new Eggceptions.ArgumentNullException(nameof(elements)); }

			var lowerBoundArray = array.LowerBound();
			var lowerBoundElements = elements.LowerBound();
			var result = (T[])System.Array.CreateInstance(typeof(T), new System.Int32[] { array.Length + elements.Length }, new System.Int32[] { lowerBoundArray });

			for (var i = lowerBoundArray; i < index; i++)
			{
				result[i] = array[i];
			}

			for (var i = 0; i < elements.Length; i++)
			{
				result[i + index] = elements[i + lowerBoundElements];
			}

			for (var i = 0; i < array.Length - (index - lowerBoundArray); i++)
			{
				result[(i + index) + elements.Length] = array[i + index];
			}

			return result;
		}
		#endregion



		#region IsNullOrEmpty
		/// <summary>If this array is null or empty, or does not have at least the specified dimensions.</summary>
		static public System.Boolean IsNullOrEmpty<T>(this T[] array, System.Int32? minimumLength = null)
		{
			// array
			// minimumLength

			return
				(array == null)
				||
				array.All(element => element.Equals(default(T)))
				||
				array.AnyDimensions((input, output) => output < input, minimumLength);
		}

		/// <summary>If this array is null or empty, or does not have at least the specified dimensions.</summary>
		static public System.Boolean IsNullOrEmpty<T>(this T[,] array, System.Int32? minimumRows = null, System.Int32? minimumColumns = null)
		{
			// array
			// minimumRows
			// minimumColumns

			return
				(array == null)
				||
				array.All(element => element.Equals(default(T)))
				||
				array.AnyDimensions((input, output) => output < input, minimumRows, minimumColumns);
		}

		/// <summary>If this array is null or empty, or does not have at least the specified dimensions.</summary>
		static public System.Boolean IsNullOrEmptyJagged<T>(this T[][,] arrays, System.Int32? minimumLength = null, System.Int32? minimumRows = null, System.Int32? minimumColumns = null)
		{
			// arrays
			// minimumLength
			// minimumRows
			// minimumColumns

			return
				(arrays == null)
				||
				arrays.Any(elements => elements == null)
				||
				arrays.AllJagged(element => element.Equals(default(T)))
				||
				arrays.AnyDimensionsJagged((input, output) => output < input, minimumLength, minimumRows, minimumColumns);
		}
		#endregion



		#region IsNullOrSparse
		/// <summary>If this array is null or sparse, or does not have at least the specified dimensions.</summary>
		static public System.Boolean IsNullOrSparse<T>(this T[] array, System.Int32? minimumLength = null)
		{
			// array
			// minimumLength

			return
				(array == null)
				||
				array.Any(element => element.Equals(default(T)))
				||
				array.AnyDimensions((input, output) => output < input, minimumLength);
		}

		/// <summary>If this array is null or sparse, or does not have at least the specified dimensions.</summary>
		static public System.Boolean IsNullOrSparse<T>(this T[,] array, System.Int32? minimumRows = null, System.Int32? minimumColumns = null)
		{
			// array
			// minimumRows
			// minimumColumns

			return
				(array == null)
				||
				array.Any(element => element.Equals(default(T)))
				||
				array.AnyDimensions((input, output) => output < input, minimumRows, minimumColumns);
		}

		/// <summary>If this array is null or sparse, or does not have at least the specified dimensions.</summary>
		static public System.Boolean IsNullOrSparseJagged<T>(this T[][,] arrays, System.Int32? minimumLength = null, System.Int32? minimumRows = null, System.Int32? minimumColumns = null)
		{
			// arrays
			// minimumLength
			// minimumRows
			// minimumColumns

			return
				(arrays == null)
				||
				arrays.Any(elements => elements == null)
				||
				arrays.AnyJagged(element => element.Equals(default(T)))
				||
				arrays.AnyDimensionsJagged((input, output) => output < input, minimumLength, minimumRows, minimumColumns);
		}
		#endregion



		#region LowerBound
		/// <summary>The index of the first element in this array.</summary>
		static public System.Int32 LowerBound<T>(this T[] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLowerBound(0);
		}

		/// <summary>The index of the first element in the columns of this array.</summary>
		static public System.Int32 LowerBoundColumns<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLowerBound(1);
		}

		/// <summary>The index of the first element in the rows of this array.</summary>
		static public System.Int32 LowerBoundRows<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLowerBound(0);
		}
		#endregion



		#region OutOfBounds
		/// <summary>If the specified index is out of bounds.</summary>
		static public System.Boolean OutOfBounds<T>(this T[] array, System.Int32? index)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			// index

			return
				Length();



			System.Boolean Length()
			{
				if (index.HasValue)
				{
					return
						(index.Value < array.LowerBound())
						||
						(index.Value > array.UpperBound());
				}

				return false;
			}
		}

		/// <summary>If the specified row or column is out of bounds.</summary>
		static public System.Boolean OutOfBounds<T>(this T[,] array, System.Int32? row, System.Int32? column)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			// row
			// column

			return
				Rows()
				||
				Columns();



			System.Boolean Rows()
			{
				if (row.HasValue)
				{
					return
						(row.Value < array.LowerBoundRows())
						||
						(row.Value > array.UpperBoundRows());
				}

				return false;
			}

			System.Boolean Columns()
			{
				if (column.HasValue)
				{
					return
						(column.Value < array.LowerBoundColumns())
						||
						(column.Value > array.UpperBoundColumns());
				}

				return false;
			}
		}
		#endregion



		#region Pop
		/// <summary>Removes elements from the end of this array.</summary>
		static public T[] Pop<T>(this T[] array, System.Int32 count = 1)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			// count

			var upperBound = array.UpperBound();

			return array.Remove(System.Math.Max(System.Math.Min(upperBound - (count - 1), upperBound), array.LowerBound()), count);
		}
		#endregion



		#region Push
		/// <summary>Adds elements to the end of this array.</summary>
		static public T[] Push<T>(this T[] array, params T[] elements)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (elements == null) { throw new Eggceptions.ArgumentNullException(nameof(elements)); }

			return array.Insert(array.UpperBound(), elements);
		}
		#endregion



		#region Remove
		/// <summary>Removes elements from this array at the specified index.</summary>
		static public T[] Remove<T>(this T[] array, System.Int32 index, System.Int32 count = 1)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (array.OutOfBounds(index)) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(index)); }
			// count

			if (count < 0 || count > array.Length)
			{
				count = array.Length;
			}

			var lowerBound = array.LowerBound();
			var result = (T[])System.Array.CreateInstance(typeof(T), new System.Int32[] { array.Length - count }, new System.Int32[] { lowerBound });

			for (var i = lowerBound; i < index; i++)
			{
				result[i] = array[i];
			}

			for (var i = 0; i < array.Length - (index - lowerBound) - count; i++)
			{
				result[i + index] = array[i + index + count];
			}

			return result;
		}
		#endregion



		#region Row
		/// <summary>The specified row of this array.</summary>
		static public T[] Row<T>(this T[,] array, System.Int32 row, System.Int32 lowerBound = 0)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (array.OutOfBounds(row, null)) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(row)); }
			// lowerBound

			var columns = array.Columns();
			var result = (T[])System.Array.CreateInstance(typeof(T), new System.Int32[] { columns }, new System.Int32[] { lowerBound });

			var lowerBoundRows = array.LowerBoundRows();
			var lowerBoundColumns = array.LowerBoundColumns();

			for (var column = 0; column < columns; column++)
			{
				result[column + lowerBound] = array[row + lowerBoundRows, column + lowerBoundColumns];
			}

			return result;
		}
		#endregion



		#region RowBind
		/// <summary>Creates a multidimensional array from this jagged array where each element is a row.</summary>
		static public T[,] RowBindJagged<T>(this T[][] arrays, System.Int32 lowerBoundRows = 0, System.Int32 lowerBoundColumns = 0)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			// lowerBoundRows
			// lowerBoundColumns
			if (!arrays.SameDimensionsJagged()) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(arrays)); }

			var arraysLowerBound = arrays.LowerBound();

			var rows = arrays.Length;
			var columns = arrays[arraysLowerBound]?.Length ?? 0; // If all arrays are null then set the number of columns to 0
			var result = (T[,])System.Array.CreateInstance(typeof(T), new System.Int32[] { rows, columns }, new System.Int32[] { lowerBoundRows, lowerBoundColumns });

			for (var row = 0; row < rows; row++)
			{
				if (arrays[row] == null)
				{
					continue;
				}

				var arrayLowerBound = arrays[row].LowerBound();

				for (var column = 0; column < columns; column++)
				{
					result[row + lowerBoundRows, column + lowerBoundColumns] = arrays[row + arraysLowerBound][column + arrayLowerBound];
				}
			}

			return result;
		}
		#endregion



		#region Rows
		/// <summary>The number of rows in this array.</summary>
		static public System.Int32 Rows<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLength(0);
		}
		#endregion



		#region SameDimensions
		/// <summary>If the dimensions of this array are equal to the dimensions of other arrays.</summary>
		static public System.Boolean SameDimensions<T>(this T[] array, params T[][] arrays)
		{
			// array
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }

			return arrays.Unshift(array).SameDimensionsJagged();
		}

		/// <summary>If the dimensions of this array are equal to the dimensions of other arrays.</summary>
		static public System.Boolean SameDimensions<T>(this T[,] array, params T[][,] arrays)
		{
			// array
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }

			return arrays.Unshift(array).SameDimensionsJagged();
		}

		/// <summary>If the dimensions of each element in this jagged array are equal.</summary>
		static public System.Boolean SameDimensionsJagged<T>(this T[][] arrays)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (arrays.Length < 2) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(arrays)); }

			if (arrays.Any(elements => elements == null))
			{
				return arrays.All(elements => elements == null);
			}

			var lowerBound = arrays.LowerBound();
			var upperBound = arrays.UpperBound();

			var firstArray = arrays[lowerBound];
			var firstArrayLowerBound = firstArray.LowerBound();
			var firstArrayUpperBound = firstArray.UpperBound();

			for (var i = lowerBound + 1; i <= upperBound; i++) // Skip firstArray
			{
				if
				(
					(arrays[i].LowerBound() != firstArrayLowerBound)
					||
					(arrays[i].UpperBound() != firstArrayUpperBound)
				)
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>If the dimensions of each element in this jagged array are equal.</summary>
		static public System.Boolean SameDimensionsJagged<T>(this T[][,] arrays)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }
			if (arrays.Length < 2) { throw new Eggceptions.ArgumentOutOfRangeException(nameof(arrays)); }

			if (arrays.Any(elements => elements == null))
			{
				return arrays.All(elements => elements == null);
			}

			var lowerBound = arrays.LowerBound();
			var upperBound = arrays.UpperBound();

			var firstArray = arrays[lowerBound];
			var lowerBoundRows = firstArray.LowerBoundRows();
			var upperBoundRows = firstArray.UpperBoundRows();
			var lowerBoundColumns = firstArray.LowerBoundColumns();
			var upperBoundColumns = firstArray.UpperBoundColumns();

			for (var i = lowerBound + 1; i <= upperBound; i++) // Skip firstArray
			{
				if
				(
					(arrays[i].LowerBoundRows() != lowerBoundRows)
					||
					(arrays[i].UpperBoundRows() != upperBoundRows)
					||
					(arrays[i].LowerBoundColumns() != lowerBoundColumns)
					||
					(arrays[i].UpperBoundColumns() != upperBoundColumns)
				)
				{
					return false;
				}
			}

			return true;
		}
		#endregion



		#region Shift
		/// <summary>Removes elements from the beginning of this array.</summary>
		static public T[] Shift<T>(this T[] array, System.Int32 count = 1)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			// count

			return array.Remove(array.LowerBound(), count);
		}
		#endregion



		#region ToDouble
		/// <summary>Converts each element in this array to <i>System.Double</i>.</summary>
		static public System.Double[] ToDouble<T>(this T[] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.Convert(element => System.Convert.ToDouble(element));
		}

		/// <summary>Converts each element in this array to <i>System.Double</i>.</summary>
		static public System.Double[,] ToDouble<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.Convert(element => System.Convert.ToDouble(element));
		}

		/// <summary>Converts each element in this array to <i>System.Double</i>.</summary>
		static public System.Double[][,] ToDoubleJagged<T>(this T[][,] arrays)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }

			return arrays.ConvertJagged(element => System.Convert.ToDouble(element));
		}
		#endregion



		#region ToSingle
		/// <summary>Converts each element in this array to <i>System.Single</i>.</summary>
		static public System.Single[] ToSingle<T>(this T[] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.Convert(element => System.Convert.ToSingle(element));
		}

		/// <summary>Converts each element in this array to <i>System.Single</i>.</summary>
		static public System.Single[,] ToSingle<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.Convert(element => System.Convert.ToSingle(element));
		}

		/// <summary>Converts each element in this array to <i>System.Single</i>.</summary>
		static public System.Single[][,] ToSingleJagged<T>(this T[][,] arrays)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }

			return arrays.ConvertJagged(element => System.Convert.ToSingle(element));
		}
		#endregion



		#region ToType
		/// <summary>Converts each element in this array to the specified type.</summary>
		static public TOutput[] ToType<TInput, TOutput>(this TInput[] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.Convert(element => (TOutput)System.Convert.ChangeType(element, typeof(TOutput)));
		}

		/// <summary>Converts each element in this array to the specified type.</summary>
		static public TOutput[,] ToType<TInput, TOutput>(this TInput[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.Convert(element => (TOutput)System.Convert.ChangeType(element, typeof(TOutput)));
		}

		/// <summary>Converts each element in this array to the specified type.</summary>
		static public TOutput[][,] ToTypeJagged<TInput, TOutput>(this TInput[][,] arrays)
		{
			if (arrays == null) { throw new Eggceptions.ArgumentNullException(nameof(arrays)); }

			return arrays.ConvertJagged(element => (TOutput)System.Convert.ChangeType(element, typeof(TOutput)));
		}
		#endregion



		#region UpperBound
		/// <summary>The index of the last element in this array.</summary>
		static public System.Int32 UpperBound<T>(this T[] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLowerBound(0) + (array.Length - 1);
		}

		/// <summary>The index of the last element in the columns of this array.</summary>
		static public System.Int32 UpperBoundColumns<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLowerBound(1) + (array.Columns() - 1);
		}

		/// <summary>The index of the last element in the rows of this array.</summary>
		static public System.Int32 UpperBoundRows<T>(this T[,] array)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }

			return array.GetLowerBound(0) + (array.Rows() - 1);
		}
		#endregion



		#region Unshift
		/// <summary>Adds elements to the beginning of this array.</summary>
		static public T[] Unshift<T>(this T[] array, params T[] elements)
		{
			if (array == null) { throw new Eggceptions.ArgumentNullException(nameof(array)); }
			if (elements == null) { throw new Eggceptions.ArgumentNullException(nameof(elements)); }

			return array.Insert(array.LowerBound(), elements);
		}
		#endregion
	}
}
