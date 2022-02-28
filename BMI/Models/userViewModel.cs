using System;
using System.ComponentModel.DataAnnotations;
namespace BMI.Models
{
    public class userViewModel
    {
        public userViewModel()
        {

        }
        public userViewModel(string f, string l, string g, int m, int d, int y, int h, int w)
        {
            this.f = f;
            this.l = l;
            this.g = g;
            this.m = m;
            this.d = d;
            this.y = y;
            this.h = h;
            this.w = w;
        }

        [Required]
        [MaxLength(20)]
        public string f, l;
        [Required]
        public string g;
        [Required]
        [Range(1,12)]
        public int? m;
        [Required]
        [Range(1,31)]
        public int? d;
        [Required]
        [Range(1900,2022)]
        public int? y;
        [Required]
        [Range(48,108)]
        public int? h;
        [Range(50,500)]
        [Required]
        public int? w;

        //calc
        //years
        public TimeSpan age;
        public int hr;
        public int bmi;
    }
}
