namespace LocknCharm.Domain.Enums
{
    public enum OrderStatus
    {
        Created = 1,     // Đơn hàng vừa được tạo
        Paid = 2,        // Đã thanh toán
        Processing = 3,  // Đang xử lý
        Shipped = 4,     // Đã gửi đi
        Completed = 5,   // Đã giao thành công
        Cancelled = 6    // Đã hủy
    }
}
