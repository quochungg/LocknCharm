using System.Text.RegularExpressions;

namespace LocknCharm.Application.DTOs.Role
{
    public class UpdateRoleDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public void ValidateFields()
        {
            ValidateField(Name!, "Tên vai trò");
            ValidateField(FullName!, "FullName");
        }

        // Phương thức riêng để xác thực từng trường
        private void ValidateField(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} không thể để trống hoặc chỉ chứa khoảng trắng.", fieldName);
            }

            value = value.Trim();

            if (value.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch)))
            {
                throw new ArgumentException($"{fieldName} không được chứa ký tự đặc biệt.", fieldName);
            }
            else if (fieldName.Equals("FullName", StringComparison.OrdinalIgnoreCase))
            {
                if (value != value.Trim())
                {
                    throw new ArgumentException($"{fieldName} không được chứa khoảng trắng đầu hoặc cuối.", fieldName);
                }
                if (Regex.IsMatch(value, @"\s{2,}"))
                {
                    throw new ArgumentException($"{fieldName} không được chứa nhiều khoảng trắng liên tiếp giữa các từ.", fieldName);
                }
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException($"{fieldName} không được chứa số.", fieldName);
                }
            }
            else if (fieldName.Equals("Tên vai trò", StringComparison.OrdinalIgnoreCase))
            {
                if (value.Contains(" "))
                {
                    throw new ArgumentException($"{fieldName} không được chứa khoảng trắng.", fieldName);
                }
            }
            else
            {
                throw new ArgumentException($"Trường không xác định: {fieldName}", fieldName);
            }
        }

    }
}
