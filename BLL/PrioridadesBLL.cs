using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PrioridadesBLL
{
    private Context _context;
    public PrioridadesBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int PrioridadId)
    {
        return _context.Prioridades.Any(o => o.PrioridadId == PrioridadId);
    }

    private bool Insertar(Prioridades Prioridades)
    {
        _context.Prioridades.Add(Prioridades);
        return _context.SaveChanges() > 0;
    }

    private bool Modificar(Prioridades Prioridades)
    {
        var existe = _context.Prioridades.Find(Prioridades.PrioridadId);
        if(existe != null)
        {
            _context.Entry(existe).CurrentValues.SetValues(Prioridades);
            return _context.SaveChanges() > 0;
        }
        return false;
    }

    public bool Guardar(Prioridades Prioridades){
        if(!Existe(Prioridades.PrioridadId))
            return this.Insertar(Prioridades);
        else
            return this.Modificar(Prioridades);
    }

    public bool Eliminar(int PrioridadId)
    {
        var eliminado  = _context.Prioridades.Where(o=> o.PrioridadId== PrioridadId).SingleOrDefault();
        if(eliminado!=null){
            _context.Entry(eliminado).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        return false;
    }

    public Prioridades? Buscar(int PrioridadId)
    {
        return _context.Prioridades.Where(o => o.PrioridadId == PrioridadId).AsNoTracking().SingleOrDefault();
    }

    public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> criterio)
    {
        return _context.Prioridades.AsNoTracking().Where(criterio).ToList();
    }

    public bool VerificarExistencia(Prioridades Prioridades)
    {
        var PrioridadIgual = _context.Prioridades.Any(o =>o.Descripcion == Prioridades.Descripcion || o.DiasCompromiso == Prioridades.DiasCompromiso);
        if(PrioridadIgual)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}