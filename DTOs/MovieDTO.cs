﻿using System.Collections.Generic;

namespace UniversityApp.BL.DTOs
{
    public class MovieDTO
    {
        public List<SearchDTO> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }

    public class SearchDTO
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}