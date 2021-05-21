using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace LessonMonitor.API.Models
{
    public class LogModel
    {
        public string Protocol { get; set; }
        public string Method { get; set; }
        public string Scheme { get; set; }
        public string QueryString { get; set; }
        public ICollection<StringValues> Headers { get; set; }
        public string RequestBody { get; set; }

        public override string ToString()
        {
            return $"Protocol: {Protocol};\n\rMethod: {Method};\n\r" +
                   $"Scheme: {Scheme};\n\rQueryString: {QueryString};\n\rRequest: {RequestBody}";
        }

        public void Loging()
        {
            Console.Clear();
            Console.WriteLine(this);
            if(Headers is not null)
            {
                Console.WriteLine("Headers:");
                foreach (var header in Headers)
                {
                    foreach (var item in header)
                    {
                        Console.WriteLine($"    : {item}");
                    }
                }
            }
        }
    }
}
