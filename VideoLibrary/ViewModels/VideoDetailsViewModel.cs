using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using VideoLibrary.Models;

namespace VideoLibrary.ViewModels
{
    public class VideoDetailsViewModel
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        
        private string _Plot;
        public string Plot
        {
            get
            {
                if (_Plot == null && !String.IsNullOrWhiteSpace(this.Title))
                {
                    LoadExtendedInfo();
                }
                return _Plot;
            }
        }

        private string _PosterUrl;
        public string PosterUrl
        {
            get
            {
                if (_PosterUrl == null && !String.IsNullOrWhiteSpace(this.Title))
                {
                    LoadExtendedInfo();
                }
                return _PosterUrl;
            }
        }

        public ICollection<Review> Reviews { get; set; }

        private void LoadExtendedInfo()
        {
            // Another site can be used to obtain the poster and plot data.  This is the one I decided
            // to use.
            string movieInfoLink = String.Format("http://www.omdbapi.com/?t={0}&r=XML", this.Title);

            using (var reader = XmlReader.Create(movieInfoLink))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "movie"))
                    {
                        if (reader.HasAttributes)
                        {
                            this._PosterUrl = (reader.GetAttribute("poster"));

                            string xmlPlot = (reader.GetAttribute("plot"));
                            
                            // Decode escaped chars
                            this._Plot = HttpUtility.HtmlDecode(xmlPlot);

                        }
                    }
                }
            }
        }
    }
}