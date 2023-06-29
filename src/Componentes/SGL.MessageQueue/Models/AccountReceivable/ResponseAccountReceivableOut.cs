using System;

namespace SGL.MessageQueue.Models.AccountReceivable
{
    public class ResponseAccountReceivableOut
    {
        public Guid Id { get; set; }
        public Guid CustonerId { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public string? Status { get; set; }
    }
}
