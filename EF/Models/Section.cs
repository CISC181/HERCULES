﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HERCULES.EF.Models
{
    [Table("SECTION")]
    [Index(nameof(CourseNo), Name = "SECT_CRSE_FK_I")]
    [Index(nameof(InstructorId), Name = "SECT_INST_FK_I")]
    [Index(nameof(SectionNo), nameof(CourseNo), Name = "SECT_SECT2_UK", IsUnique = true)]
    public partial class Section
    {
        public Section()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        [Key]
        [Column("SECTION_ID")]
        public int SectionId { get; set; }
        [Column("COURSE_NO")]
        public int CourseNo { get; set; }
        [Column("SECTION_NO")]
        public byte SectionNo { get; set; }
        [Column("START_DATE_TIME", TypeName = "DATE")]
        public DateTime? StartDateTime { get; set; }
        [Column("LOCATION")]
        [StringLength(50)]
        public string Location { get; set; }
        [Column("INSTRUCTOR_ID")]
        public int InstructorId { get; set; }
        [Column("CAPACITY")]
        public byte? Capacity { get; set; }
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

        [ForeignKey(nameof(CourseNo))]
        [InverseProperty(nameof(Course.Sections))]
        public virtual Course CourseNoNavigation { get; set; }
        [ForeignKey(nameof(SchoolId))]
        [InverseProperty("Sections")]
        public virtual School School { get; set; }
        [InverseProperty(nameof(Enrollment.Section))]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
