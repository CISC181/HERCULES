﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HERCULES.EF.Models
{
    [Table("ENROLLMENT")]
    [Index(nameof(SectionId), Name = "ENR_SECT_FK_I")]
    public partial class Enrollment
    {
        [Key]
        [Column("STUDENT_ID")]
        public int StudentId { get; set; }
        [Key]
        [Column("SECTION_ID")]
        public int SectionId { get; set; }
        [Column("ENROLL_DATE", TypeName = "DATE")]
        public DateTime EnrollDate { get; set; }
        [Column("FINAL_GRADE")]
        public byte? FinalGrade { get; set; }
        [Required]
        [Column("CREATED_BY")]
        [StringLength(30)]
        public string CreatedBy { get; set; }
        [Column("CREATED_DATE", TypeName = "DATE")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column("MODIFIED_BY")]
        [StringLength(30)]
        public string ModifiedBy { get; set; }
        [Column("MODIFIED_DATE", TypeName = "DATE")]
        public DateTime ModifiedDate { get; set; }
        [Column("SCHOOL_ID")]
        public int SchoolId { get; set; }

        [ForeignKey(nameof(SchoolId))]
        [InverseProperty("Enrollments")]
        public virtual School School { get; set; }
        [ForeignKey(nameof(SectionId))]
        [InverseProperty("Enrollments")]
        public virtual Section Section { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Enrollments")]
        public virtual Student Student { get; set; }
    }
}
