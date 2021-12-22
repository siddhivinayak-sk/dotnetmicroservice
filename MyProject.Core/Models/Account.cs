using System;

namespace MyProject.Core.Models
{
    public class Account
    {
        public int AccId { get; set; }
        public int CusId { get; set; }
        public string AccName { get; set; }
        public string AccBalance { get; set; }
        public bool Status { get; set; }
    }
}