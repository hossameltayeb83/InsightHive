﻿namespace InsightHive.Domain.Entities
{
    public class Filter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public ICollection<Option> Options { get; set; } = new HashSet<Option>();
    }
}
