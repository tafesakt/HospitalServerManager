﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalServerManager.InterfacesAndEnums;
using Newtonsoft.Json;

namespace HospitalServerManager.Model.Basic
{
    class Doctor : SqlTable
    {
        public string Name { get; protected set; }
        public AcademicDegrees _AcademicDegree { get; set; }
        public MedicalSpecializations _MedicalSpecialization { get; set; }
        public string Surname { get; protected set; }
        public DateTime DateOfEmployment { get; protected set; }
        public JobPositions _JobPosition { get; set; }

        protected Doctor() : base()
        {
        }
        public Doctor(int doctorID, string name, string surname, AcademicDegrees academicDegree,
            MedicalSpecializations specialization, DateTime dateOfEmployment, JobPositions jobPosition)
            : base(doctorID.ToString(), "Id_Lekarza", new List<string> { })
        {
            Name = name;
            Surname = surname;
            _AcademicDegree = academicDegree;
            _MedicalSpecialization = specialization;
            DateOfEmployment = dateOfEmployment;
            _JobPosition = jobPosition;
        }
		[JsonConstructor]
		protected Doctor(int doctorID, string name, string surname, string academicDegree,
			string specialization, DateTime dateOfEmployment, string jobPosition)
			: base(doctorID.ToString(), "Id_Lekarza", new List<string> { })
		{
			Name = name;
			Surname = surname;
			_AcademicDegree = academicDegree.GetEnumFromDescription<AcademicDegrees>();
			_MedicalSpecialization = specialization.GetEnumFromDescription<MedicalSpecializations>();
			DateOfEmployment = dateOfEmployment;
			_JobPosition = jobPosition.GetEnumFromDescription<JobPositions>();
		}
		/// <summary>
		/// List have to be in right order (doctor id, name, surname, academic degree, medical specialization,
		/// date of employment, jobposition).
		/// </summary>
		/// <param name="listOfValues"></param>
		public Doctor(List<string> listOfValues) : base(listOfValues[0], "Id_Lekarza", new List<string> { })
        {
            Name = listOfValues[1];
            Surname = listOfValues[2];
            _AcademicDegree = listOfValues[3].GetEnumFromDescription<AcademicDegrees>();
            _MedicalSpecialization = listOfValues[4].GetEnumFromDescription<MedicalSpecializations>();
            DateOfEmployment = DateTime.Parse(listOfValues[5]);
            _JobPosition = listOfValues[6].GetEnumFromDescription<JobPositions>();
        }
    }
}
