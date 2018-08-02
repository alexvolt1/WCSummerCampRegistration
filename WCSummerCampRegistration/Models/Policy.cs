using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class Policy
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "acac Summer Camp Policies and Procedures")]
        public string PoliciesAndProcedures { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Drop off Procedure")]
        public string DropOffProcedure { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Pick-Up Procedure")]
        public string PickUpProcedure { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Late Pick-Up")]
        public string LatePickUp { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Illness")]
        public string Illness { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Lunch")]
        public string Lunch { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Visiting")]
        public string Visiting { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Safety Policy")]
        public string SafetyPolicy { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Photo Consent")]
        public string PhotoConsent { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Necessary Forms")]
        public string NecessaryForms { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "What to Bring")]
        public string WhatToBring { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Late Registration")]
        public string LateRegistration { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Disease")]
        public string Disease { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Communicating an Emergency")]
        public string CommunicatingAnEmergency { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Medicine")]
        public string Medicine { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Acceptable/Unacceptable Behavior")]
        public string AcceptableUnacceptableBehavior { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [Display(Name = "Reporting Child Abuse and Neglect")]
        public string ReportingChildAbuse { get; set; }

    }
}
