﻿namespace TodoApi.Models
{
    public class TodoItemEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}