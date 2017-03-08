using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using VideoLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace VideoLibrary.ViewModels
{
    public class VideoDetailsViewModel
    {
        public int VideoId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public VideoFormat FormatCode { get; set; }

        public string PlotSummary { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}