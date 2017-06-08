using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENTIDADES;
using DAO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Paciente p = null;
       

        [TestMethod]
        public void ObtenerPorDNI_TEST()
        {
            const string ape = "Milici";
            const string esperado = "ConDatos";

            string valor = PacienteDao.ValidarApellido(ape);

            Assert.AreEqual(esperado, valor);
        }
    }
}
