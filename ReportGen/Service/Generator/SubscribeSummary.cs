using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;
using ReportGen.Model;
using WordDocumentGenerator.Library;

namespace ReportGen.Service.Generator
{
    public class SubscribeSummary : WordReportGenerator
    {
        protected const string Name = "Name";
        protected const string Issuer = "Issuer";
        protected const string IssueYear = "IssueYear";
        protected const string BondStage = "BondStage";
        protected const string BondType = "BondType";
        protected const string BondAmount = "BondAmount";
        protected const string BondMaxRate = "BondMaxRate";
        protected const string BondMinRate = "BondMinRate";
        protected const string BuyFloorAmount = "BuyFloorAmount";
        protected const string BuyStepAmount = "BuyStepAmount";
        protected const string BondDeclareDate = "BondDeclareDate";
        protected const string BondIssueDate = "BondIssueDate";


        public SubscribeSummary(DocumentGenerationInfo generationInfo) : base(generationInfo)
        {
        }

        protected override Dictionary<string, PlaceHolderType> GetPlaceHolderTagToTypeCollection()
        {            
            Dictionary<string, PlaceHolderType> placeHolderTagToTypeCollection = new Dictionary<string, PlaceHolderType>();

            placeHolderTagToTypeCollection.Add(Name, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(Issuer, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(IssueYear, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BondStage, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BondType, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BondAmount, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BondMaxRate, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BondMinRate, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BuyFloorAmount, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BuyStepAmount, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BondDeclareDate, PlaceHolderType.NonRecursive);
            placeHolderTagToTypeCollection.Add(BondIssueDate, PlaceHolderType.NonRecursive);

            return placeHolderTagToTypeCollection;

        }

        protected override void IgnorePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
        }

        protected override void NonRecursivePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            if (openXmlElementDataContext == null || openXmlElementDataContext.Element == null || openXmlElementDataContext.DataContext == null)
            {
                return;
            }

            string tagPlaceHolderValue = string.Empty;
            string tagGuidPart = string.Empty;
            GetTagValue(openXmlElementDataContext.Element as SdtElement, out tagPlaceHolderValue, out tagGuidPart);

            string tagValue = string.Empty;
            string content = string.Empty;
            ReportData data = ((openXmlElementDataContext.DataContext) as ReportData);
            var property = typeof (ReportData).GetProperty(tagPlaceHolderValue);
            if (property != null)
            {
                var v = property.GetValue(data, null);
                if (v is DateTime)
                {
                    content = ((DateTime) v).ToShortDateString();
                }
                else if (v is string)
                {
                    content = v.ToString();
                }
                else
                {
                    content = v.ToString();
                }
                
            }

            // Set text without data binding
            this.SetContentOfContentControl(openXmlElementDataContext.Element as SdtElement, content);
        }

        protected override void RecursivePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
        }

        protected override void ContainerPlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
        }
    }
}
