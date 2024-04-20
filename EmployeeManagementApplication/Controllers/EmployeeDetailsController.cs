using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementApplication.Models;
using EmployeeManagementApplication.Services;

namespace EmployeeManagementApplication.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeDetailsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// method to display all the employee details/
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            return View(employees);
        }

        /// <summary>
        /// Get method to display data based of the employee when selected 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: EmployeeDetails/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetails = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }

        /// <summary>
        /// get method to add new employee using unitOfWork repository.
        /// </summary>
        /// <returns></returns>


        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_unitOfWork.DepartmentRepository.GetAll(), "DepartmentId", "DepartmentName");
            ViewData["Projects"] = new SelectList(_unitOfWork.ProjectRepository.GetAll(), "ProjectId", "ProjectName");
            ViewData["Skills"] = new SelectList(_unitOfWork.SkillRepository.GetAll(), "SkillId", "SkillName");
            return View();
        }

        /// <summary>
        /// Post method to update data into the fields using UnitOfWork repository.
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeId,Name,DepartmentId,Details,Experience")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EmployeeRepository.Add(employeeDetails);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_unitOfWork.DepartmentRepository.GetAll(), "DepartmentId", "DepartmentName", employeeDetails.DepartmentId);           
            return View(employeeDetails);
        }

        /// <summary>
        /// Get method to edit the fields using unitOfwork repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: EmployeeDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetails = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            ViewData["DepartmentId"] = new SelectList(_unitOfWork.DepartmentRepository.GetAll(), "DepartmentId", "DepartmentName", employeeDetails.DepartmentId);
            return View(employeeDetails);
        }

        /// <summary>
        /// Post method to update the edidted fields 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>


        // POST: EmployeeDetails/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Edit(int id, [Bind("EmployeeId,Name,DepartmentId,Details,Experience")] EmployeeDetails employeeDetails)
        {
            if (id != employeeDetails.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.EmployeeRepository.Update(employeeDetails);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.EmployeeRepository.Exists(employeeDetails.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_unitOfWork.DepartmentRepository.GetAll(), "DepartmentId", "DepartmentName", employeeDetails.DepartmentId);
            return View(employeeDetails);
        }

        /// <summary>
        /// get method to delete the employee details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: EmployeeDetails/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetails = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }
        /// <summary>
        /// post method to delete the employee details from the table.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _unitOfWork.EmployeeRepository.Delete(id.Value);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }


    }
}
