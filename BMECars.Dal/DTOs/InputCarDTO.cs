using BMECars.Dal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMECars.Dal.DTOs
{
    public class InputCar
    {
        [Required(ErrorMessage = "'Brand' can't be empty.")]
        [DataType(DataType.Text)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "'Price' can't be empty.")]
        [Range(0, int.MaxValue)]
        public int? Price { get; set; }

        [Required(ErrorMessage = "'Year' can't be empty.")]
        [Range(1990, 2019)]
        public int? Year { get; set; }

        [Required(ErrorMessage = "'Seat' can't be empty.")]
        [Range(2, int.MaxValue)]
        public int? Seat { get; set; }

        [Required(ErrorMessage = "'Bag' can't be empty.")]
        [Range(1, int.MaxValue)]
        public int? Bag { get; set; }

        [Required(ErrorMessage = "'Door' can't be empty.")]
        [Range(2, int.MaxValue)]
        public int? Door { get; set; }

        [Required(ErrorMessage = "'Category' can't be empty.")]
        public Category? Category { get; set; }

        [Required(ErrorMessage = "'Transmission' can't be empty.")]
        public Transmission? Transmission { get; set; }

        [Required(ErrorMessage = "'Gas' can't be empty.")]
        public Boolean? IsFuelFull { get; set; }

        [Required(ErrorMessage = "'Climate' can't be empty.")]
        public Boolean? Climate { get; set; }

        [Required(ErrorMessage = "'Company' can't be empty.")]
        public int CompanyId { get; set; }
        
        [Required(ErrorMessage = "'Country' can't be empty.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "'City' can't be empty.")]
        public string City { get; set; }

        [Required(ErrorMessage = "'Pick Up' can't be empty.")]
        public string Address { get; set; }



        public string Image { get; set; }
    }
}
