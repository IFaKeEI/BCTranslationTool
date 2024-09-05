using System;
using System.Linq;
using System.Xml.Linq;

namespace TranslationTool
{
    public class TranslationParser
    {
        public List<TranslationUnit>? ParseXlfFile(string filePath, out string originalName, out string targetLanguage)
        {
            XDocument xDoc = XDocument.Load(filePath);

            var fileElement = xDoc?.Root?.Element(XName.Get("file", "urn:oasis:names:tc:xliff:document:1.2"));
            originalName = fileElement?.Attribute("original")?.Value ?? "";
            targetLanguage = fileElement?.Attribute("target-language")?.Value ?? "";

            XNamespace ns = "urn:oasis:names:tc:xliff:document:1.2";

            var translationUnits = xDoc?.Descendants(ns + "trans-unit").Select(node =>
            {
                return new TranslationUnit
                {
                    Id = node.Attribute("id")?.Value,
                    Source = node.Element(ns + "source")?.Value,
                    Target = node.Element(ns + "target")?.Value,
                    DeveloperNote = node.Elements(ns + "note")
                                        .FirstOrDefault(n => n.Attribute("from")?.Value == "Developer")?.Value,
                    XliffGeneratorNote = node.Elements(ns + "note")
                                            .FirstOrDefault(n => n.Attribute("from")?.Value == "Xliff Generator")?.Value,
                    NabToolNote = node.Elements(ns + "note")
                                      .FirstOrDefault(n => n.Attribute("from")?.Value == "NAB AL Tool Refresh Xlf")?.Value,
                    AlObjectTarget = node.Attribute("al-object-target")?.Value
                };
            }).ToList();

            return translationUnits;
        }
    }
}
