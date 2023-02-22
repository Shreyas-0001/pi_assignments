using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using empform_ajax.Models;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace empform_ajax.Controllers
{
    public class WorkController : Controller
    {
        private readonly ShreyasTrainingContext _context;

        public WorkController(ShreyasTrainingContext context)
        {
            _context = context;
        }

        // GET: Work
        public async Task<IActionResult> Index()
        {
            var shreyasTrainingContext = _context.As1Employees.Include(a => a.Department).Include(a => a.Designation).Include(a => a.Skills);



            var emp = shreyasTrainingContext.ToList();


            var department_list = _context.As1Departments.ToList();
            var designation_list = _context.As1Designations.ToList();
            var skill_list = _context.As1Skills.ToList();



            ViewBag.designation = designation_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.department = department_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.skill_list = skill_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.Flag = true;
            return View(emp);
        }

        // GET: Work/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.As1Employees == null)
            {
                return NotFound();
            }

            var as1Employee = await _context.As1Employees
                .Include(a => a.Department)
                .Include(a => a.Designation)
                .Include(a => a.Skills)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (as1Employee == null)
            {
                return NotFound();
            }

            return View(as1Employee);
        }

        public async Task<IActionResult> Search(string? query)
        {

            var employee1 = _context.As1Employees
            .FromSqlInterpolated($"EXEC Find {query}")
            .ToList();


            foreach (var i in employee1)
            {
                var emp_dept = _context.As1Departments.Find(i.Departmentid);
                var emp_des = _context.As1Designations.Find(i.Designationid);
                var emp_skills = _context.As1Employees.Where(a => a.Id == i.Id).Include(a => a.Skills).ToList();
                foreach (var k in emp_skills)
                {
                    i.Skills = k.Skills;
                }

                i.Department = emp_dept;
                i.Designation = emp_des;

            }



            if (employee1 == null)
            {
                return NotFound();
            }

            return View(employee1);
        }

        public async Task<IActionResult> AscResult()
        {

            var employee1 = _context.As1Employees
            .FromSqlInterpolated($"EXEC SortByNameAsc")
            .ToList();

            foreach (var i in employee1)
            {
                var emp_dept = _context.As1Departments.Find(i.Departmentid);
                var emp_des = _context.As1Designations.Find(i.Designationid);
                var emp_skills = _context.As1Employees.Where(a => a.Id == i.Id).Include(a => a.Skills).ToList();
                foreach (var k in emp_skills)
                {
                    i.Skills = k.Skills;
                }

                i.Department = emp_dept;
                i.Designation = emp_des;

            }



            if (employee1 == null)
            {
                return NotFound();
            }
            return View("Index", employee1);
        }


        public async Task<IActionResult> DescResult()
        {

            var employee1 = _context.As1Employees
            .FromSqlInterpolated($"EXEC SortByNameDESC")
            .ToList();

            foreach (var i in employee1)
            {
                var emp_dept = _context.As1Departments.Find(i.Departmentid);
                var emp_des = _context.As1Designations.Find(i.Designationid);
                var emp_skills = _context.As1Employees.Where(a => a.Id == i.Id).Include(a => a.Skills).ToList();
                foreach (var k in emp_skills)
                {
                    i.Skills = k.Skills;
                }

                i.Department = emp_dept;
                i.Designation = emp_des;

            }



            if (employee1 == null)
            {
                return NotFound();
            }

            return View("Index", employee1);

        }

        // GET: Work/Create
        public IActionResult Create()
        {
            var department_list = _context.As1Departments.ToList();
            var designation_list = _context.As1Designations.ToList();
            var skill_list = _context.As1Skills.ToList();



            ViewBag.designation = designation_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.department = department_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.skill_list = skill_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            return View();
        }

        // POST: Work/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create_emp(As1Employee as1Employee)
        {
            if (ModelState.IsValid)
            {
                string sk = Request.Form["Skills"];
                List<int> skill_ls = sk.Split(',').Select(int.Parse).ToList();
                List<As1Skill> as_skills = new List<As1Skill>();

                foreach (int id in skill_ls)
                {
                    As1Skill skill = _context.As1Skills.Find(id);
                    as_skills.Add(skill);
                }
                as1Employee.Skills = as_skills;

                _context.Add(as1Employee);
                _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(as1Employee);
        }

        // GET: Work/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.As1Employees == null)
            {
                return NotFound();
            }

            var as1Employee = await _context.As1Employees.FindAsync(id);
            if (as1Employee == null)
            {
                return NotFound();
            }
            ViewData["Departmentid"] = new SelectList(_context.As1Departments, "Id", "Id", as1Employee.Departmentid);
            ViewData["Designationid"] = new SelectList(_context.As1Designations, "Id", "Id", as1Employee.Designationid);
            return View(as1Employee);
        }

        // POST: Work/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Dateofbirth,Gender,Salary,Doj,Departmentid,Designationid")] As1Employee as1Employee)
        {
            if (id != as1Employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(as1Employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!As1EmployeeExists(as1Employee.Id))
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
            ViewData["Departmentid"] = new SelectList(_context.As1Departments, "Id", "Id", as1Employee.Departmentid);
            ViewData["Designationid"] = new SelectList(_context.As1Designations, "Id", "Id", as1Employee.Designationid);
            return View(as1Employee);
        }


        [HttpPost]
        public async Task<IActionResult> EditAll(List<As1Employee> as1Employee, List<passSkills> psk)
        {
            var department_list = _context.As1Departments.ToList();
            var designation_list = _context.As1Designations.ToList();
            var skill_list = _context.As1Skills.ToList();



            ViewBag.designation = designation_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.department = department_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.skill_list = skill_list.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            if (ModelState.IsValid)
            {
                foreach (var i in as1Employee)
                {

                    string sk = "";
                    foreach (var j in psk)
                    {
                        if (j.id == i.Id) { sk = j.ids; }
                    }
                    List<int> skill_ls = sk.Split(',').Select(int.Parse).ToList();
                    List<As1Skill> as_skills = new List<As1Skill>();

                    // Get the list of all skill IDs that are already present in as1_empskill
                    List<int> existingSkillIds = _context.As1Employees
                    .Where(e => e.Id == i.Id)
                    .SelectMany(e => e.Skills.Select(s => s.Id))
                    .ToList();



                    // Remove the records for the skill IDs that are not present in skill_ls
                    foreach (int id in existingSkillIds)
                    {
                        if (!skill_ls.Contains(id))
                        {
                            string str = $"DELETE FROM as1_empskill WHERE empid = {i.Id} AND skillid = {id}";
                            _context.Database.ExecuteSqlRaw(str, i.Id, id);
                        }
                    }



                    // Insert new records for the skill IDs that are present in skill_ls but not in as1_empskill
                    foreach (int id in skill_ls)
                    {
                        if (!existingSkillIds.Contains(id))
                        {
                            string str = $"INSERT INTO as1_empskill VALUES({i.Id},{id})";
                            _context.Database.ExecuteSqlRaw(str);
                        }
                    }


                    _context.Update(i);
                    await _context.SaveChangesAsync();


                }
                foreach (var i in as1Employee)
                {

                    var shreyasTrainingContext = _context.As1Employees
                        .Include(a => a.Skills)
                        .Where(es => es.Id == i.Id).ToList();


                    foreach (var j in shreyasTrainingContext)
                    {
                        i.Skills = j.Skills;

                    }

                }
                ViewBag.Flag = true;
                return View("Index", as1Employee);
                
            }
            else
            {
                //foreach (var i in as1Employee)
                //{

                //    string sk = "";
                //    foreach (var j in psk)
                //    {
                //        if (j.id == i.Id) { sk = j.ids; }
                //    }
                //    List<int> skill_ls = sk.Split(',').Select(int.Parse).ToList();
                //    List<As1Skill> as_skills = new List<As1Skill>();

                //    foreach (var s in skill_ls)
                //    {
                //        As1Skill sk1 = _context.As1Skills.Find(s);
                //        as_skills.Add(sk1);
                //    }
                //    i.Skills = as_skills;
                //}
                
                //ViewBag.Flag = false;
                return View("Index", as1Employee);
                
                
            }

        }


        // GET: Work/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            if (id == null || _context.As1Employees == null)
            {
                return NotFound();
            }

            var as1Employee = await _context.As1Employees
                .Include(a => a.Department)
                .Include(a => a.Designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (as1Employee == null)
            {
                return NotFound();
            }

            return View(as1Employee);
        }

        // POST: Work/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.As1Employees == null)
            {
                return Problem("Entity set 'ShreyasTrainingContext.As1Employees'  is null.");
            }

            var as1Employee = await _context.As1Employees.FindAsync(id);


            string sql = $"DELETE FROM as1_empskill WHERE empid = {id}";
            _context.Database.ExecuteSqlRaw(sql, id);



            if (as1Employee != null)
            {
                _context.As1Employees.Remove(as1Employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool As1EmployeeExists(int id)
        {
            return (_context.As1Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
