using System;

namespace TranslationTool
{
    public class TranslationUnit
    {
        public string? Id { get; set; }
        public string? XliffGeneratorNote { get; set; }
        public string? Source { get; set; }
        public string? Target { get; set; }
        public string? DeveloperNote { get; set; }
        public string? AlObjectTarget { get; set; }
        public string? NabToolNote { get; set; }
    }
}
