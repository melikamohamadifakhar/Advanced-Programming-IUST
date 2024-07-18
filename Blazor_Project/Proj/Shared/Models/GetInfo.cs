using System;
using System.ComponentModel.DataAnnotations;
public class User{
    [Required]
    public string Name{get; set;}
    [Required, Range(12, 150)]
    public int Age{get; set;}
    [Required]
    [EmailAddress]
    public string Email{get; set;}
    [Required]
    public string Address{get; set;}
    [Required, Range(0, 99999999999999)]
    public int ZIP{get; set;}
    [Required, Range(0, 99999999999999)]
    public int AccountNum{get; set;}
}