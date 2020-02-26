using System;
using System.Configuration;

namespace Tests
{

    public class PageBaseDto
    {
        public string Title { get; set; }
        public string Confirmation { get; set; }
        public string Request { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
        public string Message { get; set; }

        //Search
        public string SearchOk { get; set; }
        public string WrongSearch { get; set; }
       
    }
}