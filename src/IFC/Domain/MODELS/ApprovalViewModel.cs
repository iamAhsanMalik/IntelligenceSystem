namespace IFC.Domain.MODELS;
public class ApprovalViewModel
{
        public int Id { get; set; }
        public DateTime? InitiatedOn { get; set; }
        public string?ApprovalStatus { get; set; }
        public string?ApprovalRequestType { get; set; }
}