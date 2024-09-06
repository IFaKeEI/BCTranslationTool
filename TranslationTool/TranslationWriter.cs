using System;
using System.Linq;
using System.Xml.Linq;

namespace TranslationTool
{
    public class TranslationWriter
    {
        public void WriteXlfFile(string filePath, List<TranslationUnit> translationUnits, string targetLanguage, string originalName)
        {
            XNamespace xliffNs = "urn:oasis:names:tc:xliff:document:1.2";

            XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(xliffNs + "xliff",
                    new XAttribute("version", "1.2"),
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(XName.Get("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance"),
                        "urn:oasis:names:tc:xliff:document:1.2 xliff-core-1.2-transitional.xsd"),
                    new XElement(xliffNs + "file",
                        new XAttribute("datatype", "xml"),
                        new XAttribute("source-language", "en-US"),
                        new XAttribute("target-language", targetLanguage),
                        new XAttribute("original", originalName),
                        new XElement(xliffNs + "body",
                            new XElement(xliffNs + "group",
                                new XAttribute("id", "body"),
                                translationUnits.Select(tu =>
                                {
                                    var transUnitElement = new XElement(xliffNs + "trans-unit",
                                        new XAttribute("id", tu.Id ?? ""),
                                        new XAttribute("size-unit", "char"),
                                        new XAttribute("translate", "yes"),
                                        new XAttribute(XNamespace.Xml + "space", "preserve"),
                                        new XElement(xliffNs + "source", tu.Source),
                                        new XElement(xliffNs + "target", string.IsNullOrEmpty(tu.Target) ? "" : tu.Target)
                                    );

                                    transUnitElement.Add(
                                        new XElement(xliffNs + "note",
                                        new XAttribute("from", "Developer"),
                                        new XAttribute("annotates", "general"),
                                        new XAttribute("priority", "2"),
                                        tu.DeveloperNote)
                                    );

                                    if (!string.IsNullOrEmpty(tu.Target) && tu.Target.Contains("[NAB"))
                                    {
                                        transUnitElement.Add(
                                            new XElement(xliffNs + "note",
                                                new XAttribute("from", "NAB AL Tool Refresh Xlf"),
                                                new XAttribute("annotates", "general"),
                                                new XAttribute("priority", "3"),
                                                tu.NabToolNote)
                                        );
                                    }

                                    if (!string.IsNullOrEmpty(tu.XliffGeneratorNote))
                                    {
                                        transUnitElement.Add(
                                            new XElement(xliffNs + "note",
                                                new XAttribute("from", "Xliff Generator"),
                                                new XAttribute("annotates", "general"),
                                                new XAttribute("priority", "3"),
                                                tu.XliffGeneratorNote)
                                        );
                                    }

                                    if (!string.IsNullOrEmpty(tu.AlObjectTarget))
                                    {
                                        transUnitElement.Add(new XAttribute("al-object-target", tu.AlObjectTarget));
                                    }

                                    return transUnitElement;
                                })
                            )
                        )
                    )
                )
            );

            xdoc.Save(filePath);
        }
    }
}
