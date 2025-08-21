
namespace Accounts.Services
{
    public class AccountService
    {
        public string GetAll()
        {
            try { return "Obteniendo todas las cuentas"; }
            catch (Exception ex) { throw; }
        }
        public string GetById(int id)
        {
            try { return $"Obteniendo cuenta con id {id}"; }
            catch (Exception ex) { throw; }
        }
        public string Create()
        {
            try { return "Cuenta creada exitosamente"; }
            catch (Exception ex) { throw; }
        }
        public string Update(int id)
        {
            try { return $"Cuenta con id {id} actualizada"; }
            catch (Exception ex) { throw; }
        }
        public string Delete(int id)
        {
            try { return $"Cuenta con id {id} eliminada"; }
            catch (Exception ex) { throw; }
        }
    }
}
