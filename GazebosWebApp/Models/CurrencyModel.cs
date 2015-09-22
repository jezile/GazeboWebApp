using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using System.Xml;

namespace GazebosWebApp.Models
{
    public class CurrencyModel
    {
        //[Range(1, double.MaxValue)]
        [Required]
        public string Amount { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal? Ask { get; set; }
        public decimal? Bid { get; set; }
        public string Total { get; set; }
        public string Error { get; set; }

        public CurrencyModel()
        {
            this.Rate = 0;
            this.Ask = 0;
            this.Bid = 0;
            this.Total = "";
            this.Error = "";
        }


        public XmlDocument GetXmlResponse(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);
            }
            catch (Exception e)
            {
                this.Error = e.Message;
                return null;
            }
        }


        public void ProcessEntityElements(XmlDocument response)
        {
            XmlNodeList entryElements = response.GetElementsByTagName("rate");

            for (int i = 0; i <= entryElements.Count - 1; i++)
            {
                XmlElement element = (XmlElement)entryElements[i];
                XmlNodeList nodes = element.SelectNodes("/query/results/rate");
                foreach (XmlNode innerNode in nodes)
                {
                    this.Name = innerNode.SelectSingleNode("Name").InnerText;
                    this.Rate = decimal.Parse(innerNode.SelectSingleNode("Rate").InnerText, CultureInfo.InvariantCulture);
                    this.Date = DateTime.Parse(innerNode.SelectSingleNode("Date").InnerText, CultureInfo.InvariantCulture);
                    this.Time = DateTime.Parse(innerNode.SelectSingleNode("Time").InnerText, CultureInfo.InvariantCulture);
                    this.Ask = decimal.Parse(innerNode.SelectSingleNode("Ask").InnerText, CultureInfo.InvariantCulture);
                    this.Bid = decimal.Parse(innerNode.SelectSingleNode("Bid").InnerText, CultureInfo.InvariantCulture);
                }
            }
        }


        public void RunProcess(string amount,
                               string currencyFrom,
                               string currencyTo)
        {
            if (currencyFrom != "" && currencyTo != "")
            {
                if (currencyFrom != currencyTo)
                {
                    string requestUrl = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair=%22" + currencyFrom + currencyTo + "%22&env=store://datatables.org/alltableswithkeys";
                    XmlDocument response = GetXmlResponse(requestUrl);

                    if (response != null)
                    {
                        ProcessEntityElements(response);

                        decimal n;
                        bool isNumeric = decimal.TryParse(amount, out n);

                        if (isNumeric)
                        {
                            try
                            {
                                decimal dAmount = Convert.ToDecimal(amount);
                                this.Total = (dAmount * this.Rate).ToString("N2");
                                this.Amount = dAmount.ToString("N2");
                            }
                            catch (Exception e)
                            {
                                this.Error = e.Message;
                            }
                        }
                        else
                        {
                            this.Error = "Invalid number";
                        }
                    }
                }
                else
                {
                    this.Error = "You cannot convert " + currencyFrom + " to " + currencyTo + "!";
                }
            }
            else
            {
                this.Error = "Either both or one currency has not been selected";
            }
        }
    }
}