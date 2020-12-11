using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models {
    public class Customer {
        public int Id { get; set; }

        [Required (ErrorMessage = "Không được để trống tên")]
        [MaxLength(40, ErrorMessage = "Phải ít hơn 40 kí tự")]
        public string Name { get; set; }

        [RegularExpression (@"^[0-9]{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public SEX Sex { get; set; }
        [NotMapped]
        public string SexName { get { return EnumConverter.Convert(this.Sex); } }

        public CUSTOMER_STATUS Status { get; set; }
        [NotMapped]
        public string StatusName { get { return EnumConverter.Convert(this.Status); } }

        [RegularExpression (@"^[a-zA-Z0-9]+@[a-zA-Z]+.[a-zA-Z]+$", ErrorMessage = "Email ko hợp lệ")]
        [Required (ErrorMessage = "Không được để trống tên tài khoản")]
        [MinLength (5, ErrorMessage = "Phải có ít nhất 5 ký tự")]
        [MaxLength(30, ErrorMessage = "Phải ít hơn 30 kí tự")]
        public string Username { get; set; }

        [MinLength (5, ErrorMessage = "Phải có ít nhất 5 ký tự")]
        [MaxLength(30, ErrorMessage = "Phải ít hơn 30 kí tự")]
        [Required (ErrorMessage = "Không được để trống mật khẩu")]
        public string Password { get; set; }

        [NotMapped]
        [Required (ErrorMessage = "Không được để trống mật khẩu")]
        [Compare (nameof (Password), ErrorMessage = "Không khớp với mật khẩu.")]
        public string ConfirmPassword { get; set; }


        public virtual IList<Order> Orders { get; set; }

        public Customer (string name, string phoneNumber, string address, SEX sex, string username, string password, CUSTOMER_STATUS status = CUSTOMER_STATUS.ACTIVE) {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Sex = sex;
            Status = status;
            Username = username;
            Password = password;
        }

        public Customer () { }
        public Customer (Customer customer) { this.Copy (customer);  }

        public void Copy (Customer customer) {
            Name = customer.Name;
            PhoneNumber = customer.PhoneNumber;
            Address = customer.Address;
            Sex = customer.Sex;
            Status = customer.Status;
            Username = customer.Username;
            Password = customer.Password;
        }
    }
}