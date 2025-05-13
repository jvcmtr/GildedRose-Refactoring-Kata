
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GildedRoseKata.Utils;
 public class Table<T>   
    {
        private readonly Dictionary<(string row, string column), T> _data = new();

        public T this[string row, string column]
        {
            get
            {
                if (_data.TryGetValue((row, column), out var value))
                {
                    return value;
                }
                throw new KeyNotFoundException($"No entry found at row '{row}', column '{column}'.");
            }
            set
            {
                _data[(row, column)] = value;
            }
        }

        public bool TryGetValue(string row, string column, out T value)
        {
            return _data.TryGetValue((row, column), out value);
        }

        public bool Contains(string row, string column)
        {
            return _data.ContainsKey((row, column));
        }

        public IEnumerable<string> GetRows()
        {
            var rows = new HashSet<string>();
            foreach (var key in _data.Keys)
            {
                rows.Add(key.row);
            }
            return rows;
        }

        public IEnumerable<string> GetColumns()
        {
            var columns = new HashSet<string>();
            foreach (var key in _data.Keys)
            {
                columns.Add(key.column);
            }
            return columns;
        }

        public IEnumerable<(string Row, string Column, T Value)> ToList()
        {
            foreach (var kvp in _data)
            {
                yield return (kvp.Key.row, kvp.Key.column, kvp.Value);
            }
        }

        public string GetFormated(string separator = "___|_", char spacer = '_', Alignment alignment = Alignment.ALIGN_CENTER )
        {
            string result = "";
            var cells = ToList();

            var columns = _data.Keys.Select(key => key.column).Distinct().ToList();
            var rows = _data.Keys.Select(key => key.row).Distinct().ToList();
            var rowMaxLen = rows.Select(r => r.Length).Max();

            Dictionary<string, int> maxLengths = new Dictionary<string, int>();
            
            foreach(var cell in cells ){ 
                if(maxLengths.TryGetValue(cell.Column, out int existing)){
                    if (existing < cell.Value.ToString().Length){
                        maxLengths[cell.Column] = cell.Value.ToString().Length;
                    }
                }
                else{
                    var size = cell.Value.ToString().Length > cell.Column.Length ? 
                        cell.Value.ToString().Length 
                        : cell.Column.Length ;  
                    maxLengths[cell.Column] = size;
                }
            }

            string getCenteredValue(string value, int maxLen){
                return ConsoleViewUtils.getCenteredValue(value.Replace(' ', spacer), maxLen, spacer, alignment);
            }

            string getLineBreak(){
                string r = "\n";
                return r;
            }

            // Add headers
            result += getCenteredValue("", rowMaxLen );
            result += separator;
            foreach (var column in columns)
            {
                result += getCenteredValue(column, maxLengths[column]);
                result += separator;
            }
            result += getLineBreak();

            // Add each entry
            foreach (var row in rows)
            {
                result += getCenteredValue(row, rowMaxLen );
                result += separator;
             
                foreach (var column in columns)
                {
                    result += getCenteredValue(this[row, column].ToString(), maxLengths[column]);
                    result += separator;
                }
                result += getLineBreak();
            }
            return result;
        
        }
    
    }