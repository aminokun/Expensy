namespace Expensy.Models
{
    public class GroupDetailsViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<string> Users { get; set; }
    }
}