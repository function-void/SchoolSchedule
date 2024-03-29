﻿using SchoolSchedule.Domain.SeedWork;
using SchoolSchedule.Domain.EducationalClassAggregate;
using SchoolSchedule.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSchedule.Domain.LessonAggregate;

public class Teacher
{
    private readonly HashSet<Subject> _subjects = new();
    private readonly List<Lesson> _lessons = new();
    private EducationalClass? _educationalClass;

    public Teacher(Guid id, List<Subject> subjects, string fullName)
    {
        (Id, FullName) = (id, fullName);
        AddTeachingSubjects(subjects);
    }

    public Teacher(Guid id, Subject subject, string fullName)
    {
        (Id, FullName) = (id, fullName);
        _subjects.Add(subject);
    }

    public Guid Id { get; set; }
    public string FullName { get; init; }
    public IReadOnlyCollection<Subject> Subjects => _subjects.ToList();
    public Guid? EducationalClassId { get; set; }
    public EducationalClass? EducationalClass => _educationalClass;
    public IReadOnlyCollection<Lesson> Lessons => _lessons;

    public void AddTeachingSubject(Subject subject)
    {
        if (
            subject != null
            && !_subjects.Contains(subject)
            )
        {
            _subjects.Add(subject);
            return;
        }

        throw new ArgumentException(nameof(this.AddTeachingSubject), nameof(subject));
    }

    private void AddTeachingSubjects(List<Subject> subjects)
    {
        if (
            subjects != null
            && subjects.Any()
            && !subjects.HasDuplications()
            && !_subjects.Any(x => subjects.Contains(x))
            )
        {
            foreach (var subject in subjects)
            {
                _subjects.Add(subject);
            }

            return;
        }

        throw new ArgumentException(nameof(this.AddTeachingSubjects), nameof(subjects));
    }

    public void BecomeClassTeacher(EducationalClass @class)
    {
        if (
            @class != null 
            && @class.ClassroomTeacher == this
            )
        {
            _educationalClass = @class;
            return;
        }

        throw new ArgumentNullException(nameof(this.BecomeClassTeacher), nameof(@class));
    }
}

