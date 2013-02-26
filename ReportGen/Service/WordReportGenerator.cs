using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordDocumentGenerator.Library;

namespace ReportGen.Service
{
    public class WordReportGenerator : DocumentGenerator
    {
        public WordReportGenerator(DocumentGenerationInfo generationInfo) : base(generationInfo)
        {
        }

        protected override Dictionary<string, PlaceHolderType> GetPlaceHolderTagToTypeCollection()
        {
            throw new NotImplementedException();
        }

        protected override void IgnorePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            throw new NotImplementedException();
        }

        protected override void NonRecursivePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            throw new NotImplementedException();
        }

        protected override void RecursivePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            throw new NotImplementedException();
        }

        protected override void ContainerPlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            throw new NotImplementedException();
        }
    }
}
