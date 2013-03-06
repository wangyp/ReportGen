using WordDocumentGenerator.Library;

namespace ReportGen.Service.Generator
{
    public abstract class WordReportGenerator : DocumentGenerator
    {
        public const string SubscribeSummary = "SubscribeSummary";

        protected WordReportGenerator(DocumentGenerationInfo generationInfo) : base(generationInfo)
        {
        }

        public static WordReportGenerator Create(string name, DocumentGenerationInfo generationInfo)
        {
            switch (name)
            {
                case "SubscribeSummary":
                    return new SubscribeSummary(generationInfo);
                    break;
                default:
                    break;
            }
            
            return null;
        }
    }
}
