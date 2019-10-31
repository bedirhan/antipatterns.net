using AntiPatterns.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace AntiPatterns.Utility
{
    public class OfferParser
    {
        public static List<Offer> GetOffers(Stream input)
        {
            List<Offer> offers = new List<Offer>();

            // NOTE: .NET 4.6.1 doesn't allow external entities to be expanded by default

            XmlReaderSettings settings = new XmlReaderSettings() { DtdProcessing = DtdProcessing.Parse };

            XmlReader xmlReader = XmlReader.Create(input);
            var root = XDocument.Load(xmlReader, LoadOptions.PreserveWhitespace);

            foreach (var offerElement in root.Root.Elements("offer"))
            {
                Offer anOffer = new Offer();
                anOffer.ID = (string)offerElement.Element("id");
                anOffer.Title = (string)offerElement.Element("title");
                anOffer.Reference = (string)offerElement.Element("reference");
                anOffer.Total = (int)offerElement.Element("total");
                offers.Add(anOffer);
            }

            return offers;
        }

        public static List<Offer> QueryOffer(string titleCriteria, string xmlPath)
        {

            //titleCriteria = Microsoft.Security.Application.Encoder.XmlEncode(titleCriteria);

            string filter = "//offer[starts-with(title,'" + titleCriteria + "')]";

            XmlDocument XmlDoc = new XmlDocument();

            XmlDoc.Load(xmlPath);

            XmlNode root = XmlDoc.DocumentElement;

            XmlNodeList nodeList = root.SelectNodes(filter);

            List<Offer> offers = new List<Offer>();

            foreach (XmlNode node in nodeList)
            {
                Offer offer = new Offer();
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Element)
                    {
                        #region offer
                        if (childNode.Name == "id")
                        {
                            offer.ID = childNode.InnerText;
                        }
                        else if (childNode.Name == "title")
                        {
                            offer.Title = childNode.InnerText;
                        }
                        else if (childNode.Name == "total")
                        {
                            offer.Total = Int32.Parse(childNode.InnerText);
                        }
                        else if (childNode.Name == "reference")
                        {
                            offer.Reference = childNode.InnerText;
                        }
                        #endregion
                    }
                }
                offers.Add(offer);
            }

            return offers;
        }
    }
}