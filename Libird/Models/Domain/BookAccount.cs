﻿namespace Libird.Models.Domain
{
    public class BookAccount
    {
       
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
