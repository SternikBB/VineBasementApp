using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Extensions
{
    public static class ReflectionExtrension
    {
        public static List<string> GetObjectDisplayNames <T>(this T myClass) where T : class
        {
            var propertiesNames= new List<string>();
            foreach (var item in myClass.GetType().GetProperties())
            {
                var propertyName = item.CustomAttributes.FirstOrDefault().NamedArguments.Select(c => c.TypedValue).FirstOrDefault().Value.ToString();
                propertiesNames.Add(propertyName);
            }
            return propertiesNames;
        }
    }
}
