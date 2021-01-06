using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TodoApp
{
    public class Todo
    {
        public int Id { get; set; }
        [DisplayName("概要")]
        public string Summary { get; set; }
        [DisplayName("詳細")]
        public string Detail { get; set; }
        [DisplayName("期限")]
        public DateTime Limit { get; set; }
        [DisplayName("終了")]
        public bool Done { get; set; }
    }
}