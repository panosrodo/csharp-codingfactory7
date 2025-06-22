using AutoMapper;
using System.Transactions;
using WebStarter7DBApp.DAO;
using WebStarter7DBApp.DTO;
using WebStarter7DBApp.Exceptions;
using WebStarter7DBApp.Models;

namespace WebStarter7DBApp.Services
{
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDAO _studentDAO;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentServiceImpl> _logger;

        public StudentServiceImpl(IStudentDAO studentDAO, IMapper mapper, ILogger<StudentServiceImpl> logger)
        {
            _studentDAO = studentDAO;
            _mapper = mapper;
            _logger = logger;
        }
        public StudentReadOnlyDTO? InsertStudent(StudentInsertDTO studentInsertDTO)
        {
            StudentReadOnlyDTO studentReadOnlyDTO;
            try
            {
                using TransactionScope scope = new TransactionScope();
                Student student = _mapper.Map<Student>(studentInsertDTO);
                Student? insertedStudent = _studentDAO.Insert(student);
                studentReadOnlyDTO = _mapper.Map<StudentReadOnlyDTO>(insertedStudent);

                scope.Complete();
                return studentReadOnlyDTO;
            }
            catch (TransactionException ex)
            {
                _logger.LogError("Error. Student {Firstname} {Lastname} not inserted. {ErrorMessage}",
                    studentInsertDTO.Firstname, studentInsertDTO.Lastname, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error. Student {Firstname} {Lastname} not inserted. {ErrorMessage}",
                    studentInsertDTO.Firstname, studentInsertDTO.Lastname, ex.Message);
                throw;
            }
        }

        public void UpdateStudent(StudentUpdateDTO studentUpdateDTO)
        {
            Student student;

            try
            {
                using TransactionScope scope = new();
                if (_studentDAO.GetById(studentUpdateDTO.Id) != null)
                {
                    throw new StudentNotFoundException($"Student with id {studentUpdateDTO.Id} not found");

                }
                student = _mapper.Map<Student>(studentUpdateDTO);
                _studentDAO.Update(student);
                scope.Complete();
            }
            catch (StudentNotFoundException ex)
            {
                _logger.LogError("Error. Student with id {Id} not found {ErrorMessage}",
                    studentUpdateDTO.Id, ex.Message);
                throw;
            }
            catch (TransactionException ex)
            {
                _logger.LogError("Error. Student {Firstname} {Lastname} not updated. {ErrorMessage}",
                    studentUpdateDTO.Firstname, studentUpdateDTO.Lastname, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error. Student {Id} {Firstname} {Lastname} could not updated. {ErrorMessage}",
                    studentUpdateDTO.Id, studentUpdateDTO.Firstname, studentUpdateDTO.Lastname, ex.Message);
                throw;
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                using TransactionScope scope = new();
                if (_studentDAO.GetById(id) == null)
                {
                    throw new StudentNotFoundException($"Student with id {id} not found");

                }
                _studentDAO.Delete(id);
                scope.Complete();
            }
            catch (StudentNotFoundException ex)
            {
                _logger.LogError("Error. Student with id {Id} not found. {ErrorMessage}",
                    id, ex.Message);
                throw;
            }
            catch (TransactionException ex)
            {
                _logger.LogError("Error. Student with {Id} not deleted. {ErrorMessage}",
                   id, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error. Student {Id}  could not be deleted. {ErrorMessage}",
                   id, ex.Message);
                throw;
            }
        }

        public StudentReadOnlyDTO GetStudent(int id)
        {
            StudentReadOnlyDTO studentReadOnlDTO;
            Student? student;

            try
            {
                student = _studentDAO.GetById(id);
                if (_studentDAO.GetById(id) == null)
                {
                    throw new StudentNotFoundException($"Student with id {id} not found");
                }
                studentReadOnlDTO = _mapper.Map<StudentReadOnlyDTO>(student);
                return studentReadOnlDTO;
            }
            catch (StudentNotFoundException ex)
            {
                _logger.LogError("Error. Student with id {Id} not found. {ErrorMessage}",
                    id, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error. Student {Id}  could not be returned. {ErrorMessage}",
                   id, ex.Message);
                throw;
            }
        }

        public List<StudentReadOnlyDTO> GetAllStudents()
        {
            StudentReadOnlyDTO studentReadOnlyDTO;
            List<StudentReadOnlyDTO> studentReadOnlyDTOs = new();
            List<Student> students;

            try
            {
                students = _studentDAO.GetAll();

                foreach (Student student in students)
                {
                    studentReadOnlyDTO = _mapper.Map<StudentReadOnlyDTO>(student);
                    studentReadOnlyDTOs.Add(studentReadOnlyDTO);
                }
                return studentReadOnlyDTOs;
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError("Error. Students could not be returned. {ErrorMessage}",
                    ex.Message);
                    throw;
                }
            }
        }
    }
}