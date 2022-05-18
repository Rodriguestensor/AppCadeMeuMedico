using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppCadeMeuMedico.Models;

namespace AppCadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

       

        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(c=>c.Cidades).Include(c=>c.Especialidades).ToList();
            return View(medicos);
        }
        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            return View();

        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                
                   
                        db.Medicos.Add(medico);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    
                
                
              
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome",medico.IDEspecialidade);
            return View(medico);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var medico = db.Medicos.Find(id);
            return View("Editar", medico);
        }

        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            db.Entry(medico).State = EntityState.Modified;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Editar(long id)
        //{

        //    Medicos medico = db.Medicos.Find(id);
        //    ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
        //    ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);
        //    return View(medico);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Editar(/*[Bind(Include = "IDMedico,CRM,Nome,Endereco,Bairro,Email,AtendePorConvenio,TemClinica,WebsiteBlog,IDCidade,IDEspecialidade")]*/ Medicos medico, long id)
        //{


        //    if (ModelState.IsValid)
        //    {

        //        Medicos medicos = db.Medicos.Find(id);

        //        //medicos. = true;
        //        //db.Entry(medico).State = EntityState.Modified;


        //        //db.Entry(medico).State = EntityState.Modified;
        //        db.Entry(medico).State = EntityState.Detached;

        //        //set the state from the entity that you just received to modified 
        //        db.Entry(medicos).State = EntityState.Modified;
        //        db.SaveChanges();
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }

        //    ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
        //    ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);
        //    return View(medico);
        //}

        //public void Update(Medicos medicos,int id)
        //{
        //    //first find the entity to update
        //    Medicos oldEntity = DbSet.Find(id);

        //    //detach this entity from the DbSet
        //    Db.Entry(oldEntity).State = EntityState.Detached;

        //    //set the state from the entity that you just received to modified 
        //    Db.Entry(obj).State = EntityState.Modified;
        //}
        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Medicos medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }

    }
}