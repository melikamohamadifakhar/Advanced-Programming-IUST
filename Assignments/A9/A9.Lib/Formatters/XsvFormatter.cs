using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Logger
{
    public class XsvFormatter : ILogFormatter
    {
        public XsvFormatter(char c){ character = c;}
        
        public char character;

        public string Header => $"level{character}date{character}source{character}threadId{character}ProcessId{character}message{character}name:value pairs";

        public string Footer => string.Empty;

        public string FileExtention => "log";

        public string Format(LogEntry entry)
        {
            return $"{entry.Level.ToString()}{character}{entry.DateTime.ToString()}{character}{entry.Source.ToString()}," +
                   $"{entry.ThreadId.ToString()}{character}{entry.ProcessId}{character}{entry.Message}," +
                    string.Join(character.ToString(), entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'"));
        }
    }
}
