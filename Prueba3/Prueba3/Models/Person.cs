namespace Prueba3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Student = new HashSet<Student>();
        }

        public int PersonId { get; set; }

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string MiddelInitial { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }

        public List<Person> Listar()//retorna una coleccion
        {
            var objsemestre = new List<Person>();
            try
            {
                using (var db = new Model1())
                {
                    objsemestre = db.Person.ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objsemestre;
        }



        public Person Obtener(int id) //retorna solo un objeto
        {
            var objSemestre = new Person();
            try
            {
                using (var db = new Model1())
                {
                    objSemestre = db.Person.
                        Where(x => x.PersonId== id).
                        SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.PersonId > 0)
                    {
                        //si existe un valor mayor que cero es por que existe el registro
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        ///no existe el registro lo graba (Nuevo)
                        db.Entry(this).State = EntityState.Added;

                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Eliminar()
        {
            try
            {
                using (var db = new Model1())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
