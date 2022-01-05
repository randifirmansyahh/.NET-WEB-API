using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiswaController
    {
        //[Route("semuasiswa")] controller/semuasiswa
        [Route("/Semuasiswa")] //semuasiswa
        [HttpGet]
        public object Get()
        {
            //MATIKAN SERTIFIKAT SSL DI POSTMAN
            var namaVariable = new List<Siswa>();

            namaVariable.Add(new Siswa { ID = 1, Nama = "Randi" });
            namaVariable.Add(new Siswa { ID = 2, Nama = "Usman" });

            return new { data = namaVariable};
        }

        [Route("/Siswa")]
        [HttpGet]
        public object Get(int id)
        {
            var namaVariable = new List<Siswa>();

            namaVariable.Add(new Siswa { ID = 1, Nama = "Randi" });
            namaVariable.Add(new Siswa { ID = 2, Nama = "Usman" });

            var result = namaVariable.Where(x => x.ID == id).FirstOrDefault();

            if (result != null)
            {
                return new { data = result}; ;
            }
            return new { data = new { status = 204, message = "Data tidak ditemukan" }};
        }

        [HttpPost]
        public object Post(Siswa parameter)
        {
            var namaVariable = new List<Siswa>();

            namaVariable.Add(new Siswa { ID = parameter.ID, Nama = parameter.Nama });

            if (parameter!= null)
            {
                return new { message = "siswa berhasil ditambahkan", data = namaVariable };
            }
            return pesanJson(204, "Data tidak berhasil ditambahkan");
        }

        [HttpPut]
        public object Put(int id)
        {
            var namaVariable = new List<Siswa>();

            namaVariable.Add(new Siswa { ID = 1, Nama = "Randi" });
            namaVariable.Add(new Siswa { ID = 2, Nama = "Udin" });

            var result = namaVariable.Where(x => x.ID == id).FirstOrDefault();

            if (result != null)
            {
                return new { message="update berhasil", data = result };
            }
            return pesanJson(204,"Update tidak berhasil, data tidak ditemukan");
        }

        [HttpDelete]
        public object Delete(int id)
        {
            var namaVariable = new List<Siswa>();

            namaVariable.Add(new Siswa { ID = 1, Nama = "Randi" });
            namaVariable.Add(new Siswa { ID = 2, Nama = "Udin" });

            var result = namaVariable.Where(x => x.ID == id).FirstOrDefault();

            if (result != null)
            {
                return new { message = "delete berhasil", data = result };
            }
            return pesanJson(204, "Hapus gagal, Data tidak ditemukan");
        }

        private object pesanJson(int status, string pesan)
        {
            var result = new JsonMessage();
            result.status = status;
            result.message = pesan;
            return result;
        }
    }
}