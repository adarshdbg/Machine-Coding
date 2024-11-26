using System.Collections.Concurrent;

namespace Parking_Lot.Redis
{
    public class InMemory
    {

        public ConcurrentDictionary<string,Dictionary<string,object>> Dictionary { get; set; }
        public ConcurrentDictionary<string,Type> dictType { get; set; }


        public InMemory() {
            this.Dictionary = new ConcurrentDictionary<string, Dictionary<string, object>>() { };
            this.dictType = new ConcurrentDictionary<string,Type>();
        }

        public Dictionary<string, object> get(string key)
        {
            Dictionary.TryGetValue(key, out var value);
            if (value == null)
                return null;
            return value;
        }
        public List<string> search(string attributeKey, string attributeValue)
        {

            return Dictionary
                    .Where((p)=>p.Value.ContainsKey(attributeKey) && p.Value[attributeKey] == attributeValue)
                    .Select((p) => p.Key)
                    .ToList();
        }
        public void put(string key, List<KeyValuePair<string, string>> listOfAttributePairs)
        {
            var parsedAttributes = new Dictionary<string, object>();
            lock (this) {

                foreach(KeyValuePair<string, string>  data in listOfAttributePairs)
                {
                    ParseValue(data.Key, data.Value);
                    parsedAttributes[data.Key] = data.Value;
                }
                Dictionary[key] = parsedAttributes;
            }

        }

        public void delete(string key)
        {
            Dictionary.TryRemove(key, out var value);
        }
        public List<string> keys()
        {
            return Dictionary.Keys.ToList();
        }

        private object ParseValue(string attributeKey, string attributeValue)
        {
            object value = null;
            if (int.TryParse(attributeValue, out int intVal)) value = intVal;
            else if (long.TryParse(attributeValue, out long longVal)) value = longVal;
            else if (float.TryParse(attributeValue, out float floatVal)) value = floatVal;
            else if (double.TryParse(attributeValue, out double doubleVal)) value = doubleVal;
            else if (bool.TryParse(attributeValue, out bool boolVal)) value = boolVal;
            else
                value = attributeValue;

            if (dictType.ContainsKey(attributeKey))
            {
                if (dictType[attributeKey].GetType() != attributeValue.GetType())
                    throw new Exception("invalid type");
            }
            else
                dictType[attributeValue] = attributeValue.GetType();    
            return value;

        }
    }
}
