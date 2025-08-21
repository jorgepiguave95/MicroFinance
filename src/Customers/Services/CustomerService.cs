
namespace Customers.Services
{
    public class CustomerService
    {
        public string GetAll()
        {
            try { return "Obteniendo todos los clientes"; }
            catch (Exception ex) { throw; }
        }
        public string GetById(int id)
        {
            try { return $"Obteniendo cliente con id {id}"; }
            catch (Exception ex) { throw; }
        }
        public string Create()
        {
            try { return "Cliente creado exitosamente"; }
            catch (Exception ex) { throw; }
        }
        public string Update(int id)
        {
            try { return $"Cliente con id {id} actualizado"; }
            catch (Exception ex) { throw; }
        }
        public string Delete(int id)
        {
            try { return $"Cliente con id {id} eliminado"; }
            catch (Exception ex) { throw; }
        }
    }
}
