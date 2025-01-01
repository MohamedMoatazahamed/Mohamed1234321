﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ProjectController : Controller
    {
       private readonly appdbcontext _context;
        public ProjectController(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
            
        }
        public async  Task<ActionResult> Index()
        {
         var git= await _context.projects.ToListAsync();
            return View(git);
        }

        // GET: ProjectController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var mo=await _context.projects.FirstOrDefaultAsync(o=>o.Id==id);
            var io=await _context.tasks.Where(p=>p.projectID==mo.Id).Include(i=>i.TeamMember).ToListAsync();
            mo.Tasks=io;
            return View(mo);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Project project)
        {
          await _context.projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: ProjectController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var serch=await _context.projects.FirstOrDefaultAsync(i=>i.Id==id);
            return View(serch);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Project project)
        {
           _context.projects.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: ProjectController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var serch = await _context.projects.FirstOrDefaultAsync(i => i.Id == id);
            return View(serch);
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Project project)
        {
           _context.projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
