﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNote.Models
{
    public class NoteModel
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public NoteModel(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
}
